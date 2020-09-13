using Newtonsoft.Json;
using GitHubExplorer.Service.Interfaces;

namespace GitHubExplorer.Service
{
    /// <summary>
    /// Class JsonConverter.
    /// Implements the <see cref="GitHubExplorer.Service.Interfaces.IJsonConverter" />
    /// </summary>
    /// <seealso cref="GitHubExplorer.Service.Interfaces.IJsonConverter" />
    public class JsonConverter : IJsonConverter
    {
        /// <summary>
        /// Deserializes the object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">The input.</param>
        /// <returns>T.</returns>
        public T DeserializeObject<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }
    }
}