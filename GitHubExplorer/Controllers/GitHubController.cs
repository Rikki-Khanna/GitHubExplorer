using GitHubExplorer.Models;
using GitHubExplorer.Service.Interfaces;
using System.Web.Mvc;

namespace GitHubExplorer.Controllers
{
    public class GitHubController : Controller
    {

        public readonly IService<GitHubRepository, GitHubCommitHistoryCollection> _iService;

        public GitHubController(IService<GitHubRepository, GitHubCommitHistoryCollection> iService)
        {
            _iService = iService;
        }

        // GET: List of repository by repo name.
        public ActionResult SearchRepo(string searchName, int? page)
        {
            if (!string.IsNullOrEmpty(searchName))
            {
                return View(_iService.GetRepository(searchName, page));
            }

            return View(new GitHubRepository());
        }

        // GET: List of commit history for repository.
        public ActionResult CommitHistory(string commitUrl, int? page)
        {
            if (!string.IsNullOrEmpty(commitUrl))
            {
                return View(_iService.GetCommitHistory(commitUrl, page));
            }

            return View(new GitHubCommitHistoryCollection());
        }

    }
}