using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using AntiqueMall.Models;
namespace AntiqueMall.Areas.Admin.Controllers
{
    public class AdminAccountController : Controller
    {
        AnticDataEntities db = new AnticDataEntities();
        // GET: Admin/AdminAccount
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string name,string password)
        {
          
            if(name != " " && password !=" ")
            {
                
                Adminsp cr = db.Adminsps.Find(2);
            if (cr.name==name && cr.password==password)
                {
                    Session["Aloged"] = true;
                    Session["Adminname"] =cr.name;
                    return RedirectToAction("Index", "AdminC");
                }
                else
                {
                    ViewBag.AdlogError = "Incorrect Password or Email !";
                }
            }
            else
            {
             
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["Aloged"] = null;
            return RedirectToAction("Login", "AdminAccount");
        }
    }
}