using System.Web;
using System.Web.Optimization;

namespace CreownTutor
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        //public static void RegisterBundles(BundleCollection bundles)
        //{
        //    bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
        //                "~/Scripts/jquery-{version}.js"));

        //    bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
        //                "~/Scripts/jquery.validate*"));

        //    // Use the development version of Modernizr to develop with and learn from. Then, when you're
        //    // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
        //    bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
        //                "~/Scripts/modernizr-*"));

        //    bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
        //              "~/Scripts/bootstrap.js",
        //              "~/Scripts/respond.js"));

        //    bundles.Add(new StyleBundle("~/Content/css").Include(
        //              "~/Content/bootstrap.css",
        //              "~/Content/site.css"));
        //}

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/js/jquery-2.2.4.min.js",
                        "~/js/jquery-ui.min.js",
                        "~/js/bootstrap.min.js",
                        "~/js/jquery-plugin-collection.js"

                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/js/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));



            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/css/bootstrap.min.css",
                      "~/css/jquery-ui.min.css",
                      "~/css/animate.css",
                      "~/css/css-plugin-collections.css",
                      "~/css/menuzord-skins/menuzord-rounded-boxed.css",
                      "~/css/style-main.css",
                      "~/css/preloader.css",
                      "~/css/custom-bootstrap-margin-padding.css",
                      "~/css/responsive.css",
                      "~/css/colors/theme-skin-color-set-1.css"
                      ));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryui")
            //     .Include("~/Scripts/jquery-ui-{version}.js"));

            //bundles.Add(new StyleBundle("~/Content/jqueryui")
            //   .Include("~/Content/themes/base/all.css"));
        }
    }
}
