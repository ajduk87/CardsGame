using Autofac.Integration.WebApi;
using Owin;
using System.Web.Http;

namespace CardsGameConfigService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Configure Web Api for self-host
            HttpConfiguration config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            var dependencyResolver = new AutofacWebApiDependencyResolver(ContainerInitializer.GetContainer());
            config.DependencyResolver = dependencyResolver;


            app.UseWebApi(config);
        }
    }
}
