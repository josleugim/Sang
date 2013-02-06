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

        //Generación de vale
        public ActionResult GenerateCoupon(int id)
        {
            var users = _db.SangUsers.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));
            //var client =
            //    _db.SangClients.Where(u => u.SangUserId == users.SangUserID)
            //       .OrderByDescending(c => c.SangClientID)
            //       .FirstOrDefault();

            var random = new Random();
            int randomN = random.Next();

            //var coupon = new Coupon();
            //coupon.SangUserId = id;
            //coupon.SangUser = users;
            //coupon.CouponNumber = users.tempWarranty + randomN;
            //coupon.RegisterDate = DateTime.Now;
            //coupon.CouponURL = "../../Content/Documents/" + coupon.CouponNumber + ".pdf";
            //_db.Coupons.Add(coupon);
            //_db.SaveChanges();

            var doc = new Document(PageSize.A4);
            var output = new FileStream(Server.MapPath("../../Content/Documents/" + "LP12341932043748" + ".pdf"), FileMode.Create);
            var writer = PdfWriter.GetInstance(doc, output);

            doc.Open();

            
            var logoVale = Image.GetInstance(Server.MapPath("../../Content/images/Logo-vale.jpg"));
            var logoSang = Image.GetInstance(Server.MapPath("../../Content/images/logo-sang.jpg"));
            var sleepImage = Image.GetInstance(Server.MapPath("../../Content/images/sleep-image.jpg"));
            var sleepImage2 = Image.GetInstance(Server.MapPath("../../Content/images/sleep-image2.jpg"));

            var table = new PdfPTable(2);

            float[] widths = new float[2];
            widths[0] = 317.0F;
            widths[1] = 483.0F;

            table.SetTotalWidth(widths);

            var cellLogoVale = new PdfPCell(logoVale, false) {Rowspan = 6, HorizontalAlignment = 1};
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
            //var cellSleepImage2 = new PdfPCell(sleepImage2, true) { HorizontalAlignment = 1 };
            //table.AddCell(cellSleepImage2);


            var cell = new PdfPCell(new Phrase("1. Datos generales", new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.WHITE)));
            cell.Colspan = 4;
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            cell.BackgroundColor = new BaseColor(128, 128, 128);
            table.AddCell(cell);

            table.AddCell("!!");
            table.AddCell("No. de cliente");
            table.AddCell("");

            table.AddCell("Giro");

            var cellGiro =
                new PdfPCell(new Phrase("", new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.BLACK)));
            cellGiro.Colspan = 3;
            table.AddCell(cellGiro);

            table.AddCell("Eslogan (Lema publicitario)");

            var cellEslogan =
                new PdfPCell(new Phrase("", new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL, BaseColor.BLACK)));
            cellEslogan.Colspan = 3;
            table.AddCell(cellEslogan);

            doc.Add(table);

            doc.Close();

            return View();
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