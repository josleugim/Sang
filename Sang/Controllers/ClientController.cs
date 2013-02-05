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
        private SangDBContext db = new SangDBContext();

        //
        // GET: /Client/

        public ViewResult Index()
        {
            var sangclients = db.SangClients.Include(s => s.SangUser).Include(s => s.Hospital);
            return View(sangclients.ToList());
        }

        //
        // GET: /Client/Details/5

        public ViewResult Details(int id)
        {
            SangClient sangclient = db.SangClients.Find(id);
            return View(sangclient);
        }

        //
        // GET: /Client/Create

        public ActionResult Create()
        {
            ViewBag.SangUserId = new SelectList(db.SangUsers, "SangUserID", "Email");
            ViewBag.HospitalId = new SelectList(db.Hospitals, "HospitalID", "HospitalName");
            return View();
        } 

        //
        // POST: /Client/Create

        [HttpPost]
        public ActionResult Create(SangClient sangclient)
        {
            if (ModelState.IsValid)
            {
                db.SangClients.Add(sangclient);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.SangUserId = new SelectList(db.SangUsers, "SangUserID", "Email", sangclient.SangUserId);
            ViewBag.HospitalId = new SelectList(db.Hospitals, "HospitalID", "HospitalName", sangclient.HospitalId);
            return View(sangclient);
        }
        
        //
        // GET: /Client/Edit/5
 
        public ActionResult Edit(int id)
        {
            SangClient sangclient = db.SangClients.Find(id);
            ViewBag.SangUserId = new SelectList(db.SangUsers, "SangUserID", "Email", sangclient.SangUserId);
            ViewBag.HospitalId = new SelectList(db.Hospitals, "HospitalID", "HospitalName", sangclient.HospitalId);
            return View(sangclient);
        }

        //
        // POST: /Client/Edit/5

        [HttpPost]
        public ActionResult Edit(SangClient sangclient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sangclient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SangUserId = new SelectList(db.SangUsers, "SangUserID", "Email", sangclient.SangUserId);
            ViewBag.HospitalId = new SelectList(db.Hospitals, "HospitalID", "HospitalName", sangclient.HospitalId);
            return View(sangclient);
        }

        //
        // GET: /Client/Delete/5
 
        public ActionResult Delete(int id)
        {
            SangClient sangclient = db.SangClients.Find(id);
            return View(sangclient);
        }

        //
        // POST: /Client/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            SangClient sangclient = db.SangClients.Find(id);
            db.SangClients.Remove(sangclient);
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