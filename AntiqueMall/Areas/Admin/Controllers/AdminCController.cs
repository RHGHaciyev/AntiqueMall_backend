using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AntiqueMall.Areas.Admin.Controllers
{
    public class AdminCController : Controller
    {
        // GET: Admin/AdminC
        public ActionResult Index()
        {
            if(Session["Aloged"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "AdminAccount");
            }
        }
    }
}