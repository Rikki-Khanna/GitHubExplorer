using System.Collections.Generic;
using Newtonsoft.Json;
using GitHubExplorer.Models;
using GitHubExplorer.Service.Interfaces;

namespace GitHubExplorer.Service
{
    public class GitHubCommitService : IGitHubCommitService 
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// The web client
        /// </summary>
        private readonly IHttpWebClient _webClient;

        /// <summary>
        /// The json converter
        /// </summary>
        private readonly IJsonConverter _jsonConverter;

        /// <summary>
        /// Initializes a new instance of the <see cref="GitHubCommitService"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="webclient">The webclient.</param>
        /// <param name="jsonConverter">The json converter.</param>
        public GitHubCommitService(IConfig config, IHttpWebClient webclient, IJsonConverter jsonConverter)
        {
            _config = config;
            _webClient = webclient;
            _jsonConverter = jsonConverter;
        }

        /// <summary>
        /// Gets the commit history.
        /// </summary>
        /// <param name="commitUrl">The commit URL.</param>
        /// <param name="page">The page.</param>
        /// <returns>GitHubCommitHistoryCollection.</returns>
        public GitHubCommitHistoryCollection GetCommitHistory(string commitUrl, int? page)
        {
            var gitCommitHistoryCollection = new GitHubCommitHistoryCollection();
            gitCommitHistoryCollection.CommitUrl = commitUrl;
            if (!string.IsNullOrEmpty(commitUrl))
            {
                var pageQueryString = string.Empty;
                if (page != null)
                {
                    pageQueryString = string.Concat("?page=", page, "&per_page=10");
                }
                var url = string.Concat(_config.GitHubUrl, commitUrl, pageQueryString);
                var jsonResult = _webClient.GetHttpStringResponse(url);
                var gitCommitHistory = JsonConvert.DeserializeObject<List<GitHubCommitHistory>>(jsonResult);
                var pager = new Pager(gitCommitHistory.Count, page);
                gitCommitHistoryCollection.Pager = pager;
                if(gitCommitHistory.Count >= 10)
                {
                    gitCommitHistoryCollection.GitHubCommitHistory = gitCommitHistory.GetRange(0, 10);
                }
                else
                {
                    gitCommitHistoryCollection.GitHubCommitHistory = gitCommitHistory;
                }
            }

            return gitCommitHistoryCollection;
        } 
    }
}