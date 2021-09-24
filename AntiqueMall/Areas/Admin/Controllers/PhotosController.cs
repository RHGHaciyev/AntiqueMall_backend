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
    public class PhotosController : Controller
    {
        private AnticDataEntities db = new AnticDataEntities();

        // GET: Admin/Photos
        public ActionResult Index()
        {
            if (Session["Aloged"] != null)
            {
                return View(db.Photos.ToList());
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }

        }

        // GET: Admin/Photos/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Aloged"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Photo photo = db.Photos.Find(id);
                if (photo == null)
                {
                    return HttpNotFound();
                }
                return View(photo);
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }
  
        }

        // GET: Admin/Photos/Create
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

        // POST: Admin/Photos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "photo_id,")] Photo photo,HttpPostedFileBase photos_path)
        {
            if (ModelState.IsValid)
            {
                if(photos_path.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(photos_path.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads/AnticPhotos"), fileName);
                    var newName = fileName;
                    photos_path.SaveAs(path);
                    photo.photos_path = "/Uploads/AnticPhotos/" + fileName;
                    db.Photos.Add(photo);
                    db.SaveChanges();
                }
                
                return RedirectToAction("Index");
            }

            return View(photo);
        }

        // GET: Admin/Photos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Aloged"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Photo photo = db.Photos.Find(id);
                if (photo == null)
                {
                    return HttpNotFound();
                }
                return View(photo);
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }
  
        }

        // POST: Admin/Photos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "photo_id,photos_path")] Photo photo)
        {
            if (ModelState.IsValid)
            {

                db.Entry(photo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(photo);
        }

        // GET: Admin/Photos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Aloged"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Photo photo = db.Photos.Find(id);
                if (photo == null)
                {
                    return HttpNotFound();
                }
                return View(photo);
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }
   
        }

        // POST: Admin/Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Photo photo = db.Photos.Find(id);
            db.Photos.Remove(photo);
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
