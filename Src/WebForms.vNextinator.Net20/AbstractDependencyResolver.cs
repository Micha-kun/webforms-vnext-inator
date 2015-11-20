using System;
using System.Collections.Generic;

namespace WebForms.vNextinator
{
    public abstract class AbstractDependencyResolver<TContainer> : IDependencyResolver<TContainer>
    {
        protected TContainer container;

        public abstract object GetService(Type serviceType);
        public abstract IEnumerable<object> GetServices(Type serviceType);
        public AbstractDependencyResolver<TContainer> Configure(Action<TContainer> setupAction)
        {
            setupAction(container);
            return this;
        }
    }
}
