﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GitHubExplorer.Models
{
    /// <summary>
    /// Class GitHubCommitHistory.
    /// </summary>
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

        [JsonProperty("parents")]
        public IList<Parent> Parents { get; set; }
    }

    /// <summary>
    /// Class Author.
    /// </summary>
    public class Author
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Date")]
        public DateTime Date { get; set; }
    }

    /// <summary>
    /// Class Committer.
    /// </summary>
    public class Committer
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("Email")]
        public string email { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }

    /// <summary>
    /// Class Tree.
    /// </summary>
    public class Tree
    {
        [JsonProperty("sha")]
        public string SHA { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    /// <summary>
    /// Class Verification.
    /// </summary>
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

    /// <summary>
    /// Class Commit.
    /// </summary>
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

    /// <summary>
    /// Class Parent.
    /// </summary>
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