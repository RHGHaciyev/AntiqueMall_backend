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
    public class usersController : Controller
    {
        private AnticDataEntities db = new AnticDataEntities();

        // GET: Admin/users
        public ActionResult Index()
        {
            if (Session["Aloged"] != null)
            {
                return View(db.users.ToList());

            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }

        
        }

        // GET: Admin/users/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Aloged"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                user user = db.users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }
    
        }

        // GET: Admin/users/Create
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

        // POST: Admin/users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,email,password,idea,shopVintage,Balance")] user user,HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                if(photo.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(photo.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads/Photos"), fileName);
                    var newName = fileName;
                    photo.SaveAs(path);
                    user.photo = "/Uploads/Photos/" + fileName;
                    db.users.Add(user);
                    db.SaveChanges();
                }
               
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Admin/users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Aloged"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                user user = db.users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }

            
        }

        // POST: Admin/users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,email,password,photo,idea,shopVintage,Balance")] user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Admin/users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Aloged"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                user user = db.users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }

            
        }

        // POST: Admin/users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = db.users.Find(id);
            db.users.Remove(user);
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
