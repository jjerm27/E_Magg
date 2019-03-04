using System.Web;
using System.Web.Optimization;

namespace E_Mag
{
    public class BundleConfig
    {
        // Дополнительные сведения об объединении см. на странице https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // готово к выпуску, используйте средство сборки по адресу https://modernizr.com, чтобы выбрать только необходимые тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/shopscripts").Include(
                "~/Scripts/shopscripts/jquery.prettyPhoto.js",
                "~/Scripts/shopscripts/jquery.scrollUp.min.js",
                "~/scripts/jquery.unobtrusive-ajax.min.js",
                "~/Scripts/shopscripts/price-range.js",
                "~/Scripts/shopscripts/main.js",
                "~/Scripts/shopscripts/bootstrap.min.js",
                "~/Scripts/shopscripts/contact.js",
                "~/Scripts/shopscripts/gmaps.js",
                "~/Scripts/shopscripts/html5shiv.js",               
                "~/Scripts/shopscripts/jquery.js"                                                            
                ));

            bundles.Add(new ScriptBundle("~/bundles/calccripts").Include(
                "~/Scripts/shopscripts/CalculationScripts.js"
                ));

            bundles.Add(new StyleBundle("~/Content/shopcss").Include(
                "~/Content/shopcss/animate.css",
                "~/Content/shopcss/bootstrap.min.css",
                "~/Content/shopcss/font-awesome.min.css",
                "~/Content/shopcss/main.css",
                "~/Content/shopcss/prettyPhoto.css",
                "~/Content/shopcss/price-range.css",
                "~/Content/shopcss/responsive.css"
                ));
        }
    }
}
