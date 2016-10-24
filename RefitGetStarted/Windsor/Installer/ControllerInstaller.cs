using System.Web.Http.Controllers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace RefitGetStarted.Windsor.Installer
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                         .BasedOn<IHttpController>()
                        .LifestyleTransient()
                .Configure(configurer => configurer.Named(configurer.Implementation.Name))
                .LifestyleTransient());
        }
    }
}