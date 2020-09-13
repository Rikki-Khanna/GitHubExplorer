using System.Web.Mvc;
using GitHubExplorer.Models;
using GitHubExplorer.Service.Interfaces;

namespace GitHubExplorer.Controllers
{
    /// <summary>
    /// Class GitHubController.
    /// Implements the <see cref="System.Web.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class GitHubController : Controller
    {

        /// <summary>
        /// The i repo service
        /// </summary>
        public readonly IGitHubRepoService _iRepoService;

        /// <summary>
        /// The i commit service
        /// </summary>
        public readonly IGitHubCommitService _iCommitService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GitHubController"/> class.
        /// </summary>
        /// <param name="iRepoService">The i repo service.</param>
        /// <param name="iCommitService">The i commit service.</param>
        public GitHubController(IGitHubRepoService iRepoService, IGitHubCommitService iCommitService)
        {
            _iRepoService = iRepoService;
            _iCommitService = iCommitService;
        }

        // GET: List of repository by repo name.
        /// <summary>
        /// Searches the repo.
        /// </summary>
        /// <param name="searchName">Name of the search.</param>
        /// <param name="page">The page.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult SearchRepo(string searchName, int? page)
        {
            if (!string.IsNullOrEmpty(searchName))
            {
                return View(_iRepoService.GetRepository(searchName, page));
            }

            return View(new GitHubRepository());
        }

        // GET: List of commit history for repository.
        /// <summary>
        /// Commits the history.
        /// </summary>
        /// <param name="commitUrl">The commit URL.</param>
        /// <param name="page">The page.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult CommitHistory(string commitUrl, int? page)
        {
            if (!string.IsNullOrEmpty(commitUrl))
            {
                return View(_iCommitService.GetCommitHistory(commitUrl, page));
            }

            return View(new GitHubCommitHistoryCollection());
        }

    }
}