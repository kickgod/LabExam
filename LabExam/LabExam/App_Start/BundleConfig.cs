using System.Web;
using System.Web.Optimization;

namespace LabExam
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Jquery 验证 Scripts文件里面有什么版本的jq 就使用什么版本的jq
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            //Jquery 验证插件
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            //支持旧版本的浏览器 提供新的HTML5标签支持 
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            //bootstrap js文件  在jquery文件之后加载
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));
            //bootsrap css文件
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //主页内容的css文件
            bundles.Add(new StyleBundle("~/Content/Mycss").Include(
                "~/Content/css/labEntry.min.css"));

            bundles.Add(new StyleBundle("~/Content/AdminEntry").Include(
    "~/Content/css/AdminEntry.min.css"));

            //主页需要的js文件
            bundles.Add(new ScriptBundle("~/bundles/myScript").Include(
                "~/Scripts/App/labLayout.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminScript").Include(
                "~/Scripts/App/adminEntry.js"));
        }
    }
}
