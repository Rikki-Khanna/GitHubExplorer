using System;
using System.Reflection;
using System.Web.Mvc;
using GitHubExplorer.Service;
using GitHubExplorer.Service.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace GitHubExplorer
{
    /// <summary>Class RegisterDependency.</summary>
    public static class RegisterDependency
    {
        /// <summary>Registers the dependencies.</summary>
        public static void RegisterDependencies()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Register<IConfig, Config>();
            container.Register<IJsonConverter, JsonConverter>();
            container.Register<IHttpWebClient, HttpWebClient>();
            container.Register<IGitHubRepoService, GitHubRepoService>();
            container.Register<IGitHubCommitService, GitHubCommitService>();
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}