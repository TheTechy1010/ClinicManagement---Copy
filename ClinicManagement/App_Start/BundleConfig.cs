using System.Web;
using System.Web.Optimization;

namespace ClinicManagement
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.bundle.min.js",
                      "~/Scripts/bs-select/bootstrap-select.js",
                      "~/Scripts/DataTables/jquery.dataTables.js",
                      "~/Scripts/DataTables/dataTables.bootstrap4.js",
                      "~/Scripts/bootstrap-datepicker.min.js",
                      "~/Content/ClockPicker/jquery-clockpicker.min.js",
                      "~/Content/ClockPicker/bootstrap-clockpicker.min.js",
                      "~/Scripts/toastr.min.js",
                      "~/Scripts/toastrConfig.js",
                      "~/Scripts/bootbox.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-cosmo.css",
                      "~/Content/PagedList.css",
                      "~/Content/bs-select/bootstrap-select.css",
                      "~/Content/DataTables/css/jquery.dataTables.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.css",
                      "~/Content/DataTables/css/dataTables.bootstrap4.css",
                      "~/Content/bootstrap-datepicker.min.css",
                      "~/Content/ClockPicker/jquery-clockpicker.min.css",
                      "~/Content/ClockPicker/bootstrap-clockpicker.min.css",
                      "~/Content/toastr.css",
                      "~/Content/site.css"));
            
        }
    }
}
