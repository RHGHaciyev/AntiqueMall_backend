using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AntiqueMall.Models;
namespace AntiqueMall.Controllers
{
    public class PaintingController : Controller
    {
        private AnticDataEntities db = new AnticDataEntities();
        // GET: Painting
        public ActionResult painting()
        {
            ViewBag.categories = db.Categories.ToList();
            ViewBag.slide = db.fsecslides.ToList();
            ViewBag.paint = db.Products.OrderByDescending(a => a.select_id).ToList().Take(12);
            return View();
        }
    }
}