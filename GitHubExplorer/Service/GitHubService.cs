using GitHubExplorer.Models;
using GitHubExplorer.Service.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace GitHubExplorer.Service
{
    public class GitHubService : IService<GitHubRepository, GitHubCommitHistoryCollection>
    {
        private readonly IConfig _config;
        private readonly IHttpWebClient _webClient;
        private readonly IJsonConverter _jsonConverter;

        public GitHubService(IConfig config, IHttpWebClient webClient, IJsonConverter jsonConverter)
        {
            _config = config;
            _webClient = webClient;
            _jsonConverter = jsonConverter;
        }

        public GitHubRepository GetRepository(string searchName, int? page)
        {
            var gitHubRepo = new GitHubRepository();
            if (!string.IsNullOrEmpty(searchName))
            {
               var url = string.Concat(_config.GitHubUrl, "search/repositories?q=", searchName, "&page=", page, "&per_page=10");
               var jsonResult = _webClient.GetHttpStringResponse(url);
               gitHubRepo = JsonConvert.DeserializeObject<GitHubRepository>(jsonResult);
                if (gitHubRepo != null)
                {
                    var count = gitHubRepo.TotalCount;

                    if(gitHubRepo.TotalCount > 100)
                    {
                        count = 100;
                    }
                    var pager = new Pager(count, page);
                    gitHubRepo.Pager = pager;
                    gitHubRepo.SearchName = searchName;
                }       
            }

            return gitHubRepo;
        }

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