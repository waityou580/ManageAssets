using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ManageAssets.Helper;
using ManageAssets.Models;

namespace ManageAssets.Controllers
{
    public class Sys_ControllerController : Controller
    {
        AssetsManagerEntities db = new AssetsManagerEntities();
        // Update Controller
        public ActionResult UpdateController()
        {
            SaveReflectionController save = new SaveReflectionController();
            save.SaveReflection();
            return RedirectToAction("index");
        }
        // NotificationAuthozide
        public ActionResult NotificationAuthozide()
        {
            return View();
        }
        // GET: Sys_Controller
        public ActionResult Index()
        {
            List<Sys_Controller> lstController = db.Sys_Controller.ToList();
            return View(lstController);
        }

        // GET: Sys_Controller/Details/5
        public ActionResult Details(string id)
        {
            return RedirectToAction("Index","Sys_Action",new { id = id});
        }

        // GET: Sys_Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sys_Controller/Create
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

        // GET: Sys_Controller/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Controller lst = db.Sys_Controller.Find(id);
            if (lst == null)
            {
                return HttpNotFound();
            }
            return View(lst);
        }

        // POST: Sys_Controller/Edit/5
        [HttpPost]
        public ActionResult Edit(Sys_Controller ctr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ctr).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Sys_Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sys_Controller/Delete/5
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
