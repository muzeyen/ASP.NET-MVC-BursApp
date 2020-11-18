using BursApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BursApp.Controllers
{
    public class HomeController : Controller
    {
        BursDBContext db = new BursDBContext();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Burslar.ToList());
        }
        public ActionResult CreateBurs()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateBurs(Burslar burslar)
        {
            if (ModelState.IsValid)
            {               
                db.Burslar.Add(burslar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(burslar);
        }

        public ActionResult Edit(int? id) //soru işareti boş id gelebilir anlamında
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek Burs Bulunamadı";
            }
            var burs = db.Burslar.Find(id);
            if (burs == null)
            {
                return HttpNotFound();
            }

            return View(burs);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int? id, Burslar burs)
        {
            if (ModelState.IsValid)
            {
                var h = db.Burslar.Where(x => x.BursID == id).SingleOrDefault();
                h.BursBaslik = burs.BursBaslik;
                h.BursAciklama = burs.BursAciklama;
                h.BursMiktari = burs.BursMiktari;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(int id,Burslar burslar)
        {
            var burs = db.Burslar.Find(id);
            if (burs == null)
            {
                return HttpNotFound();
            }
            return View(burs);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var h = db.Burslar.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            db.Burslar.Remove(h);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}