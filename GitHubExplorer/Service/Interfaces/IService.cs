namespace GitHubExplorer.Service.Interfaces
{
    public interface IService<out TRepository, TGitHubCommitHistoryCollection>
    {
        TRepository GetRepository(string searchName, int? page);

        TGitHubCommitHistoryCollection GetCommitHistory(string commitUrl, int? page);
    }
}
