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
    public class CollectionController : Controller
    {
        private SangDBContext db = new SangDBContext();

        //
        // GET: /Collection/

        public ViewResult Index()
        {
            return View(db.Collections.ToList());
        }

        //
        // GET: /Collection/Details/5

        public ViewResult Details(int id)
        {
            Collection collection = db.Collections.Find(id);
            return View(collection);
        }

        //
        // GET: /Collection/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Collection/Create

        [HttpPost]
        public ActionResult Create(Collection collection)
        {
            if (ModelState.IsValid)
            {
                db.Collections.Add(collection);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(collection);
        }
        
        //
        // GET: /Collection/Edit/5
 
        public ActionResult Edit(int id)
        {
            Collection collection = db.Collections.Find(id);
            return View(collection);
        }

        //
        // POST: /Collection/Edit/5

        [HttpPost]
        public ActionResult Edit(Collection collection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(collection);
        }

        //
        // GET: /Collection/Delete/5
 
        public ActionResult Delete(int id)
        {
            Collection collection = db.Collections.Find(id);
            return View(collection);
        }

        //
        // POST: /Collection/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Collection collection = db.Collections.Find(id);
            db.Collections.Remove(collection);
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