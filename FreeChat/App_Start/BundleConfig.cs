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
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


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
                "~/Scripts/Controllers/indexController.js",
                "~/Scripts/Controllers/monitorController.js",
                "~/Scripts/Services/IndexService.js"));
        }
    }
}
