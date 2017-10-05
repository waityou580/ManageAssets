using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ManageAssets.Models;

namespace ManageAssets.Controllers
{
    public class Sys_ActionController : Controller
    {
        AssetsManagerEntities db = new AssetsManagerEntities();
        // GET: Sys_Action
        public ActionResult Index(string id)
        {
            List<Sys_Action> lstAction = db.Sys_Action.Where(p => p.Controller_ID == id).ToList();

            return View(lstAction);
        }

        // GET: Sys_Action/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sys_Action/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sys_Action/Create
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

        // GET: Sys_Action/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Action lstAction = db.Sys_Action.Find(id);
            if (lstAction == null)
            {
                return HttpNotFound();
            }
            return View(lstAction);
        }

        // POST: Sys_Action/Edit/5
        [HttpPost]
        public ActionResult Edit(Sys_Action act)
        {
            if (ModelState.IsValid)
            {
                db.Entry(act).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("index","Sys_Action",new { id = act.Controller_ID});
            }
            return View();
        }

        // GET: Sys_Action/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sys_Action/Delete/5
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
