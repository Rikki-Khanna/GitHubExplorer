using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GitHubExplorer.Models
{
    /// <summary>
    /// Class GitHubRepository.
    /// </summary>
    public class GitHubRepository
    {
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("incomplete_results")]
        public bool IncompleteResults { get; set; }

        [JsonProperty("items")]
        public IList<Items> RepositoryItems { get; set; }

        public Pager Pager { get; set; }

        public string SearchName { get; set; }
    }

    public class Items
    {
        [JsonProperty("name")]
        public string RepositoryName { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("owner")]
        public Owner RepositoryOwner { get; set; }

        [JsonProperty("license")]
        public License RepositoryLicense { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedTime { get; set; }

        [JsonProperty("commits_url")]
        public string CommitsUrl { get; set; }

        [JsonProperty("git_commits_url")]
        public string GitCommitsUrl { get; set; }
    }

    public class License
    {
        [JsonProperty("key")]
        public string Licensekey { get; set; }

        [JsonProperty("name")]
        public string LicenseName { get; set; }

        [JsonProperty("spdx_id")]
        public string SPDXId { get; set; }

        [JsonProperty("url")]
        public string LicenseUrl { get; set; }

        [JsonProperty("node_id")]
        public string LicenseNodeId { get; set; }

    }

    public class Owner
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("node_id")]
        public string NodeId { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("gravatar_id")]
        public string GravatarId { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("received_events_url")]
        public string ReceivedEventsUrl { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}