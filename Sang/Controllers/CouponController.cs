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

        //
        // GET: /Coupon/Create

        public ActionResult Create()
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