using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AntiqueMall.Models;
namespace AntiqueMall.Controllers
{
    public class AccountController : Controller
    {
        AnticDataEntities db = new AnticDataEntities();
        // GET: Account
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(user newUser)
        {
            if (newUser.name != "" && newUser.email != "")
            {

            }
            ViewBag.RegError = "Please,fill all the field";
            return View();
        }
    }
}