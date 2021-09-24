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
    public class ProductsController : Controller
    {
        private AnticDataEntities db = new AnticDataEntities();

        // GET: Admin/Products
        public ActionResult Index()
        {
            if (Session["Aloged"] != null)
            {
                var products = db.Products.Distinct().Include(p => p.Category).Include(p => p.Photo).Include(p => p.Product_tags).Distinct();
                return View(products.ToList());
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }
            
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Aloged"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Product product = db.Products.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }
  
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            if (Session["Aloged"] != null)
            {
                ViewBag.category_id = new SelectList(db.Categories, "id", "Category_Name");
                ViewBag.photo_id = new SelectList(db.Photos, "photo_id", "photos_path");
                ViewBag.tag_id = new SelectList(db.Product_tags, "tag_id", "tag_name");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }
           
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "product_id,title,product_name,product_price,category_id,availability,tag_id,photo_id,product_number,weight,dimensions,description,status")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.category_id = new SelectList(db.Categories, "id", "Category_Name", product.category_id);
            ViewBag.photo_id = new SelectList(db.Photos, "photo_id", "photos_path", product.photo_id);
            ViewBag.tag_id = new SelectList(db.Product_tags, "tag_id", "tag_name", product.tag_id);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Aloged"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Product product = db.Products.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                ViewBag.category_id = new SelectList(db.Categories, "id", "Category_Name", product.category_id);
                ViewBag.photo_id = new SelectList(db.Photos, "photo_id", "photos_path", product.photo_id);
                ViewBag.tag_id = new SelectList(db.Product_tags, "tag_id", "tag_name", product.tag_id);
                return View(product);
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }
           
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "product_id,title,product_name,product_price,category_id,availability,tag_id,photo_id,product_number,weight,dimensions,description,status")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category_id = new SelectList(db.Categories, "id", "Category_Name", product.category_id);
            ViewBag.photo_id = new SelectList(db.Photos, "photo_id", "photos_path", product.photo_id);
            ViewBag.tag_id = new SelectList(db.Product_tags, "tag_id", "tag_name", product.tag_id);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Aloged"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Product product = db.Products.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }
            
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
