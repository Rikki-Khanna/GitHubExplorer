using GitHubExplorer.Models;

namespace GitHubExplorer.Service.Interfaces
{
    /// <summary>
    /// Interface IGitHubRepoService
    /// </summary>
    public interface IGitHubRepoService
    {
        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <param name="searchName">Name of the search.</param>
        /// <param name="page">The page.</param>
        /// <returns>GitHubRepository.</returns>
        GitHubRepository GetRepository(string searchName, int? page);
    }
}
