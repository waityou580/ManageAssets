using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ManageAssets.Models;

namespace ManageAssets.Controllers
{
    public class Sys_GroupPermissionController : BaseController
    {
        AssetsManagerEntities db = new AssetsManagerEntities();
        // GET: Sys_GroupPermission
        public ActionResult Index()
        {
            List<Sys_GroupPermision> lstAccountPermission = db.Sys_GroupPermision.ToList();
            return View(lstAccountPermission);
        }

        // GET: Sys_GroupPermission/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sys_GroupPermission/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sys_GroupPermission/Create
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
    
        //GET: View had Permission in Sys_GroupPermission
        public ActionResult Partial_ViewPermission(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Sys_GroupPermisionDetail> lstGroupPermission = db.Sys_GroupPermisionDetail.Where(p => p.GroupID == id).OrderBy(p=>p.Action_ID).ToList();

            return PartialView(lstGroupPermission);
        }

        //GET: Get All Sys_Action
        public ActionResult Partial_ViewAllAction(string GroupId)
        {
            ViewBag.GroupId = GroupId;
            List<Sys_Action> lstAction = db.Sys_Action.Where(a => !db.Sys_GroupPermisionDetail.Select(m => m.Action_ID).Contains(a.Action_ID)).OrderBy(p=>p.Action_ID).ToList();
            return PartialView(lstAction);
        }

        //GET: Add Action to GroupPermission
        public ActionResult AddAction_to_GroupPermission(string id, string GroupID)
        {
            Sys_GroupPermisionDetail groupPermission = new Sys_GroupPermisionDetail();
            groupPermission.GroupID = GroupID;
            groupPermission.Action_ID = id;
            db.Sys_GroupPermisionDetail.Add(groupPermission);
            db.SaveChanges();

            // Update Session Authorize
            Sys_Account user = (Sys_Account)Session["UserAccount"]; 
            List<string> lst = (from a in db.Sys_Account
                                join b in db.Sys_AccountPermission on a.Username equals b.Username
                                join c in db.Sys_GroupPermisionDetail on b.GroupID equals c.GroupID
                                where a.Username == user.Username
                                select (c.Action_ID)).ToList();
            Session["UserAuthorize"] = lst;

            return RedirectToAction("Edit", new { id = GroupID });
        }

        //GET: Remove Action GroupPermission
        public ActionResult Remove_GroupPermission(int id, string groupId)
        {
            Sys_GroupPermisionDetail detail = db.Sys_GroupPermisionDetail.Find(id);
            db.Sys_GroupPermisionDetail.Remove(detail);
            db.SaveChanges();

            // Update Session Authorize
            Sys_Account user = (Sys_Account)Session["UserAccount"];
            List<string> lst = (from a in db.Sys_Account
                                join b in db.Sys_AccountPermission on a.Username equals b.Username
                                join c in db.Sys_GroupPermisionDetail on b.GroupID equals c.GroupID
                                where a.Username == user.Username
                                select (c.Action_ID)).ToList();
            Session["UserAuthorize"] = lst;

            return RedirectToAction("Edit", new { id = groupId });
        }
        // GET: Sys_GroupPermission/Edit/5
        public ActionResult Edit(string id)
        {
            ViewBag.GroupId = id;
            return View();
        }

        // POST: Sys_GroupPermission/Edit/5
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

        // GET: Sys_GroupPermission/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sys_GroupPermission/Delete/5
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
