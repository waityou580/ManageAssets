﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManageAssets.Models;
using System.Net;
using Rotativa;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace ManageAssets.Controllers
{
    public class PaymentsController : Controller
    {
        private AssetsManagerEntities db = new AssetsManagerEntities();
        // GET: Payments
        public ActionResult Index()
        {
            List<PAYMENT> lst = db.PAYMENTS.ToList();
            return View(lst);
        }
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAYMENT lst = db.PAYMENTS.Find(id);
            if (lst == null)
            {
                return HttpNotFound();
            }
            return View(lst);
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult Create(PAYMENT pay)
        {
            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                db.PAYMENTS.Add(pay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Default/Edit/5
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

        // GET: Default/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Default/Delete/5
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
        public ActionResult ExportPdf1()
        {
            return new ActionAsPdf("Details")
            {
                FileName = Server.MapPath("~/Content/List.pdf")
            };
        }
        public ActionResult ExportPdf(string id)
        {
            List<PAYMENT> allCustomer = db.PAYMENTS.Where(p=>p.Payment_ID == id).ToList();

            //var query = (from i in db.PAYMENTS
            //             select new
            //             {
            //                 Content_VN = i.Content_CN ?? "a",
            //                 Content_CN = i.Content_VN ?? "No Value"
            //             }).ToList();

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "Payments.rpt"));

            rd.SetDataSource(allCustomer);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Payments.pdf");
        }

        public ActionResult ExportExcel(string id)
        {
            List<PAYMENT> allCustomer = db.PAYMENTS.Where(p=>p.Payment_ID == id).ToList();

            //var query = (from i in db.PAYMENTS
            //             select new
            //             {
            //                 Content_VN = i.Content_CN ?? "a",
            //                 Content_CN = i.Content_VN ?? "No Value"
            //             }).ToList();

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "Payments.rpt"));

            rd.SetDataSource(allCustomer);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/xls", "Payments.xls");
        }

    }
}