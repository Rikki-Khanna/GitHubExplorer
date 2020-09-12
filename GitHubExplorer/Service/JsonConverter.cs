using GitHubExplorer.Service.Interfaces;
using Newtonsoft.Json;

namespace GitHubExplorer.Service
{
    public class JsonConverter : IJsonConverter
    {
        public T DeserializeObject<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }
    }
}