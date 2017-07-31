using ManageAssets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageAssets.Controllers
{
    public class Sys_LoginController : Controller
    {
        AssetsManagerEntities db = new AssetsManagerEntities();
        // GET: Sys_Login
        public ActionResult Index()
        {
            return View();
        }
        // POST: Sys_Account/Login
        [HttpPost]
        public ActionResult Login(Sys_Account Account)
        {
            var user = db.Sys_Account.FirstOrDefault(p => p.Username == Account.Username && p.Password == Account.Password);
            if (user != null)
            {
                Session["UserAccount"] = user;
                return RedirectToAction("Index", "Payments"/*, new { area = "Sys_HomePage" }*/);
            }

            return RedirectToAction("Index", "Sys_Login");
        }
    }
}