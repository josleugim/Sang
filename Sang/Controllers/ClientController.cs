using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sang.Models;

namespace Sang.Controllers
{
    public class ClientController : Controller
    {
        private SangDBContext _db = new SangDBContext();

        //
        // GET: /Client/

        public ViewResult Index()
        {
            var sangclients = _db.SangClients.Include(s => s.SangUser).Include(s => s.Hospital);
            return View(sangclients.ToList());
        }

        //
        // GET: /Client/Details/5

        public ViewResult Details(int id)
        {
            SangClient sangclient = _db.SangClients.Find(id);
            return View(sangclient);
        }

        //
        // GET: /Client/Create

        public ActionResult Create()
        {
            int nCuentas = 0;
            var users = _db.SangUsers.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));
            //var client = _db.SangClients.FirstOrDefault(c => c.SangUser.SangUserID.Equals(users.SangUserID));
            var client =
                _db.SangClients.Where(u => u.SangUserId == users.SangUserID)
                   .OrderByDescending(c => c.SangClientID)
                   .FirstOrDefault();

            //Cuantos clientes existen
            var nClient = from e in _db.SangClients
                          where e.SangUser.SangUserID == users.SangUserID
                          select e;

            if (nClient.Any())
            {
                var nChildren = from c in _db.SangChildren
                                where c.SangClientId == client.SangClientID
                                select c;

                nCuentas = nClient.Count() + nChildren.Count();

            }

            if (Convert.ToInt32(nCuentas) >= 2)
                return View("Thanks");
            else
            {
                ViewBag.HospitalId = new SelectList(_db.Hospitals, "HospitalID", "HospitalName");
                if (client == null)
                {
                    var n = new List<int> {1, 2};
                    ViewBag.nMattress = new SelectList(n);

                    //Set the ID of the relational sanguser
                    var model = new SangClient()
                        {
                            SangUserId = users.SangUserID,
                            SangUser = users,
                            Gender = "Ninguno"
                        };

                    return View(model);
                }
                    //
                    //Si ya existe la cuenta se envía la garantía
                else
                    return RedirectToAction("Create", "Purchase", new { id = users.tempWarranty });
            }
        }

        //
        // POST: /Client/Create

        [HttpPost]
        public ActionResult Create(SangClient sangclient, string cGender, string nMattress)
        {
            if (ModelState.IsValid && sangclient.PrivacyNotice != false)
            {
                var users = _db.SangUsers.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));

                _db.SangClients.Add(sangclient);
                sangclient.CompleteName = sangclient.UserName + " " + sangclient.FirstName + " " + sangclient.LastName;
                sangclient.Gender = cGender;
                sangclient.RegisterDate = DateTime.Now;
                sangclient.SangUser = users;
                //sangclient.Hospital = hosp;
                sangclient.nMattressUsers = Convert.ToInt32(nMattress);
                _db.SaveChanges();
                //return RedirectToAction("AdultCuestionary", new { id = sangclient.SangClientID });

                //Update the client in the warranty
                var warranty = _db.Warranties.FirstOrDefault(s => s.WarrantyCode.Equals(users.tempWarranty));
                UpdateModel(warranty);
                warranty.SangClient = sangclient;
                _db.SaveChanges();

                return RedirectToAction("Create", "Purchase", new { id = warranty.WarrantyCode });
            }

            var n = new List<int> { 1, 2 };
            ViewBag.nMattress = new SelectList(n);

            ViewBag.HospitalId = new SelectList(_db.Hospitals, "HospitalID", "HospitalName");

            return View(sangclient);
        }

        //
        // GET: /Client/Edit/5

        public ActionResult Edit(int id)
        {
            SangClient sangclient = _db.SangClients.Find(id);
            ViewBag.SangUserId = new SelectList(_db.SangUsers, "SangUserID", "Email", sangclient.SangUserId);
            ViewBag.HospitalId = new SelectList(_db.Hospitals, "HospitalID", "HospitalName", sangclient.HospitalId);
            return View(sangclient);
        }

        //
        // POST: /Client/Edit/5

        [HttpPost]
        public ActionResult Edit(SangClient sangclient)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(sangclient).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SangUserId = new SelectList(_db.SangUsers, "SangUserID", "Email", sangclient.SangUserId);
            ViewBag.HospitalId = new SelectList(_db.Hospitals, "HospitalID", "HospitalName", sangclient.HospitalId);
            return View(sangclient);
        }

        //
        // GET: /Client/Delete/5

        public ActionResult Delete(int id)
        {
            SangClient sangclient = _db.SangClients.Find(id);
            return View(sangclient);
        }

        //
        // POST: /Client/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SangClient sangclient = _db.SangClients.Find(id);
            _db.SangClients.Remove(sangclient);
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