namespace GitHubExplorer.Service.Interfaces
{
    public interface IJsonConverter
    {
        T DeserializeObject<T>(string input);
    }
}
