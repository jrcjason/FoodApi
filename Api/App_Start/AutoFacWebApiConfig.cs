using Api.Models;
using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Api.App_Start
{
    public class AutoFacWebApiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterDependencies(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterDependencies(ContainerBuilder builder)
        {
            try
            {
                //Register Web API controllers.  
                builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

                builder.RegisterType<BusinessModel>().As<IProductModel>().InstancePerRequest();
                builder.RegisterType<BusinessModel>().As<IShoppingCartModel>().InstancePerRequest();

                Container = builder.Build();

                return Container;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}