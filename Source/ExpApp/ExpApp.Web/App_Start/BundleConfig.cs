using System.Web;
using System.Web.Optimization;

namespace ExpApp.Web
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.11.0.js"));//{version}
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                 "~/Scripts/bootstrap/js/bootstrap.js"));
      

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/Content/bootstrap/css/bootstrap.css",
                "~/Content/bootstrap/css/bootstrap-responsive.css"

                ));
            /*****************************************************************************/
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*",
                "~/Scripts/jquery.unobtrusive*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                "~/Scripts/jquery-ui-{version}.js",
                "~/Scripts/jquery-ui-zh.js"
                ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));


            //---Admin Site---

            //-----CSS-----
            bundles.Add(new StyleBundle("~/bundles/css/bootstrap2").Include(
                      "~/Content/admin/css/bootstrap.min.css",
                      "~/Content/admin/css/bootstrap-responsive.min.css"));

            bundles.Add(new StyleBundle("~/bundles/css/admin").Include(
                      "~/Content/admin/css/uniform.css",
                      "~/Content/admin/css/select2.css",
                      "~/Content/admin/css/matrix-style.css",
                      "~/Content/admin/css/matrix-media.css",
                      "~/Content/admin/css/font.css",
                      "~/Content/admin/font-awesome/css/font-awesome.css"
                      ));

            bundles.Add(new StyleBundle("~/bundles/css/jqueryui").Include(
                      "~/Content/themes/base/jquery.ui.core.css",
                //"~/Content/themes/base/jquery.ui.resizable.css",
                //"~/Content/themes/base/jquery.ui.selectable.css",
                //"~/Content/themes/base/jquery.ui.accordion.css",
                      "~/Content/themes/base/jquery.ui.autocomplete.css",
                //"~/Content/themes/base/jquery.ui.button.css",
                //"~/Content/themes/base/jquery.ui.dialog.css",
                //"~/Content/themes/base/jquery.ui.slider.css",
                //"~/Content/themes/base/jquery.ui.tabs.css",
                      "~/Content/themes/base/jquery.ui.datepicker.css",
                //"~/Content/themes/base/jquery.ui.progressbar.css",
                      "~/Content/themes/base/jquery.ui.theme.css"
                      ));

            //-----JS-----
            bundles.Add(new ScriptBundle("~/bundles/js/admin-jq").Include(
                     "~/Content/admin/js/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/bootstrap2").Include(
                     "~/Content/admin/js/bootstrap.min.js",
                     "~/Content/admin/js/bootbox.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/jqdataTables").Include(
                      "~/Content/admin/js/jquery.dataTables.min.js",
                      "~/Content/admin/js/jquery.dataTables.AjaxSource.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/admin-plugin").Include(
                      "~/Content/admin/js/select2.min.js"));
        
        }
    }
}