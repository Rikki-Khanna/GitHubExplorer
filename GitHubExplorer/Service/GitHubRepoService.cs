using Newtonsoft.Json;
using GitHubExplorer.Models;
using GitHubExplorer.Service.Interfaces;

namespace GitHubExplorer.Service
{
    public class GitHubRepoService : IGitHubRepoService 
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
        /// Initializes a new instance of the <see cref="GitHubRepoService"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="webclient">The webclient.</param>
        /// <param name="jsonConverter">The json converter.</param>
        public GitHubRepoService(IConfig config, IHttpWebClient webclient, IJsonConverter jsonConverter)
        {
            _config = config;
            _webClient = webclient;
            _jsonConverter = jsonConverter;
        }

        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <param name="searchName">Name of the search.</param>
        /// <param name="page">The page.</param>
        /// <returns>GitHubRepository.</returns>
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
    }
}