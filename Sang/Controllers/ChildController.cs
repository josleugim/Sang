using System;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Sang.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

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


                if (Convert.ToInt32(nCuentas) >= 3)
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
                

                var result = Convert.ToInt32(sangchild.CuestionaryResult);

                //var client =
                //    _db.SangClients.Find(sangchild.SangClientId);

                if (result > 19)
                {
                    //return RedirectToAction("GenerateCouponChild", "Coupon", new {id = client.SangUserId });
                    var users = _db.SangUsers.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));

                    var client =
                        _db.SangClients.Where(u => u.SangUserId == users.SangUserID)
                           .OrderByDescending(c => c.SangClientID)
                           .FirstOrDefault();

                    var hosp = _db.Hospitals.FirstOrDefault(h => h.HospitalID.Equals(client.HospitalId));

                    var random = new Random();
                    int randomN = random.Next(1);

                    sangchild.CouponNumber = users.tempWarranty + randomN + client.SangClientID + sangchild.SangChildID;
                    sangchild.CouponUrl = "../../Content/Documents/" + sangchild.CouponNumber + ".pdf";

                    var doc = new Document(PageSize.A4);
                    var output = new FileStream(Server.MapPath("../../Content/Documents/" + sangchild.CouponNumber + ".pdf"), FileMode.Create);
                    var writer = PdfWriter.GetInstance(doc, output);

                    doc.Open();

                    var logoVale = Image.GetInstance(Server.MapPath("../../Content/images/Logo-vale.jpg"));
                    var logoSang = Image.GetInstance(Server.MapPath("../../Content/images/logo-sang.jpg"));
                    var sleepImage = Image.GetInstance(Server.MapPath("../../Content/images/sleep-image.jpg"));
                    var info = Image.GetInstance(Server.MapPath("../../Content/images/informes.jpg"));

                    var table = new PdfPTable(2);

                    var widths = new float[2];
                    widths[0] = 317.0F;
                    widths[1] = 483.0F;

                    table.SetTotalWidth(widths);

                    var cellLogoVale = new PdfPCell(logoVale, false) { Rowspan = 6, HorizontalAlignment = 1 };
                    table.AddCell(cellLogoVale);

                    var cellLogoSang = new PdfPCell(logoSang, false) { HorizontalAlignment = 1 };
                    table.AddCell(cellLogoSang);

                    var cellCategoria =
                        new PdfPCell(new Phrase("No. Vale: " + sangchild.CouponNumber,
                                                new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.WHITE)));
                    cellCategoria.BackgroundColor = new BaseColor(0, 0, 0);
                    cellCategoria.HorizontalAlignment = 2;
                    table.AddCell(cellCategoria);

                    var cellSleepImage = new PdfPCell(sleepImage, true) { HorizontalAlignment = 1 };
                    table.AddCell(cellSleepImage);

                    var cellNombreCompleto = new PdfPCell(new Phrase(sangchild.CompleteName, new Font(Font.FontFamily.HELVETICA, 11f, Font.NORMAL, BaseColor.WHITE))) { HorizontalAlignment = 1, BackgroundColor = new BaseColor(0, 0, 0) };
                    table.AddCell(cellNombreCompleto);

                    var cellInforme = new PdfPCell(info, true) { HorizontalAlignment = 1 };
                    table.AddCell(cellInforme);

                    var cellAddress = new PdfPCell(new Phrase(hosp.HospitalAddress, new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.WHITE))) { HorizontalAlignment = 0, BackgroundColor = new BaseColor(0, 0, 0) };
                    table.AddCell(cellAddress);

                    doc.Add(table);

                    doc.Close();
                }

                _db.SaveChanges();

                return RedirectToAction("Introduction", "Home");
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