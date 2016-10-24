using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.MicroKernel;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;

namespace RefitGetStarted.Windsor
{
    internal class WindsorDependencyScope : IDependencyScope
    {
        private readonly IWindsorContainer container;
        private readonly IDisposable scope;

        public WindsorDependencyScope(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            this.container = container;
            scope = container.BeginScope();
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

        public IEnumerable<object> GetServices(Type serviceType) => container.ResolveAll(serviceType).Cast<object>();

        public void Dispose() => scope?.Dispose();
    }
}