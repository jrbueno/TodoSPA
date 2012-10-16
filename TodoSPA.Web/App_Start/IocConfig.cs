using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TodoSPA.Data;
using TodoSPA.Model;
using Ninject;

namespace TodoSPA.Web
{
    public class IocConfig
    {
        public static void RegisterIoc(HttpConfiguration config)
        {
            var kernel = new StandardKernel();

            kernel.Bind<RepoFactories>().To<RepoFactories>().InSingletonScope();
            kernel.Bind<IRepoProvider>().To<RepoProvider>();
            kernel.Bind<ITodoUoW>().To<TodoUoW>();

            config.DependencyResolver = new NinjectDependencyResolver(kernel);

        }
    }
}