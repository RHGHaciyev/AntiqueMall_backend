using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AntiqueMall.Models;

namespace AntiqueMall.Areas.Admin.Controllers
{
    public class MenusController : Controller
    {
        private AnticDataEntities db = new AnticDataEntities();

        // GET: Admin/Menus
        public ActionResult Index()
        {
            if (Session["Aloged"] != null)
            {
                var menus = db.Menus.Include(m => m.Submenu);
                return View(menus.ToList());
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }

            
        }

        // GET: Admin/Menus/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Aloged"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Menu menu = db.Menus.Find(id);
                if (menu == null)
                {
                    return HttpNotFound();
                }
                return View(menu);
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }
 
        }

        // GET: Admin/Menus/Create
        public ActionResult Create()
        {
            if (Session["Aloged"] != null)
            {
                ViewBag.sub_menu_id = new SelectList(db.Submenus, "id", "name");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }


            
        }

        // POST: Admin/Menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,sub_menu_id")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Menus.Add(menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sub_menu_id = new SelectList(db.Submenus, "id", "name", menu.sub_menu_id);
            return View(menu);
        }

        // GET: Admin/Menus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Aloged"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Menu menu = db.Menus.Find(id);
                if (menu == null)
                {
                    return HttpNotFound();
                }
                ViewBag.sub_menu_id = new SelectList(db.Submenus, "id", "name", menu.sub_menu_id);
                return View(menu);
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }  
        }

        // POST: Admin/Menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,sub_menu_id")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sub_menu_id = new SelectList(db.Submenus, "id", "name", menu.sub_menu_id);
            return View(menu);
        }

        // GET: Admin/Menus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Aloged"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Menu menu = db.Menus.Find(id);
                if (menu == null)
                {
                    return HttpNotFound();
                }
                return View(menu);
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            } 
        }

        // POST: Admin/Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Menu menu = db.Menus.Find(id);
            db.Menus.Remove(menu);
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
