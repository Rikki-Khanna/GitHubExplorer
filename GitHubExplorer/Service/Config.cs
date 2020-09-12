using GitHubExplorer.Service.Interfaces;
using System.Configuration;

namespace GitHubExplorer.Service
{
    public class Config : IConfig
    {
        public string GitHubUrl => string.IsNullOrEmpty(ConfigurationManager.AppSettings["gitHubUrl"])
            ? string.Empty
            : ConfigurationManager.AppSettings["gitHubUrl"];
    }
}