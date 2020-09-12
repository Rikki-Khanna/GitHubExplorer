using GitHubExplorer.Models;

namespace GitHubExplorer.Service.Interfaces
{
    public interface IGitHubService
    {
        GitHubRepository GetRepository(string searchName, int? page);
    }
}
