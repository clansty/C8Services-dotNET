using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using Owin;
using Microsoft.Owin.Cors;

namespace C8Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            //配置路由
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.EnableCors(new EnableCorsAttribute("*","*", "*"));
                app.UseWebApi(config);
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
    
}