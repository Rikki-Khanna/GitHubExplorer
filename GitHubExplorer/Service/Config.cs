using System.Configuration;
using GitHubExplorer.Service.Interfaces;

namespace GitHubExplorer.Service
{
    /// <summary>
    /// Class Config.
    /// Implements the <see cref="GitHubExplorer.Service.Interfaces.IConfig" />
    /// </summary>
    /// <seealso cref="GitHubExplorer.Service.Interfaces.IConfig" />
    public class Config : IConfig
    {
        /// <summary>
        /// Gets the git hub URL.
        /// </summary>
        /// <value>The git hub URL.</value>
        public string GitHubUrl => string.IsNullOrEmpty(ConfigurationManager.AppSettings["gitHubUrl"])
            ? string.Empty
            : ConfigurationManager.AppSettings["gitHubUrl"];
    }
}