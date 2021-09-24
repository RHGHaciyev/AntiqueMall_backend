using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AntiqueMall.Models;
using System.IO;

namespace AntiqueMall.Areas.Admin.Controllers
{
    public class SlidersController : Controller
    {
        private AnticDataEntities db = new AnticDataEntities();

        // GET: Admin/Sliders
        public ActionResult Index()
        {
            if (Session["Aloged"] != null)
            {
                return View(db.Sliders.ToList());
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }   
        }

        // GET: Admin/Sliders/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Aloged"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Slider slider = db.Sliders.Find(id);
                if (slider == null)
                {
                    return HttpNotFound();
                }
                return View(slider);
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }
 
        }

        // GET: Admin/Sliders/Create
        public ActionResult Create()
        {
            if (Session["Aloged"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }

        }

        // POST: Admin/Sliders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,text")] Slider slider,HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(photo.FileName);
                var path = Path.Combine(Server.MapPath("~/Uploads/AnticPhotos"), fileName);
                photo.SaveAs(path);
                slider.photo = "/Uploads/AnticPhotos/" + fileName;
                db.Sliders.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slider);
        }

        // GET: Admin/Sliders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Aloged"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Slider slider = db.Sliders.Find(id);
                if (slider == null)
                {
                    return HttpNotFound();
                }
                return View(slider);
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }
 
        }

        // POST: Admin/Sliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,photo,title,text")] Slider slider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slider);
        }

        // GET: Admin/Sliders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Aloged"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Slider slider = db.Sliders.Find(id);
                if (slider == null)
                {
                    return HttpNotFound();
                }
                return View(slider);
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }
            
        }

        // POST: Admin/Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = db.Sliders.Find(id);
            db.Sliders.Remove(slider);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
