using GitHubExplorer.Models;

namespace GitHubExplorer.Service.Interfaces
{
    /// <summary>
    /// Interface IGitHubCommitService
    /// </summary>
    public interface IGitHubCommitService
    {
        /// <summary>
        /// Gets the commit history.
        /// </summary>
        /// <param name="commitUrl">The commit URL.</param>
        /// <param name="page">The page.</param>
        /// <returns>GitHubCommitHistoryCollection.</returns>
        GitHubCommitHistoryCollection GetCommitHistory(string commitUrl, int? page);
    }
}
