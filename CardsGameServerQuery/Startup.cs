using Autofac.Integration.WebApi;
using Owin;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CardsGameServerQuery
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Configure Web Api for self-host
            HttpConfiguration config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            var dependencyResolver = new AutofacWebApiDependencyResolver(ContainerInitializer.GetContainer());
            config.DependencyResolver = dependencyResolver;

            app.UseWebApi(config);
        }
    }
}