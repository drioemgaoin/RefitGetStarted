using System.Net.Http.Formatting;
using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Owin;
using RefitGetStarted.Windsor;
using RefitGetStarted.Windsor.Installer;

namespace RefitGetStarted.Configuration
{
    public sealed partial class Bootstrap
    {
        private readonly IAppBuilder app;
        private readonly IWindsorContainer container;
        private readonly HttpConfiguration configuration;

        public static class Factory
        {
            public static Bootstrap Create(IAppBuilder appBuilder)
            {
                var container = new WindsorContainer();
                var httpConfiguration = new HttpConfiguration();
                return new Bootstrap(appBuilder, container, httpConfiguration);
            }
        }

        internal Bootstrap(IAppBuilder app, IWindsorContainer container, HttpConfiguration configuration)
        {
            this.app = app;
            this.container = container;
            this.configuration = configuration;

            ConfigureContainer();
            ConfigureHttpConfiguration();
        }

        public Bootstrap UseWebApi()
        {
            app.UseWebApi(configuration);
            return this;
        }

        private void ConfigureContainer()
        {
            container.Install(
                new ExternalApiInstaller(),
                new ControllerInstaller()
            );

            container.Register(Classes.FromThisAssembly()
                .Pick()
                .WithServiceDefaultInterfaces()
                .Configure(c => c.LifestyleTransient()));
        }

        private void ConfigureHttpConfiguration()
        {
            configuration.MapHttpAttributeRoutes();
            configuration.DependencyResolver = new WindsorHttpDependencyResolver(container);

            ConfigureJsonFormatter();

            configuration.EnsureInitialized();
        }

        private void ConfigureJsonFormatter()
        {
            configuration.Formatters.Clear();
            configuration.Formatters.Add(new JsonMediaTypeFormatter());
            configuration.Formatters.JsonFormatter.SerializerSettings.
                ContractResolver = new CamelCasePropertyNamesContractResolver();
            configuration.Formatters.JsonFormatter.SerializerSettings.Converters.Add
                (new StringEnumConverter());
        }
    }
}