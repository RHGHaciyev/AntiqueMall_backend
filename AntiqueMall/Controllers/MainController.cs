using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AntiqueMall.Models;
using System.Net;
using System.Data.Entity;

namespace AntiqueMall.Controllers
{
    public class MainController : Controller
    {
        private AnticDataEntities db = new AnticDataEntities();
        // GET: Main
        public ActionResult CheckLog(string use,string pass)
        {   

            var linq = db.users.Where(m => m.password == pass && m.name == use).FirstOrDefault();
            if (linq != null)
            {
                Session["loged"] = true;
                Session["username"] = use;
                return JavaScript("window.location = 'http://localhost:51618/Main/UserPage'");
            }
            else
            {
                return Content("All Fields are required");
            }
        }
        public ActionResult outlog()
        {
            Session["loged"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Home1(string prod)
        {
            int a = Convert.ToInt32(prod);
            Product list = db.Products.Where(n => n.product_id == a).FirstOrDefault();
            return PartialView("ProductPartial",list);
        }
        public ActionResult view(string prod)
        {
            ViewBag.product = db.Products.OrderByDescending(c => c.product_type).Distinct().ToList().Take(5);
            int a = Convert.ToInt32(prod);
            Product list = db.Products.Where(n => n.product_id == a).FirstOrDefault();
            return PartialView("QuickView", list);
        }
        public ActionResult itemAdd(string prod)
        {
            int a = Convert.ToInt32(prod);
            Product list = db.Products.Where(n => n.product_id == a).FirstOrDefault();
            return PartialView("itemPartial", list);
        }

        public ActionResult itemAddView(string prod)
        {
            int a = Convert.ToInt32(prod);
            Product list = db.Products.Where(n => n.product_id == a).FirstOrDefault();
            return PartialView("ViewCart", list);
        }
        public ActionResult Home()
        {
            ViewBag.slider = db.Sliders.ToList();
            ViewBag.bottext = db.BotTexts.ToList();
            ViewBag.productTags = db.Product_tags.ToList();
            ViewBag.allproduct = db.Products.Where(c => c.tag_id == 4).OrderByDescending(c => c.tag_id).ToList().Take(8);
            ViewBag.vaseproduct = db.Products.Where(c => c.tag_id == 5).OrderByDescending(c => c.tag_id).ToList().Take(8);
            ViewBag.clockproduct = db.Products.Where(c => c.tag_id == 6).OrderByDescending(c => c.tag_id).ToList().Take(8);
            ViewBag.tablewareproduct = db.Products.Where(c => c.tag_id == 7).OrderByDescending(c => c.tag_id).ToList().Take(8);
            ViewBag.paintingsproduct = db.Products.Where(c => c.tag_id == 8).OrderByDescending(c => c.tag_id).ToList().Take(8);
            ViewBag.information = db.information.Find(1);
            ViewBag.info = db.information.ToList();
            ViewBag.secallproduct = db.Products.Where(c => c.tag_id == 4).OrderByDescending(c => c.tag_id).ToList().Skip(8).Take(8);
            ViewBag.secvaseproduct = db.Products.Where(c => c.tag_id == 5).OrderByDescending(c => c.tag_id).ToList().Skip(8);
            ViewBag.secclockproduct = db.Products.Where(c => c.tag_id == 6).OrderByDescending(c => c.tag_id).ToList().Skip(8);
            ViewBag.sectablewareproduct = db.Products.Where(c => c.tag_id == 7).OrderByDescending(c => c.tag_id).ToList().Skip(8);
            ViewBag.secpaintingsproduct = db.Products.Where(c => c.tag_id == 8).OrderByDescending(c => c.tag_id).ToList().Skip(8);
            ViewBag.banner = (from d in db.Photos select d).ToList().Skip(33).Take(2);
            ViewBag.sbanner = (from d in db.Photos select d).ToList().Skip(35).Take(2);
            ViewBag.photos = (from d in db.Photos select d).ToList().Skip(37).Take(4);
            ViewBag.fblog = db.Blogs.Where(c => c.id == 1).ToList();
            ViewBag.blog = db.Blogs.Where(c => c.id == 2).ToList();
            ViewBag.logo = (from d in db.Photos select d).ToList().Skip(48).Take(6);
            return View();
        }
        public ActionResult Painting()
        {
            ViewBag.lefts=db.Products.OrderByDescending(a => a.leftselectId).ToList().Take(5);
            ViewBag.categories = db.Categories.ToList();
            ViewBag.slide = db.fsecslides.ToList().Take(1);
            ViewBag.paint = db.Products.OrderByDescending(a => a.select_id).ToList().Take(12);
            ViewBag.tags = db.Product_tags.ToList();
            
            ViewBag.productr = db.Products.ToList().Take(1);
            return View();        
        }
        public ActionResult Painting2()
        {
            ViewBag.lefts = db.Products.OrderByDescending(a => a.leftselectId).ToList().Take(5);
            ViewBag.categories = db.Categories.ToList();
            ViewBag.slide = db.fsecslides.ToList().Skip(1).Take(1);
            ViewBag.paint2 = db.Products.OrderByDescending(a => a.select_id).ToList().Skip(12).Take(8);
            return View();
        }
        public ActionResult Clock()
        {
            ViewBag.categories = db.Categories.ToList();
            ViewBag.clock = db.Products.OrderByDescending(a => a.select_clock_id).ToList().Skip(5).Take(12);
            ViewBag.slide = db.fsecslides.ToList().Skip(2).Take(1);
            ViewBag.lefts = db.Products.OrderByDescending(a => a.leftselectId).ToList().Take(5);
            return View();
        }
        public ActionResult Clock2()
        {
            ViewBag.categories = db.Categories.ToList();
            ViewBag.clock2 = db.Products.OrderByDescending(a => a.select_clock_id).ToList().Take(5);
            ViewBag.slide = db.fsecslides.ToList().Skip(5).Take(1);
            ViewBag.lefts = db.Products.OrderByDescending(a => a.leftselectId).ToList().Take(5);
            return View();
        }
        public ActionResult Tableware()
        {
            ViewBag.tableware = db.Products.OrderByDescending(a => a.selectTableware_id).ToList().Take(12);
            ViewBag.categories = db.Categories.ToList();
            ViewBag.slide = db.fsecslides.ToList().Skip(3).Take(1);
            ViewBag.lefts = db.Products.OrderByDescending(a => a.leftselectId).ToList().Take(5);
            return View();
        }
        public ActionResult Tableware2()
        {
            ViewBag.tableware2 = db.Products.OrderByDescending(a => a.selectTableware_id).ToList().Skip(12).Take(4);
            ViewBag.categories = db.Categories.ToList();
            ViewBag.slide = db.fsecslides.ToList().Skip(6).Take(1);
            ViewBag.lefts = db.Products.OrderByDescending(a => a.leftselectId).ToList().Take(5);
            return View();
        }
        public ActionResult Vase()
        {
            ViewBag.slide = db.fsecslides.ToList().Skip(4).Take(1);
            ViewBag.vase = db.Products.OrderByDescending(a => a.select_vase_id).ToList().Take(12);
            ViewBag.categories = db.Categories.ToList();
            ViewBag.lefts = db.Products.OrderByDescending(a => a.leftselectId).ToList().Take(5);
            return View();
        }
        public ActionResult Vase2()
        {
            ViewBag.slide = db.fsecslides.ToList().Skip(4).Take(1);
            ViewBag.vase2 = db.Products.OrderByDescending(a => a.select_vase_id).ToList().Skip(12).Take(2);
            ViewBag.categories = db.Categories.ToList();
            ViewBag.lefts = db.Products.OrderByDescending(a => a.leftselectId).ToList().Take(5);
            return View();
        }
        public ActionResult Shop()
        {
            ViewBag.slide = db.fsecslides.ToList().Skip(7).Take(1);
            ViewBag.shop = db.Products.OrderByDescending(a => a.select_shop_id).ToList().Take(12);
            ViewBag.categories = db.Categories.ToList();
            ViewBag.lefts = db.Products.OrderByDescending(a => a.leftselectId).ToList().Take(5);
            return View();
        }
        public ActionResult Shop2()
        {
            ViewBag.slide = db.fsecslides.ToList().Skip(8).Take(1);
            ViewBag.shop2 = db.Products.OrderByDescending(a => a.select_shop_id).ToList().Skip(12).Take(12);
            ViewBag.categories = db.Categories.ToList();
            ViewBag.lefts = db.Products.OrderByDescending(a => a.leftselectId).ToList().Take(5);
            return View();
        }
        public ActionResult Shop3()
        {
            ViewBag.slide = db.fsecslides.ToList().Skip(9).Take(1);
            ViewBag.shop3 = db.Products.OrderByDescending(a => a.select_shop_id).ToList().Skip(24).Take(5);
            ViewBag.categories = db.Categories.ToList();
            ViewBag.lefts = db.Products.OrderByDescending(a => a.leftselectId).ToList().Take(5);
            return View();
        }
        public ActionResult Testimonial()
        {
            ViewBag.slide = db.fsecslides.ToList().Skip(10).Take(1);
            ViewBag.users = db.users.ToList().Take(2);
            ViewBag.users1 = db.users.ToList().Skip(2).Take(2);
            ViewBag.users2 = db.users.ToList().Skip(4).Take(2);
            ViewBag.users3 = db.users.ToList().Skip(6).Take(2);
            ViewBag.users4 = db.users.ToList().Skip(8).Take(1);
            return View();
        }
        public ActionResult Testimonial2()
        {
            ViewBag.slide = db.fsecslides.ToList().Skip(11).Take(1);
            ViewBag.users = db.users.ToList().Take(3);
            ViewBag.users1 = db.users.ToList().Skip(3).Take(3);
            ViewBag.users2 = db.users.ToList().Skip(6).Take(3);
            return View();
        }
        public ActionResult FAQ1()
        {
            ViewBag.slide = db.fsecslides.ToList().Skip(12).Take(1);
            ViewBag.question = db.Most_given_questions.ToList();
            ViewBag.questionf = db.Most_given_questions.ToList().Take(1);
            return View();
        }
        public ActionResult FAQ2()
        {
            ViewBag.slide = db.fsecslides.ToList().Skip(13).Take(1);
            ViewBag.question = db.Most_given_questions.OrderByDescending(a=>a.id).ToList();
            ViewBag.questionf = db.Most_given_questions.ToList().Take(1);
            return View();
        }
        public ActionResult Categories()
        {
            ViewBag.product = db.Products.OrderByDescending(a => a.product_id).ToList().Distinct().Take(5);
            ViewBag.productr = db.Products.ToList().Take(1);
            ViewBag.desc = db.Descriptions.ToList();
            ViewBag.desctext = db.Descriptions.ToList();
            ViewBag.slide = db.fsecslides.ToList().Skip(14).Take(1);
         
            return View();
        }
        public ActionResult Blog()
        {
            ViewBag.slide = db.fsecslides.ToList().Skip(15).Take(1);
            ViewBag.blog = db.Blogs.OrderBy(a => a.id).ToList();
            return View();
        }
        public ActionResult UserPage()
        {
            return View();
        }
        public ActionResult UserOrders()
        {
            return View();
        }
        public ActionResult UserDownloads()
        {
            return View();
        }
        public ActionResult UserAdress()
        {
            return View();
        }
        public ActionResult BillingAdressEdit()
        {
            return View();
        }
        public ActionResult Aboutus()
        {
            ViewBag.aboutfin = db.Aboutfs.ToList().Take(1);
            ViewBag.about = db.Aboutfs.ToList().Take(2);
            ViewBag.aboutsec = db.Aboutfs.ToList().Skip(2).Take(2);
            ViewBag.teamt = db.Teams.ToList().Take(1);
            ViewBag.teampers = db.Teams.ToList();
            ViewBag.fblog = db.Blogs.Where(c => c.id == 1).ToList();
            ViewBag.blog = db.Blogs.Where(c => c.id == 2).ToList();
            return View();
        }
        public ActionResult BlogView()
        {
            ViewBag.BlogView = db.Blogs.ToList().Take(1);
            return View();
        }
        public ActionResult BlogView13()
        {
            ViewBag.BlogView = db.Blogs.ToList().Skip(1).Take(1);
            return View();
        }
        public ActionResult BlogView15()
        {
            ViewBag.BlogView = db.Blogs.ToList().Skip(2).Take(1);
            return View();
        }
        public ActionResult HelloWorld()
        {
            return View();
        }
        public ActionResult viewCart()
        {
            ViewBag.product = db.Products.OrderByDescending(a => a.product_id).ToList().Distinct();
            
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.lefts = db.Products.OrderByDescending(a => a.leftselectId).ToList().Take(5);
            return View();
        }
    }
}