namespace GitHubExplorer.Service.Interfaces
{
    /// <summary>
    /// Interface IHttpWebClient
    /// </summary>
    public interface IHttpWebClient
    {
        /// <summary>
        /// Gets the HTTP string response.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>System.String.</returns>
        string GetHttpStringResponse(string url);
    }
}
