using ManageAssets.Helper;
using ManageAssets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageAssets.Controllers
{
    //[AuthorizeController]
    public class Sys_LoginController : BaseController
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
                List<string> lst = (from a in db.Sys_Account
                          join b in db.Sys_AccountPermission on a.Username equals b.Username
                          join c in db.Sys_GroupPermisionDetail on b.GroupID equals c.GroupID
                          where a.Username == user.Username
                          select(c.Action_ID)).ToList();

                Session["UserAuthorize"] = lst;

                Session["UserAccount"] = user;
                return RedirectToAction("Index", "Home"/*, new { area = "Sys_HomePage" }*/);
            }

            return RedirectToAction("Index", "Sys_Login");
        }
        public ActionResult LogOut(string id)
        {
            return RedirectToAction("Index");
        }
        //
        public ActionResult SetLanguage(string language)
        {
            // Validate input
            language = CultureHelper.GetImplementedCulture(language);

            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = language;   // update cookie value
            else
            {

                cookie = new HttpCookie("_culture");
                cookie.Value = language;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);

            //var t = Request.Url.AbsoluteUri;

            return RedirectToAction("Index"); 
        }

    }
}