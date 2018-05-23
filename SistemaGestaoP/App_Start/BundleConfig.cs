using System.Web.Optimization;

namespace SistemaGestaoP
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jeditable").Include(
                        "~/Scripts/jquery.jeditable.mini.js"));
            // bundles.
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
"~/Scripts/bootstrap.js",
"~/Scripts/bootstrap.min.js",
"~/Scripts/Director/dashboard.js",
"~/Scripts/plugins/chart.js",
"~/Scripts/plugins/daterangepicker/daterangepicker.js",
"~/Scripts/plugins/fullcalendar/fullcalendar.js",
"~/Scripts/plugins/iCheck/icheck.min.js",
"~/Scripts/Director/app.js",
"~/Scripts/",
"~/Scripts/"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
"~/Content/bootstrap.css",
"~/Content/bootstrap.min.css",
"~/Content/easypiechart.css",
"~/Content/font-awesome.css",
"~/Content/font-awesome.min.css",
"~/Content/gmap.css",
"~/Content/ionicons.css",
"~/Content/ionicons.min.css",
"~/Content/jquery-ui.min.css",
"~/Content/jquery.ui.plupload.css",
"~/Content/Site.css",
"~/Content/style.css",
"~/Content/throbber.gif",
 "~/Content/datepicker/datepicker3.css",
 "~/Content/daterangepicker/daterangepicker-bs3.css",
 "~/Content/iCheck/all.css",
 "~/Content/jvectormap/jquery-jvectormap-1.2.2.css",
 "~/Content/morris/morris.css",
 "~/Content/iCheck/flat/_all.css",
 "~/Content/iCheck/futurico/futurico.css",
 "~/Content/iCheck/line/_all.css",
 "~/Content/iCheck/minimal/_all.css",
 "~/Content/iCheck/polaris/polaris.css",
 "~/Content/iCheck/square/_all.css",
 "~/Content/",
 "~/Content/",
 "~/Content/",
 "~/Content/",
 "~/Content/",
 "~/Content/",
 "~/Content/"
));

           BundleTable.EnableOptimizations = true;
        }
    }
}
