
using Ninject;
using System;
using System.Collections.Generic;
using WebForms.vNextinator;

namespace SuperControlTest.DI
{
    public sealed class NinjectDependencyResolver : AbstractDependencyResolver<IKernel>
    {
        public NinjectDependencyResolver()
        {
            container = new StandardKernel();
        }

        public override object GetService(Type serviceType)
        {
            return container.Get(serviceType);
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            return container.GetAll(serviceType);
        }
    }
}