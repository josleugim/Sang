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
    public class PurchaseController : Controller
    {
        private SangDBContext db = new SangDBContext();

        //
        // GET: /Purchase/

        public ViewResult Index()
        {
            var purchase = db.Purchase.Include(p => p.Warranty);
            return View(purchase.ToList());
        }

        //
        // GET: /Purchase/Details/5

        public ViewResult Details(int id)
        {
            Purchase purchase = db.Purchase.Find(id);
            return View(purchase);
        }

        //
        // GET: /Purchase/Create

        public ActionResult Create(int id)
        {
            //SangUser users = db.SangUsers.FirstOrDefault(c => c.Email.Equals(User.Identity.Name));
            Warranty warrant = db.Warranties.FirstOrDefault(c => c.WarrantyID.Equals(id));
            Purchase purchase = db.Purchase.FirstOrDefault(c => c.WarrantyId.Equals(warrant.WarrantyID));

            if (purchase == null)
            {
                ViewBag.WarrantyId = new SelectList(db.Warranties, "WarrantyID", "WarrantyCode");
                ViewBag.MattressId = new SelectList(db.ModelMattress, "ModelMattressID", "ModelName");
                List<string> size = new List<string> { "Individual", "Matrimonial", "King Size", "Queen Size" };
                ViewBag.Size = new SelectList(size);
                List<string> estado = new List<string> { "Aguascalientes", "Baja California", "Baja California Sur", "Campeche",
                    "Chiapas", "Chihuahua", "Coahuila", "Colima", "Durango", "Guanajuato", "Guerrero", "Hidalgo", "Jalisco", "México",
                "Michoacán de Ocampo", "Morelos", "Nayarit", "Nuevo León", "Oaxaca", "Puebla", "Querétaro", "Quintana Roo",
                "San Luis Potosí", "Sinaloa", "Sonora", "Tabasco", "Tamaulipas", "Tlaxcala", "Veracruz", "Yucatán", "Zacatecas"};
                ViewBag.estado = new SelectList(estado);

                Warranty warr = db.Warranties.Find(id);

                var model = new Purchase
                {
                    WarrantyId = warr.WarrantyID
                };
                return View(model);
            }
            else
                return View("Thanks");
        }

        //
        // POST: /Purchase/Create

        [HttpPost]
        public ActionResult Create(Purchase purchase, string MattressId, string Size, string calle, string nExt, string nInt, string colonia, string delMuni, string estado, string cp)
        {
            if (ModelState.IsValid)
            {
                int tempId = Convert.ToInt32(MattressId);
                ModelMattress matt = db.ModelMattress.FirstOrDefault(m => m.ModelMattressID.Equals(tempId));
                db.Purchase.Add(purchase);
                purchase.RegisterDate = DateTime.Now;
                purchase.MattressSize = Size;
                purchase.ModelMattress = matt;
                purchase.ModelMattresstId = tempId;
                db.SaveChanges();

                //Update the client address
                Warranty warr = db.Warranties.FirstOrDefault(s => s.WarrantyID.Equals(purchase.WarrantyId));
                int tempId2 = Convert.ToInt32(warr.SangClientId);
                SangClient client = db.SangClients.FirstOrDefault(c => c.SangClientID.Equals(tempId2));
                UpdateModel(client);
                client.Address = calle + ", número exterior " + nExt + " " + nInt;
                client.Colony = colonia;
                client.Township = delMuni;
                client.ShortState = estado;
                client.PostalCode = cp;
                db.SaveChanges();

                return View("Thanks");
            }

            ViewBag.WarrantyId = new SelectList(db.Warranties, "WarrantyID", "WarrantyCode", purchase.WarrantyId);
            ViewBag.MattressId = new SelectList(db.ModelMattress, "ModelMattressID", "ModelName");
            List<string> size = new List<string> { "Individual", "Matrimonial", "King Size", "Queen Size" };
            ViewBag.Size = new SelectList(size);
            List<string> estado2 = new List<string> { "Aguascalientes", "Baja California", "Baja California Sur", "Campeche",
                    "Chiapas", "Chihuahua", "Coahuila", "Colima", "Durango", "Guanajuato", "Guerrero", "Hidalgo", "Jalisco", "México",
                "Michoacán de Ocampo", "Morelos", "Nayarit", "Nuevo León", "Oaxaca", "Puebla", "Querétaro", "Quintana Roo",
                "San Luis Potosí", "Sinaloa", "Sonora", "Tabasco", "Tamaulipas", "Tlaxcala", "Veracruz", "Yucatán", "Zacatecas"};
            ViewBag.estado = new SelectList(estado2);
            return View(purchase);
        }

        public ViewResult Thanks()
        {
            return View();
        }

        //
        // GET: /Purchase/Edit/5

        public ActionResult Edit(int id)
        {
            Purchase purchase = db.Purchase.Find(id);
            ViewBag.WarrantyId = new SelectList(db.Warranties, "WarrantyID", "WarrantyCode", purchase.WarrantyId);
            return View(purchase);
        }

        //
        // POST: /Purchase/Edit/5

        [HttpPost]
        public ActionResult Edit(Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WarrantyId = new SelectList(db.Warranties, "WarrantyID", "WarrantyCode", purchase.WarrantyId);
            return View(purchase);
        }

        //
        // GET: /Purchase/Delete/5

        public ActionResult Delete(int id)
        {
            Purchase purchase = db.Purchase.Find(id);
            return View(purchase);
        }

        //
        // POST: /Purchase/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Purchase purchase = db.Purchase.Find(id);
            db.Purchase.Remove(purchase);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}