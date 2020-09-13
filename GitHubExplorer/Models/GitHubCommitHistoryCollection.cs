using System.Collections.Generic;

namespace GitHubExplorer.Models
{
    /// <summary>
    /// Class GitHubCommitHistoryCollection.
    /// </summary>
    public class GitHubCommitHistoryCollection
    {
        public IList<GitHubCommitHistory> GitHubCommitHistory { get; set; }

        public Pager Pager { get; set; }

        public string CommitUrl { get; set; }

    }
}