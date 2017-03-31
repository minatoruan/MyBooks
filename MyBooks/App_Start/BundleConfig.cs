using System.Web.Optimization;

namespace MyBooks.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/node_modules/jquery/dist/jquery.min.js"));
			
            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/node_modules/bootstrap/dist/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include(
					"~/node_modules/bootstrap/dist/css/bootstrap.css",
                    "~/Content/site.css",
                    "~/Content/navbar.css"));
        }
    }
}
