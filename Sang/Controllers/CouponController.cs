using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sang.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Sang.Controllers
{
    public class CouponController : Controller
    {
        private readonly SangDBContext _db = new SangDBContext();

        //
        // GET: /Coupon/

        public ViewResult Index(string cupon)
        {
            if (Request.HttpMethod == "POST")
            {
                var couponResult = _db.Coupons.Include(u => u.SangUser)
                    .Where(c => c.CouponNumber.Equals(cupon));

                return View(couponResult.ToList());
            }
            var coupons = _db.Coupons.Include(c => c.SangUser);
            return View(coupons.ToList());
        }

        //
        // GET: /Coupon/Details/5

        public ViewResult Details(int id)
        {
            Coupon coupon = _db.Coupons.Find(id);
            return View(coupon);
        }

        //Genera vale para consulta
        public ActionResult GenerateAppointment(int id)
        {
            var users = _db.SangUsers.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));

            var client =
                _db.SangClients.Where(u => u.SangUserId == users.SangUserID)
                   .OrderByDescending(c => c.SangClientID)
                   .FirstOrDefault();

            var hosp = _db.Hospitals.FirstOrDefault(h => h.HospitalID.Equals(client.HospitalId));

            var random = new Random(1000);
            int randomN = random.Next();

            var coupon = new Coupon();
            coupon.SangUserId = id;
            coupon.SangUser = users;
            coupon.CouponNumber = users.tempWarranty + randomN;
            coupon.RegisterDate = DateTime.Now;
            coupon.CouponURL = "../../Content/Documents/" + coupon.CouponNumber + ".pdf";
            _db.Coupons.Add(coupon);
            _db.SaveChanges();

            var doc = new Document(PageSize.A4);
            var output = new FileStream(Server.MapPath("../../Content/Documents/" + coupon.CouponNumber + ".pdf"), FileMode.Create);
            var writer = PdfWriter.GetInstance(doc, output);

            doc.Open();


            var logoVale = Image.GetInstance(Server.MapPath("../../Content/images/Logo-vale.jpg"));
            var logoSang = Image.GetInstance(Server.MapPath("../../Content/images/logo-sang.jpg"));
            var sleepImage = Image.GetInstance(Server.MapPath("../../Content/images/vale-consulta.jpg"));
            var info = Image.GetInstance(Server.MapPath("../../Content/images/informes.jpg"));

            var table = new PdfPTable(2);

            float[] widths = new float[2];
            widths[0] = 317.0F;
            widths[1] = 483.0F;

            table.SetTotalWidth(widths);

            var cellLogoVale = new PdfPCell(logoVale, false) { Rowspan = 6, HorizontalAlignment = 1 };
            table.AddCell(cellLogoVale);

            var cellLogoSang = new PdfPCell(logoSang, false) { HorizontalAlignment = 1 };
            table.AddCell(cellLogoSang);

            var cellCategoria =
                new PdfPCell(new Phrase("No. Vale: " + "LP12341932043748",
                                        new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.WHITE)));
            cellCategoria.BackgroundColor = new BaseColor(0, 0, 0);
            cellCategoria.HorizontalAlignment = 2;
            table.AddCell(cellCategoria);

            var cellSleepImage = new PdfPCell(sleepImage, true) { HorizontalAlignment = 1 };
            table.AddCell(cellSleepImage);

            var cellNombreCompleto = new PdfPCell(new Phrase(client.CompleteName, new Font(Font.FontFamily.HELVETICA, 11f, Font.NORMAL, BaseColor.WHITE))) { HorizontalAlignment = 1, BackgroundColor = new BaseColor(0, 0, 0) };
            table.AddCell(cellNombreCompleto);

            var cellInforme = new PdfPCell(info, true) { HorizontalAlignment = 1 };
            table.AddCell(cellInforme);

            var cellAddress = new PdfPCell(new Phrase(hosp.HospitalAddress, new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.WHITE))) { HorizontalAlignment = 0, BackgroundColor = new BaseColor(0, 0, 0) };
            table.AddCell(cellAddress);

            doc.Add(table);

            doc.Close();

            return RedirectToAction("AdultResult", "Home", new
            {
                id = client.SangClientID,
                d1 = Convert.ToInt32(client.Disorder1),
                d2 = Convert.ToInt32(client.Disorder2),
                d3 = Convert.ToInt32(client.Disorder3),
                d4 = Convert.ToInt32(client.Disorder4),
                d5 = Convert.ToInt32(client.Disorder5),
                d7 = Convert.ToInt32(client.Disorder7),
                d8 = Convert.ToInt32(client.Disorder8)
            });

            //return Redirect("../../Content/Documents/" + coupon.CouponNumber + ".pdf");
        }

        
        /// <summary>
        /// Generates the coupon.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public ActionResult GenerateCoupon(int id)
        {
            var users = _db.SangUsers.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));

            var client =
                _db.SangClients.Where(u => u.SangUserId == users.SangUserID)
                   .OrderByDescending(c => c.SangClientID)
                   .FirstOrDefault();

            var hosp = _db.Hospitals.FirstOrDefault(h => h.HospitalID.Equals(client.HospitalId));

            var random = new Random(1000);
            int randomN = random.Next();

            var coupon = new Coupon();
            coupon.SangUserId = id;
            coupon.SangUser = users;
            coupon.CouponNumber = users.tempWarranty + randomN;
            coupon.RegisterDate = DateTime.Now;
            coupon.CouponURL = "../../Content/Documents/" + coupon.CouponNumber + ".pdf";
            _db.Coupons.Add(coupon);
            _db.SaveChanges();

            var doc = new Document(PageSize.A4);
            var output = new FileStream(Server.MapPath("../../Content/Documents/" + coupon.CouponNumber + ".pdf"), FileMode.Create);
            var writer = PdfWriter.GetInstance(doc, output);

            doc.Open();


            var logoVale = Image.GetInstance(Server.MapPath("../../Content/images/Logo-vale.jpg"));
            var logoSang = Image.GetInstance(Server.MapPath("../../Content/images/logo-sang.jpg"));
            var sleepImage = Image.GetInstance(Server.MapPath("../../Content/images/sleep-image.jpg"));
            var info = Image.GetInstance(Server.MapPath("../../Content/images/informes.jpg"));

            var table = new PdfPTable(2);

            float[] widths = new float[2];
            widths[0] = 317.0F;
            widths[1] = 483.0F;

            table.SetTotalWidth(widths);

            var cellLogoVale = new PdfPCell(logoVale, false) { Rowspan = 6, HorizontalAlignment = 1 };
            table.AddCell(cellLogoVale);

            var cellLogoSang = new PdfPCell(logoSang, false) { HorizontalAlignment = 1 };
            table.AddCell(cellLogoSang);

            var cellCategoria =
                new PdfPCell(new Phrase("No. Vale: " + coupon.CouponNumber,
                                        new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.WHITE)));
            cellCategoria.BackgroundColor = new BaseColor(0, 0, 0);
            cellCategoria.HorizontalAlignment = 2;
            table.AddCell(cellCategoria);

            var cellSleepImage = new PdfPCell(sleepImage, true) { HorizontalAlignment = 1 };
            table.AddCell(cellSleepImage);

            var cellNombreCompleto = new PdfPCell(new Phrase(client.CompleteName, new Font(Font.FontFamily.HELVETICA, 11f, Font.NORMAL, BaseColor.WHITE))) { HorizontalAlignment = 1, BackgroundColor = new BaseColor(0, 0, 0) };
            table.AddCell(cellNombreCompleto);

            var cellInforme = new PdfPCell(info, true) { HorizontalAlignment = 1 };
            table.AddCell(cellInforme);

            var cellAddress = new PdfPCell(new Phrase(hosp.HospitalAddress, new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.WHITE))) { HorizontalAlignment = 0, BackgroundColor = new BaseColor(0, 0, 0) };
            table.AddCell(cellAddress);

            doc.Add(table);

            doc.Close();

            //Validar si son 2 usuarios y enviar a crear nuevo
            if (client.nMattressUsers == 2)
            {
                return RedirectToAction("Create", "Client");
            }

            //return RedirectToAction("AdultResult", "Home", new
            //{
            //    id = client.SangClientID,
            //    d1 = Convert.ToInt32(client.Disorder1),
            //    d2 = Convert.ToInt32(client.Disorder2),
            //    d3 = Convert.ToInt32(client.Disorder3),
            //    d4 = Convert.ToInt32(client.Disorder4),
            //    d5 = Convert.ToInt32(client.Disorder5),
            //    d7 = Convert.ToInt32(client.Disorder7),
            //    d8 = Convert.ToInt32(client.Disorder8)
            //});

            //return Redirect("../../Content/Documents/" + coupon.CouponNumber + ".pdf");

            return RedirectToActionPermanent("Create", "Client");
        }

        public ActionResult GenerateCouponChild(int id)
        {
            var users = _db.SangUsers.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));

            var client =
                _db.SangClients.Where(u => u.SangUserId == users.SangUserID)
                   .OrderByDescending(c => c.SangClientID)
                   .FirstOrDefault();

            var child =
                    _db.SangChildren.Where(u => u.SangClientId == client.SangClientID)
                   .OrderByDescending(c => c.SangChildID)
                   .FirstOrDefault();

            var hosp = _db.Hospitals.FirstOrDefault(h => h.HospitalID.Equals(client.HospitalId));

            var random = new Random(1000);
            int randomN = random.Next();

            var coupon = new Coupon();
            coupon.SangUserId = id;
            coupon.SangUser = users;
            coupon.CouponNumber = users.tempWarranty + randomN;
            coupon.RegisterDate = DateTime.Now;
            coupon.CouponURL = "../../Content/Documents/" + coupon.CouponNumber + ".pdf";
            _db.Coupons.Add(coupon);
            _db.SaveChanges();

            var doc = new Document(PageSize.A4);
            var output = new FileStream(Server.MapPath("../../Content/Documents/" + coupon.CouponNumber + ".pdf"), FileMode.Create);
            var writer = PdfWriter.GetInstance(doc, output);

            doc.Open();


            var logoVale = Image.GetInstance(Server.MapPath("../../Content/images/Logo-vale.jpg"));
            var logoSang = Image.GetInstance(Server.MapPath("../../Content/images/logo-sang.jpg"));
            var sleepImage = Image.GetInstance(Server.MapPath("../../Content/images/sleep-image.jpg"));
            var info = Image.GetInstance(Server.MapPath("../../Content/images/informes.jpg"));

            var table = new PdfPTable(2);

            float[] widths = new float[2];
            widths[0] = 317.0F;
            widths[1] = 483.0F;

            table.SetTotalWidth(widths);

            var cellLogoVale = new PdfPCell(logoVale, false) { Rowspan = 6, HorizontalAlignment = 1 };
            table.AddCell(cellLogoVale);

            var cellLogoSang = new PdfPCell(logoSang, false) { HorizontalAlignment = 1 };
            table.AddCell(cellLogoSang);

            var cellCategoria =
                new PdfPCell(new Phrase("No. Vale: " + coupon.CouponNumber,
                                        new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.WHITE)));
            cellCategoria.BackgroundColor = new BaseColor(0, 0, 0);
            cellCategoria.HorizontalAlignment = 2;
            table.AddCell(cellCategoria);

            var cellSleepImage = new PdfPCell(sleepImage, true) { HorizontalAlignment = 1 };
            table.AddCell(cellSleepImage);

            var cellNombreCompleto = new PdfPCell(new Phrase(child.CompleteName, new Font(Font.FontFamily.HELVETICA, 11f, Font.NORMAL, BaseColor.WHITE))) { HorizontalAlignment = 1, BackgroundColor = new BaseColor(0, 0, 0) };
            table.AddCell(cellNombreCompleto);

            var cellInforme = new PdfPCell(info, true) { HorizontalAlignment = 1 };
            table.AddCell(cellInforme);

            var cellAddress = new PdfPCell(new Phrase(hosp.HospitalAddress, new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.WHITE))) { HorizontalAlignment = 0, BackgroundColor = new BaseColor(0, 0, 0) };
            table.AddCell(cellAddress);

            doc.Add(table);

            doc.Close();

            return RedirectToActionPermanent("Create", "Client");
        }

        //
        // GET: /Coupon/Create

        public ActionResult Create(int id)
        {
            ViewBag.SangUserId = new SelectList(_db.SangUsers, "SangUserID", "Email");
            return View();
        }

        //
        // POST: /Coupon/Create

        [HttpPost]
        public ActionResult Create(Coupon coupon)
        {
            if (ModelState.IsValid)
            {
                _db.Coupons.Add(coupon);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SangUserId = new SelectList(_db.SangUsers, "SangUserID", "Email", coupon.SangUserId);
            return View(coupon);
        }

        //
        // GET: /Coupon/Edit/5

        public ActionResult Edit(int id)
        {
            Coupon coupon = _db.Coupons.Find(id);
            ViewBag.SangUserId = new SelectList(_db.SangUsers, "SangUserID", "Email", coupon.SangUserId);
            return View(coupon);
        }

        //
        // POST: /Coupon/Edit/5

        [HttpPost]
        public ActionResult Edit(Coupon coupon)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(coupon).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SangUserId = new SelectList(_db.SangUsers, "SangUserID", "Email", coupon.SangUserId);
            return View(coupon);
        }

        //
        // GET: /Coupon/Delete/5

        public ActionResult Delete(int id)
        {
            Coupon coupon = _db.Coupons.Find(id);
            return View(coupon);
        }

        //
        // POST: /Coupon/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Coupon coupon = _db.Coupons.Find(id);
            _db.Coupons.Remove(coupon);
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