using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManageAssets.Models;

namespace ManageAssets.Helper
{
    public class AuthorizeController : ActionFilterAttribute
    {
        AssetsManagerEntities db = new AssetsManagerEntities();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            List<string> lstAuthorize = (List<string>)filterContext.HttpContext.Session["UserAuthorize"];
            //string[] listPermission = { "Payments-Index", "Payments-Create", "Sys_Login-Index", "Sys_Login-Login" };
            string actionName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "-"
                + filterContext.ActionDescriptor.ActionName;
            if(lstAuthorize == null || lstAuthorize.Count == 0)
            {
                filterContext.Result = new RedirectResult("~/Sys_Controller/NotificationAuthozide");
            }else if (!lstAuthorize.Contains(actionName))
            {
                filterContext.Result = new RedirectResult("~/Sys_Controller/NotificationAuthozide");
            }
        }
    }
}