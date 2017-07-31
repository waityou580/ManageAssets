using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManageAssets.Models;
using System.Net;
using Rotativa;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Globalization;
using System.Data.Entity;

namespace ManageAssets.Controllers
{
    public class PaymentsController : Controller
    {
        private AssetsManagerEntities db = new AssetsManagerEntities();
        // GET: Payments
        public ActionResult Index()
        {
            var userAccount = (Sys_Account)Session["UserAccount"];
            if (userAccount == null)
            {
                return RedirectToAction("Index", "Sys_Login");
            }
            List<PAYMENT> lst;
            if (userAccount.GroupID == "admin")
            {
                lst = db.PAYMENTS.ToList();
                return View(lst);
            }
                lst = db.PAYMENTS.Where(p => p.Users_Create == userAccount.Username).ToList();
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
            var userAccount = (Sys_Account)Session["UserAccount"];
            if (userAccount == null)
            {
                return RedirectToAction("Index", "Sys_Login");
            }
            var date = DateTime.Today;
            var date1 = date.ToString("yyyy-MM-dd");
            string paymentID;
            try
            {
                var paymentDate = db.PAYMENTS.Where(p => p.Payment_Date.ToString() == date1).ToList();
                paymentID = paymentDate.Select(p=>p.Payment_ID).Last();
                paymentID = paymentID.Substring(9,3);
                paymentID = (int.Parse(paymentID) + 1).ToString();
                if(int.Parse(paymentID) < 10)
                {
                    paymentID = "00" + paymentID;
                }if(int.Parse(paymentID) < 100 && int.Parse(paymentID) >= 10)
                {
                    paymentID = "0" + paymentID;
                }
                paymentID = "PAY" + date.ToString("yyMMdd") + paymentID;
            }
            catch
            {
                paymentID = "PAY" + date.ToString("yyMMdd") + "001";
            }
            ViewBag.AutoCode = paymentID;
            // Department Code
            ViewBag.DeptList = new SelectList(db.DEPARTMENTs,"DEPT_ID","DEPT_NAME");
            //Supplier Code
            ViewBag.lstSupp = new SelectList(db.SUPPLIERs, "SUPPLIER_ID", "SUPPLIER_NAME");
            // Username
            ViewBag.userAccount = userAccount.Username;
            //Currency List
            List<SelectListItem> lstCur = new List<SelectListItem>();
            lstCur.Add(new SelectListItem { Text = "VND", Value = "VND" });
            lstCur.Add(new SelectListItem { Text = "USD", Value = "USD" });
            lstCur.Add(new SelectListItem { Text = "RMD", Value = "RMD" });
            ViewBag.lstCur = lstCur;
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
        public ActionResult Edit(String id)
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
            // Department Code
            ViewBag.DeptList = new SelectList(db.DEPARTMENTs, "DEPT_ID", "DEPT_NAME");
            //Supplier Code
            ViewBag.lstSupp = new SelectList(db.SUPPLIERs, "SUPPLIER_ID", "SUPPLIER_NAME");
            //Currency List
            List<SelectListItem> lstCur = new List<SelectListItem>();
            lstCur.Add(new SelectListItem { Text = "VND", Value = "VND" });
            lstCur.Add(new SelectListItem { Text = "USD", Value = "USD" });
            lstCur.Add(new SelectListItem { Text = "RMD", Value = "RMD" });
            ViewBag.lstCur = lstCur;
            return View(lst);
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Edit(PAYMENT pay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Default/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAYMENT PAY = db.PAYMENTS.Find(id);
            if (PAY == null)
            {
                return HttpNotFound();
            }
            return View(PAY);
        }

        // POST: Default/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                PAYMENT pay = db.PAYMENTS.Find(id);
                db.PAYMENTS.Remove(pay);
                db.SaveChanges();
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
            List<PAYMENT> payments = db.PAYMENTS.Where(p=>p.Payment_ID == id).ToList();

            var query = (from i in db.PAYMENTS
                         where i.Payment_ID == id
                         select new
                         {
                             Payment_Date = i.Payment_Date ?? DateTime.Now,
                             Department = i.DEPARTMENT.DEPT_NAME ?? "Ten bo phan",
                             Supplier_ID = i.SUPPLIER.SUPPLIER_NAME ?? "TEN NCC",
                             Invoice_Date = i.Invoice_Date ?? DateTime.Now,
                             Billing_period = i.Billing_period ?? DateTime.Now,
                             Paument_method = i.Payment_method ?? "Phuong Thuc Thanh Toan",
                             Units_used = i.Units_used ?? "Don vi su dung",
                             Title_VN =  i.Title_VN ?? "Tieu de VN",
                             Title_CN = i.Title_CN ?? "Tieu de CN",
                             Content_VN = i.Content_VN ?? "Noi dung VN",
                             Content_CN = i.Content_CN ?? "Noi dung CN",
                             Price = i.Price ?? 0,
                             VAT = i.VAT ?? 0,
                             Amount = i.Amount ?? 0,
                             Currency = i.Currency ?? "VND"
                         }
                         ).ToList();

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "Payments.rpt"));

            rd.SetDataSource(query);

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

            var query = (from i in db.PAYMENTS
                         where i.Payment_ID == id
                         select new
                         {
                             Payment_Date = i.Payment_Date ?? DateTime.Now,
                             Department = i.DEPARTMENT.DEPT_NAME ?? "Ten bo phan",
                             Supplier_ID = i.SUPPLIER.SUPPLIER_NAME ?? "TEN NCC",
                             Invoice_Date = i.Invoice_Date ?? DateTime.Now,
                             Billing_period = i.Billing_period ?? DateTime.Now,
                             Paument_method = i.Payment_method ?? "Phuong Thuc Thanh Toan",
                             Units_used = i.Units_used ?? "Don vi su dung",
                             Title_VN = i.Title_VN ?? "Tieu de VN",
                             Title_CN = i.Title_CN ?? "Tieu de CN",
                             Content_VN = i.Content_VN ?? "Noi dung VN",
                             Content_CN = i.Content_CN ?? "Noi dung CN",
                             Price = i.Price ?? 0,
                             VAT = i.VAT ?? 0,
                             Amount = i.Amount ?? 0,
                             Currency = i.Currency ?? "VND"
                         }
                         ).ToList();

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "Payments.rpt"));

            rd.SetDataSource(query);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/xls", "Payments.xls");
        }

    }
}