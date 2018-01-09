using System.Web.Optimization;

namespace FreeChat
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
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //                      "~/Content/bootstrap.css",
                      "~/Content/sb-admin.css",

                      "~/Content/site.css"));


            bundles.Add(new ScriptBundle("~/bundles/adminTemplateLayout").Include(
                "~/vendor/jquery/jquery.min.js",
                "~/vendor/bootstrap/js/bootstrap.bundle.min.js",
                "~/vendor/jquery-easing/jquery.easing.min.js",
                "~/vendor/datatables/jquery.dataTables.js",
                "~/vendor/datatables/dataTables.bootstrap4.js",
                "~/Scripts/AdminTemplate/sb-admin.min.js",
                "~/Scripts/AdminTemplate/sb-admin-datatables.min.js"

                ));

            bundles.Add(new StyleBundle("~/bundles/adminTemplateLayoutStyle").Include(
                    "~/vendor/bootstrap/css/bootstrap.min.css",
                    "~/vendor/font-awesome/css/font-awesome.min.css",
                    "~/vendor/datatables/dataTables.bootstrap4.css",
                    "~/Content/sb-admin.css",
                    "~/Content/Site.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/ChatEngineView").Include(
             "~/Scripts/jquery.signalR-2.2.2.min.js",
             "~/Scripts/Controllers/chatEngineController.js",
             "~/Scripts/Services/chatEngineService.js"));

            bundles.Add(new StyleBundle("~/bundles/ChatEngineViewStyle").Include(
                "~/Content/ChatEngine.css"));



            bundles.Add(new ScriptBundle("~/bundles/ChatRoomView").Include(
                "~/Scripts/Controllers/chatRoomController.js",
                "~/Scripts/Services/chatRoomService.js",
                "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new StyleBundle("~/bundles/ChatRoomViewStyle").Include(
                "~/Content/CreateRoom.css"));



            bundles.Add(new ScriptBundle("~/bundles/IndexView").Include(
                "~/Scripts/jquery.signalR-2.2.2.min.js",
                "~/Scripts/Services/indexService.js",
                "~/Scripts/Controllers/indexController.js",
                "~/Scripts/Controllers/monitorController.js")
                );


            bundles.Add(new ScriptBundle("~/bundles/ChartsView").Include(
                "~/vendor/chart.js/Chart.min.js",
                "~/Scripts/AdminTemplate/sb-admin-charts.min.js"
                ));

        }
    }
}
