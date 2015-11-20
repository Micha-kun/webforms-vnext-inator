using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using WebForms.vNextinator;

namespace SuperControlTest.DI
{
    /// <summary>
    ///  Unity dependency resolver. Allows to decouple configuration from Resolver. You can reuse UnityDependentyResolver
    ///   and configure it in each app without touching it.
    /// </summary>
    public sealed class UnityDependencyResolver : AbstractDependencyResolver<IUnityContainer>
    {

        public UnityDependencyResolver()
        {
            container = new UnityContainer();
        }

        public override object GetService(Type serviceType)
        {
            return container.Resolve(serviceType);
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            return container.ResolveAll(serviceType);
        }

    }
}