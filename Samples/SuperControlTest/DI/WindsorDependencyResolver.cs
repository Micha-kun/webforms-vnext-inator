using Castle.Windsor;
using System;
using System.Collections.Generic;
using WebForms.vNextinator;

namespace SuperControlTest.DI
{
    public sealed class WindsorDependencyResolver : AbstractDependencyResolver<IWindsorContainer>
    {


        public WindsorDependencyResolver()
        {
            container = new WindsorContainer();
        }

        public override object GetService(Type serviceType)
        {
            return container.Resolve(serviceType);
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            return (object[])container.ResolveAll(serviceType);
        }

    }
}