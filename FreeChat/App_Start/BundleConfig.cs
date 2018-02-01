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




            //-----------------------Admin Template Bundles 

            bundles.Add(new ScriptBundle("~/bundles/adminTemplateLayout").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap4/bootstrap.bundle.js",
                "~/Scripts/bootbox.js",
                "~/Scripts/AdminTemplate/sb-admin.js",
                "~/Scripts/datatables/jquery.dataTables.min.js",
                "~/Scripts/datatables/dataTables.bootstrap4.js",
                "~/Scripts/datatables/dataTables.responsive.min.js",
                "~/Scripts/datatables/responsive.bootstrap4.min.js"



                ));

            bundles.Add(new StyleBundle("~/bundles/adminTemplateLayoutStyle").Include(
                "~/Content/bootstrap4/bootstrap.min.css",
                "~/Content/sb-admin.css",
                "~/Content/datatables/css/datatables.bootstrap4.min.css",
                "~/Content/datatables/css/responsive.bootstrap.min.css",
                "~/Content/Site.css",
                "~/Content/font-awesome/css/font-awesome.min.css"
              ));

            //-----------------------End of Admin Template Bundles 




            //---------------------------------Views Bundles

            bundles.Add(new ScriptBundle("~/bundles/ChatEngineView").Include(
             "~/Scripts/jquery.signalR-2.2.2.min.js",
             "~/Scripts/Services/chatEngineService.js",
             "~/Scripts/Controllers/chatEngineController.js"
             ));

            bundles.Add(new StyleBundle("~/bundles/ChatEngineViewStyle").Include(
                "~/Content/ChatEngine.css"));



            bundles.Add(new ScriptBundle("~/bundles/ChatRoomView").Include(
                "~/Scripts/Controllers/chatRoomController.js",
                "~/Scripts/Services/chatRoomService.js"
               ));

            bundles.Add(new StyleBundle("~/bundles/ChatRoomViewStyle").Include(
                "~/Content/CreateRoom.css"));



            bundles.Add(new ScriptBundle("~/bundles/IndexView").Include(
                "~/Scripts/jquery.signalR-2.2.2.min.js",
                "~/Scripts/Services/indexService.js",
                "~/Scripts/Controllers/indexController.js",
                "~/Scripts/Controllers/monitorController.js")
                );

            bundles.Add(new StyleBundle("~/bundles/IndexViewStyle").Include(
                "~/Content/IndexPage.css"));


            bundles.Add(new ScriptBundle("~/bundles/ChartsView").Include(
                "~/Scripts/chart.js/Chart.min.js",
                "~/Scripts/AdminTemplate/sb-admin-charts.min.js"
                ));


            bundles.Add(new ScriptBundle("~/bundles/allChatRoomsPartial").Include(
                "~/Scripts/Services/indexService.js",
                "~/Scripts/Controllers/allChatRoomsPartialController.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/allChatRoomsViewStyle").Include(
                "~/Content/IndexPage.css"
                ));


            bundles.Add(new StyleBundle("~/bundles/MyRoomsViewStyle").Include(
                "~/Content/MyRooms.css"
            ));

            //----------------------------------End of Views Bundles

        }
    }
}
