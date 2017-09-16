using System.Web;
using System.Web.Optimization;

namespace ManageAssets
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/datePicker").Include(
           "~/Scripts/moment.min.js",
           "~/Scripts/bootstrap-datetimepicker.min.js"));

            bundles.Add(new StyleBundle("~/Content/datepicker").Include(
                     "~/Content/bootstrap-datetimepicker.min.css"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css",
                      "~/Content/Style.css"));
            bundles.Add(new ScriptBundle("~/vendors/js").Include(
                        //<!-- jQuery -->
                        "~/vendors/jquery/dist/jquery.min.js",
                        //<!-- Bootstrap -->
                        "~/vendors/bootstrap/dist/js/bootstrap.min.js",
                        //<!-- FastClick -->
                        "~/vendors/fastclick/lib/fastclick.js",
                        //<!-- NProgress -->
                        "~/vendors/nprogress/nprogress.js",
                        //<!-- Chart.js -->
                        "~/vendors/Chart.js/dist/Chart.min.js",
                        //<!-- gauge.js -->
                        "~/vendors/gauge.js/dist/gauge.min.js",
                        //<!-- bootstrap-progressbar -->
                        "~/vendors/bootstrap-progressbar/bootstrap-progressbar.min.js",
                        //<!-- iCheck -->
                        "~/vendors/iCheck/icheck.min.js",
                        //<!-- Skycons -->
                        "~/vendors/skycons/skycons.js",
                        //<!-- Flot -->
                        "~/vendors/Flot/jquery.flot.js",
                        "~/vendors/Flot/jquery.flot.pie.js",
                        "~/vendors/Flot/jquery.flot.time.js",
                        "~/vendors/Flot/jquery.flot.stack.js",
                        "~/vendors/Flot/jquery.flot.resize.js",
                        //<!-- Flot plugins -->
                        "~/vendors/flot.orderbars/js/jquery.flot.orderBars.js",
                        "~/vendors/flot-spline/js/jquery.flot.spline.min.js",
                        "~/vendors/flot.curvedlines/curvedLines.js",
                        //<!-- DateJS -->
                        "~/vendors/DateJS/build/date.js",
                        //<!-- JQVMap -->
                        "~/vendors/jqvmap/dist/jquery.vmap.js",
                        "~/vendors/jqvmap/dist/maps/jquery.vmap.world.js",
                        "~/vendors/jqvmap/examples/js/jquery.vmap.sampledata.js",
                        //<!-- bootstrap-daterangepicker -->
                        "~/vendors/moment/min/moment.min.js",
                        "~/vendors/bootstrap-daterangepicker/daterangepicker.js",
                        //<!-- Datatables -->
                        "~/vendors/datatables.net/js/jquery.dataTables.min.js",
                        "~/vendors/datatables.net-bs/js/dataTables.bootstrap.min.js",
                        "~/vendors/datatables.net-buttons/js/dataTables.buttons.min.js",
                        "~/vendors/datatables.net-buttons-bs/js/buttons.bootstrap.min.js",
                        "~/vendors/datatables.net-buttons/js/buttons.flash.min.js",
                        "~/vendors/datatables.net-buttons/js/buttons.html5.min.js",
                        "~/vendors/datatables.net-buttons/js/buttons.print.min.js",
                        "~/vendors/datatables.net-fixedheader/js/dataTables.fixedHeader.min.js",
                        "~/vendors/datatables.net-keytable/js/dataTables.keyTable.min.js",
                        "~/vendors/datatables.net-responsive/js/dataTables.responsive.min.js",
                        "~/vendors/datatables.net-responsive-bs/js/responsive.bootstrap.js",
                        "~/vendors/datatables.net-scroller/js/dataTables.scroller.min.js",
                        "~/vendors/jszip/dist/jszip.min.js",
                        "~/vendors/pdfmake/build/pdfmake.min.js",
                        "~/vendors/pdfmake/build/vfs_fonts.js",
                        //<!-- Custom Theme Scripts -->
                        "~/build/js/custom.min.js"));


            bundles.Add(new StyleBundle("~/vendors/css").Include(
                "~/vendors/bootstrap/dist/css/bootstrap.min.css",
                "~/vendors/font-awesome/css/font-awesome.min.css",
                "~/vendors/nprogress/nprogress.css",
                "~/vendors/iCheck/skins/flat/green.css",
                "~/vendors/select2/dist/css/select2.min.css",
                "~/vendors/switchery/dist/switchery.min.css",
                "~/vendors/starrr/dist/starrr.css",
                "~/vendors/datatables.net-bs/css/dataTables.bootstrap.min.css",
                "~/vendors/datatables.net-buttons-bs/css/buttons.bootstrap.min.css",
                "~/vendors/datatables.net-fixedheader-bs/css/fixedHeader.bootstrap.min.css",
                "~/vendors/datatables.net-responsive-bs/css/responsive.bootstrap.min.css",
                "~/vendors/datatables.net-scroller-bs/css/scroller.bootstrap.min.css",
                "~/build/css/custom.min.css"));
        }
    }
}
