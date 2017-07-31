using ManageAssets.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageAssets.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UpdateController()
        {
            SaveReflectionController save = new SaveReflectionController();
            save.SaveReflection();
            return RedirectToAction("ListController");
        }
    }
}