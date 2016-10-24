using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.MicroKernel;
using Castle.Windsor;

namespace RefitGetStarted.Windsor
{
    public class WindsorHttpDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver
    {
        private readonly IWindsorContainer container;

        public WindsorHttpDependencyResolver(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container), @"The instance of the container cannot be null.");
            }

            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch (ComponentNotFoundException)
            {
                return null;
            }
        }

        public IDependencyScope BeginScope() => new WindsorDependencyScope(container);

        public IEnumerable<object> GetServices(Type serviceType) => container.ResolveAll(serviceType).Cast<object>();

        public void Dispose() => container.Dispose();
    }
}