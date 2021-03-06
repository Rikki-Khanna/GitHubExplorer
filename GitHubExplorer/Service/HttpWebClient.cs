﻿using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using GitHubExplorer.Service.Interfaces;

namespace GitHubExplorer.Service
{
    /// <summary>
    /// Class HttpWebClient.
    /// Implements the <see cref="GitHubExplorer.Service.Interfaces.IHttpWebClient" />
    /// </summary>
    /// <seealso cref="GitHubExplorer.Service.Interfaces.IHttpWebClient" />
    public class HttpWebClient : IHttpWebClient
    {
        /// <summary>
        /// Gets the HTTP string response.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>System.String.</returns>
        public string GetHttpStringResponse(string url)
        {
            using (var client = new HttpClient())
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(url).Result;

                return response.IsSuccessStatusCode ? response.Content.ReadAsStringAsync().Result : string.Empty;
            }
        }
    }
}
