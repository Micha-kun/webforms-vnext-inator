//using Castle.MicroKernel.Registration;
//using Microsoft.Practices.Unity;
using SuperControlTest.DI;
using SuperControlTest.Presenters;
using System;
using System.Web.Http;
using WebForms.vNextinator;


namespace SuperControlTest
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(config =>
            {
                config.MapHttpAttributeRoutes();
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
            });

            //Ninject depencency resolver
            DependencyResolver.SetDependencyResolver(
            new NinjectDependencyResolver().Configure(
                    kernel =>
                    {
                        kernel.Bind<IInjectionTest>().To<InjectionTest>();
                        kernel.Bind<IDefaultPresenter>().To<DefaultPresenter>();
                    }));

            /* Unity dependency resolver. Allows to decouple configuration from Resolver. You can reuse UnityDependentyResolver
             * and configure it in each app without touching it.*/
            //DependencyResolver.SetDependencyResolver(
            //new UnityDependencyResolver().Configure(
            //        container =>
            //        {
            //            container.RegisterType<IInjectionTest, InjectionTest>();
            //            container.RegisterType<IDefaultPresenter, DefaultPresenter>();
            //        }));

            // Windsor dependency resolver.
            //DependencyResolver.SetDependencyResolver(
            //    new WindsorDependencyResolver().Configure(
            //        container =>
            //        {
            //            container.Register(Component.For<IInjectionTest>().ImplementedBy<InjectionTest>());
            //        }));
        }
    }
}