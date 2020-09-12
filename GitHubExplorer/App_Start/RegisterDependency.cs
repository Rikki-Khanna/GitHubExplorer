using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using GitHubExplorer.Models;
using GitHubExplorer.Service;
using GitHubExplorer.Service.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace GitHubExplorer
{
    public static class RegisterDependency
    {
        public static void RegisterDependencies()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Register<IConfig, Config>();
            container.Register<IJsonConverter, JsonConverter>();
            container.Register<IHttpWebClient, HttpWebClient>();
            container.Register<IService<GitHubRepository, GitHubCommitHistoryCollection>, GitHubService>();
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}