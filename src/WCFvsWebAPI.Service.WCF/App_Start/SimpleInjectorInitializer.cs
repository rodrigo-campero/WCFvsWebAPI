[assembly: WebActivator.PostApplicationStartMethod(typeof(WCFvsWebAPI.Service.WCF.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace WCFvsWebAPI.Service.WCF.App_Start
{
    using SimpleInjector;
    using SimpleInjector.Integration.Wcf;
    using SimpleInjector.Lifestyles;
    using System.Reflection;
    using WCFvsWebAPI.Infra.CrossCutting.IoC;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it for the WCF ServiceHostFactory.</summary>
        public static void Initialize()
        {
            Container container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            InitializeContainer(container);

            container.RegisterWcfServices(Assembly.GetExecutingAssembly());

            container.Verify();

            SimpleInjectorServiceHostFactory.SetContainer(container);

            // TODO: Add the following attribute to all .svc files:
            // Factory="SimpleInjector.Integration.Wcf.SimpleInjectorServiceHostFactory, SimpleInjector.Integration.Wcf"
        }

        private static void InitializeContainer(Container container)
        {
            Bootstrap.RegisterServices(container);
        }
    }
}