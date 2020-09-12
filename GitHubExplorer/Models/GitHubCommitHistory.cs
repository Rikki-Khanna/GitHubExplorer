using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitHubExplorer.Models
{
    public class GitHubCommitHistory
    {
        [JsonProperty("sha")]
        public string SHA { get; set; }

        [JsonProperty("node_id")]
        public string NodeId { get; set; }

        [JsonProperty("Commit")]
        public Commit CommitDetail { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }

        [JsonProperty("comments_url")]
        public string CommentsUrl { get; set; }

        //[JsonProperty("author")]
        //public Author AuthorDetail { get; set; }

        //[JsonProperty("committer")]
        //public Committer CommitterDetail { get; set; }

        [JsonProperty("parents")]
        public IList<Parent> Parents { get; set; }
    }
    public class Author
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Date")]
        public DateTime Date { get; set; }
    }

    public class Committer
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("Email")]
        public string email { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }

    public class Tree
    {
        [JsonProperty("sha")]
        public string SHA { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Verification
    {
        [JsonProperty("verified")]
        public bool Verified { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("signature")]
        public object Signature { get; set; }

        [JsonProperty("payload")]
        public object Payload { get; set; }
    }

    public class Commit
    {
        [JsonProperty("author")]
        public Author AuthorDetail { get; set; }

        [JsonProperty("committer")]
        public Committer CommitterDetail { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("tree")]
        public Tree TreeDetail { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("comment_count")]
        public int CommentCount { get; set; }

        [JsonProperty("Verification")]
        public Verification verification { get; set; }
    }
    public class Parent
    {
        [JsonProperty("sha")]
        public string SHA { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }
    }
}