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
    public class Most_given_questionsController : Controller
    {
        private AnticDataEntities db = new AnticDataEntities();

        // GET: Admin/Most_given_questions
        public ActionResult Index()
        {
            if (Session["Aloged"] != null)
            {
                return View(db.Most_given_questions.ToList());
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }
  
        }

        // GET: Admin/Most_given_questions/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Aloged"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Most_given_questions most_given_questions = db.Most_given_questions.Find(id);
                if (most_given_questions == null)
                {
                    return HttpNotFound();
                }
                return View(most_given_questions);
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }
   
        }

        // GET: Admin/Most_given_questions/Create
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

        // POST: Admin/Most_given_questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,question,answer")] Most_given_questions most_given_questions)
        {
            if (ModelState.IsValid)
            {
                db.Most_given_questions.Add(most_given_questions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(most_given_questions);
        }

        // GET: Admin/Most_given_questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Aloged"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Most_given_questions most_given_questions = db.Most_given_questions.Find(id);
                if (most_given_questions == null)
                {
                    return HttpNotFound();
                }
                return View(most_given_questions);
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }    
        }

        // POST: Admin/Most_given_questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,question,answer")] Most_given_questions most_given_questions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(most_given_questions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(most_given_questions);
        }

        // GET: Admin/Most_given_questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Aloged"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Most_given_questions most_given_questions = db.Most_given_questions.Find(id);
                if (most_given_questions == null)
                {
                    return HttpNotFound();
                }
                return View(most_given_questions);
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }   
        }

        // POST: Admin/Most_given_questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Most_given_questions most_given_questions = db.Most_given_questions.Find(id);
            db.Most_given_questions.Remove(most_given_questions);
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
