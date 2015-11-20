using System;
using System.Collections.Generic;

namespace WebForms.vNextinator
{
    internal interface IDependencyResolver
    {
        object GetService(Type serviceType);

        IEnumerable<object> GetServices(Type serviceType);
    }

    internal interface IDependencyResolver<TContainer> : IDependencyResolver
    {
        AbstractDependencyResolver<TContainer> Configure(Action<TContainer> setupAction);
    }

}
