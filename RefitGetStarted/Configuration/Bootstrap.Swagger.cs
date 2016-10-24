using Swashbuckle.Application;

namespace RefitGetStarted.Configuration
{
    public sealed partial class Bootstrap
    {
        public Bootstrap ConfigureSwagger()
        {
            configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Refit API");
                })
                .EnableSwaggerUi(c => c.DisableValidator());

            return this;
        }
    }
}