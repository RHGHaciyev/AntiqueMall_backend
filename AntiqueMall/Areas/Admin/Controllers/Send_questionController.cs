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
    public class Send_questionController : Controller
    {
        private AnticDataEntities db = new AnticDataEntities();

        // GET: Admin/Send_question
        public ActionResult Index()
        {
            if (Session["Aloged"] != null)
            {
                return View(db.Send_question.ToList());
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }

            
        }

        // GET: Admin/Send_question/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Aloged"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Send_question send_question = db.Send_question.Find(id);
                if (send_question == null)
                {
                    return HttpNotFound();
                }
                return View(send_question);
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }
 
        }

        // GET: Admin/Send_question/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Send_question/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,question_title,text,name,email,message_text")] Send_question send_question)
        {
            if (ModelState.IsValid)
            {
                db.Send_question.Add(send_question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(send_question);
        }

        // GET: Admin/Send_question/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Send_question send_question = db.Send_question.Find(id);
            if (send_question == null)
            {
                return HttpNotFound();
            }
            return View(send_question);
        }

        // POST: Admin/Send_question/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,question_title,text,name,email,message_text")] Send_question send_question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(send_question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(send_question);
        }

        // GET: Admin/Send_question/Delete/5
        public ActionResult Delete(int? id)
        {

            if (Session["Aloged"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Send_question send_question = db.Send_question.Find(id);
                if (send_question == null)
                {
                    return HttpNotFound();
                }
                return View(send_question);
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }

            
        }

        // POST: Admin/Send_question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Send_question send_question = db.Send_question.Find(id);
            db.Send_question.Remove(send_question);
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
