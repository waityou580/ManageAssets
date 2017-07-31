using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManageAssets.Models;

namespace ManageAssets.Controllers
{
    public class Sys_AccountController : Controller
    {
        AssetsManagerEntities db = new AssetsManagerEntities();
        // GET: Sys_Account
        public ActionResult Index()
        {
            return View();
        }
       
        // GET: Sys_Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sys_Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sys_Account/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sys_Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sys_Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sys_Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sys_Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
