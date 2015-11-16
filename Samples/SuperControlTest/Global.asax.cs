﻿using SuperControlTest.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.SessionState;
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
            DependencyResolver.SetDependencyResolver(new NinjectDependencyResolver());

            /* Unity dependency resolver. Allows to decouple configuration from Resolver. You can reuse UnityDependentyResolver
             * and configure it in each app without touching it.
            DependencyResolver.SetDependencyResolver(UnityDependencyResolver.configureAndGet(container =>
            {
                container.RegisterType<IInjectionTest, InjectionTest>();
                // container.RegisterType<AnotherIface, AnotherClass>();
                //and so on...
            })); */
        }
    }
}