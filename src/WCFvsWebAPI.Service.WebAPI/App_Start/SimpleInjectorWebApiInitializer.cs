[assembly: WebActivator.PostApplicationStartMethod(typeof(WCFvsWebAPI.Service.WebAPI.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace WCFvsWebAPI.Service.WebAPI.App_Start
{
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using SimpleInjector.Lifestyles;
    using System.Web.Http;
    using WCFvsWebAPI.Infra.CrossCutting.IoC;

    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            Container container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            Bootstrap.RegisterServices(container);
        }
    }
}