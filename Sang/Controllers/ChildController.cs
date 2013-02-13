using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Sang.Models;

namespace Sang.Controllers
{
    public class ChildController : Controller
    {
        private readonly SangDBContext _db = new SangDBContext();

        //
        // GET: /Child/

        public ViewResult Index()
        {
            var sangchildren = _db.SangChildren.Include(s => s.SangClient);
            return View(sangchildren.ToList());
        }

        //
        // GET: /Child/Details/5

        public ViewResult Details(int id)
        {
            SangChild sangchild = _db.SangChildren.Find(id);
            return View(sangchild);
        }

        //
        // GET: /Child/Create

        public ActionResult Create()
        {
            var users = _db.SangUsers.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));
            var client =
                _db.SangClients.Where(u => u.SangUserId == users.SangUserID)
                   .OrderByDescending(c => c.SangClientID)
                   .FirstOrDefault();

            //Verificación del número de registros creados
            var nClient = from e in _db.SangClients
                          where e.SangUser.SangUserID == users.SangUserID
                          select e;

            if (nClient.Any())
            {
                var nChild = from c in _db.SangChildren
                             where c.SangClientId == client.SangClientID
                             select c;

                var nCuentas = nClient.Count() + nChild.Count();


                if (Convert.ToInt32(nCuentas) >= 2)
                    return View("Thanks");

                //Cuando ya existe un menor creado
                var child =
                    _db.SangChildren.Where(u => u.SangClientId == client.SangClientID)
                   .OrderByDescending(c => c.SangChildID)
                   .FirstOrDefault();
                View(child != null && child.CuestionaryResult.HasValue ? "Thanks" : "Edit");

                //Tiene que existir un mayor de edad para crear la cuenta de un menor
                if (client != null)
                {
                    var model = new SangChild()
                    {
                        SangClientId = client.SangClientID,
                        SangClient = client
                    };

                    return View(model);
                }
            }

            return View();
        }

        //
        // POST: /Child/Create

        [HttpPost]
        public ActionResult Create(SangChild sangchild)
        {
            if (ModelState.IsValid)
            {
                _db.SangChildren.Add(sangchild);
                sangchild.RegisterDate = DateTime.Now;
                sangchild.CompleteName = sangchild.Name + " " + sangchild.FirstName + " " + sangchild.LastName;
                _db.SaveChanges();
                return RedirectToAction("Edit", new { id = sangchild.SangChildID });
            }

            //ViewBag.SangClientId = new SelectList(db.SangClients, "SangClientID", "UserName", sangchild.SangClientId);
            return View(sangchild);
        }

        //
        // GET: /Child/Edit/5

        public ActionResult Edit(int id)
        {
            SangChild sangchild = _db.SangChildren.Find(id);
            return View(sangchild);
        }

        //
        // POST: /Child/Edit/5

        [HttpPost]
        public ActionResult Edit(SangChild sangchild, int id, string Q1, string Q2, string Q3, string Q4, string Q5, string Q6, string Q7, string Q8,
            string Q9)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(sangchild).State = EntityState.Modified;
                sangchild.CuestionaryResult = Convert.ToInt32(Q1) + Convert.ToInt32(Q2) + Convert.ToInt32(Q3) + Convert.ToInt32(Q4) + Convert.ToInt32(Q5) + Convert.ToInt32(Q6) + Convert.ToInt32(Q7) +
                    Convert.ToInt32(Q8) + Convert.ToInt32(Q9);
                _db.SaveChanges();

                var result = Convert.ToInt32(sangchild.CuestionaryResult);

                if (result > 19)
                    return RedirectToAction("GenerateCouponChild", "Coupon", new {id = sangchild.SangClient.SangUserId});

                return RedirectToAction("Create", "Client");
            }
            return View(sangchild);
        }

        //
        // GET: /Child/Delete/5

        public ActionResult Delete(int id)
        {
            SangChild sangchild = _db.SangChildren.Find(id);
            return View(sangchild);
        }

        //
        // POST: /Child/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SangChild sangchild = _db.SangChildren.Find(id);
            _db.SangChildren.Remove(sangchild);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}