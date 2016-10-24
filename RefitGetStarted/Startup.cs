using Microsoft.Owin;
using Owin;
using RefitGetStarted.Configuration;

[assembly: OwinStartup(typeof(RefitGetStarted.Startup))]

namespace RefitGetStarted
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Bootstrap.Factory.Create(app)
                .ConfigureSwagger()
                .UseWebApi();
        }
    }
}
