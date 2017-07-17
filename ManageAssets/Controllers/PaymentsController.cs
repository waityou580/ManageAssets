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
        public ActionResult ExportPdf()
        {
            return new ActionAsPdf("Details")
            {
                FileName = Server.MapPath("~/Content/List.pdf")
            };
        }
        public ActionResult ExportCustomers()
        {
            List<PAYMENT> allCustomer = db.PAYMENTS.ToList();

            var query = (from i in db.PAYMENTS
                         select new
                         {
                             Content_VN = i.Content_CN ?? "a",
                             Content_CN = i.Content_VN ?? "No Value"
                         }).ToList();

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "Payments.rpt"));

            rd.SetDataSource(allCustomer);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "CustomerList.pdf");
        }


    }
}