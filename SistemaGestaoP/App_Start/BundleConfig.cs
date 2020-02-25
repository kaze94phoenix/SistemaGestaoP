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

            bundles.Add(new ScriptBundle("~/bundles/select2").Include(
                        "~/Scripts/select2.min.js"));
            bundles.Add(new StyleBundle("~/bundles/select2css").Include(
                        "~/Content/select2.min.css"));
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
"~/Scripts/Chart.min.js",
"~/Scripts/daterangepicker.js",
"~/Scripts/jekyll-search.min.js",
"~/Scripts/jquery.slimscroll.js",
"~/Scripts/jquery.slimscroll.min.js",
"~/Scripts/jquery-jvectormap-2.0.3.min.js",
"~/Scripts/jquery-jvectormap-world-mill.js",
"~/Scripts/jquery-migrate-1.4.1.min.js",
"~/Scripts/jquery-ui-1.12.1.min.js",
"~/Scripts/moment.min.js",
"~/Scripts/sleek.bundle.js",
"~/Scripts/toastr.min.js",
"~/Scripts/nprogress.js",
"~/Scripts/bootstrap.bundle.js",
"~/Scripts/bootstrap.bundle.min.js",
"~/Scripts/bootstrap.js",
"~/Scripts/bootstrap.min.js",
"~/Scripts/popper.min.js",
"~/Scripts/tether.min",
"~/Scripts/",
"~/Scripts/",
"~/Scripts/",
"~/Scripts/",
"~/Scripts/",
"~/Scripts/",
"~/Scripts/",
"~/Scripts/"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
 "~/Content/daterangepicker.css",
 "~/Content/jquery-jvectormap-2.0.3.css",
 "~/Content/jquery-ui-1.12.1.css",
 "~/Content/nprogress.css",
 "~/Content/sleek.css",
 "~/Content/sleek.min.css",
 "~/Content/sleek.css.map",
 "~/Content/sleek.min.rtl.css",
 "~/Content/styles.css",
 "~/Content/toastr.css",
 "~/Content/toastr.min.css",
 "~/Content/bootstrap.css",
 "~/Content/bootstrap.min.css",
 "~/Content/bootstrap-grid.css",
 "~/Content/bootstrap-grid.min.css",
 "~/Content/bootstrap-reboot.css",
 "~/Content/bootstrap-reboot.min.css",
 "~/Content/",
 "~/Content/",
 "~/Content/",
 "~/Content/",
 "~/Content/",
 "~/Content/",
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
