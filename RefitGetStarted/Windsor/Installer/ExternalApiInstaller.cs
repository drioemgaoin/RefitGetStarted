using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Refit;
using RefitGetStarted.Services;

namespace RefitGetStarted.Windsor.Installer
{
    public class ExternalApiInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IJsonPlaceHolderApiService>()
                .Instance(RestService.For<IJsonPlaceHolderApiService>("http://jsonplaceholder.typicode.com"))
                .LifestyleSingleton()
            );
        }
    }
}