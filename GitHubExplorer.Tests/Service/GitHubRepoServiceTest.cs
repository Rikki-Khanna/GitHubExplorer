using Moq;
using NUnit.Framework;
using GitHubExplorer.Models;
using GitHubExplorer.Service;
using GitHubExplorer.Service.Interfaces;

namespace GitHubExplorer.Tests.Service
{
    [TestFixture]
    public class GitHubRepoServiceTest
    {
        /// <summary>
        /// The mock web client
        /// </summary>
        private Mock<IHttpWebClient> _mockWebClient;

        /// <summary>
        /// The mock configuration
        /// </summary>
        private Mock<IConfig> _mockConfig;

        /// <summary>
        /// The mock converter
        /// </summary>
        private Mock<IJsonConverter> _mockConverter;

        /// <summary>
        /// The i service
        /// </summary>
        private IGitHubRepoService _iService;

        /// <summary>
        /// Sets up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _mockConverter = new Mock<IJsonConverter>();
            _mockConfig = new Mock<IConfig>();
            _mockWebClient = new Mock<IHttpWebClient>();
            _iService = new GitHubRepoService(_mockConfig.Object,_mockWebClient.Object, _mockConverter.Object);
        }

        /// Behavioral testing to verifies deserialized repo
        /// <summary>
        /// Defines the test method Returns_DeserializedRepositories.
        /// </summary>
        [Test]
        public void Returns_DeserializedRepositories()
        {
            const string jsonRepositories = "{\n  \"total_count\": 12064,\n  \"incomplete_results\": false,\n  \"items\": [\n    {\n      \"id\": 8654975,\n      \"node_id\": \"MDEwOlJlcG9zaXRvcnk4NjU0OTc1\",\n      \"name\": \"PluralsightSpaJumpStartFinal\",\n      \"full_name\": \"johnpapa/PluralsightSpaJumpStartFinal\",\n      \"private\": false,\n      \"owner\": {\n        \"login\": \"johnpapa\",\n        \"id\": 1202528,\n        \"node_id\": \"MDQ6VXNlcjEyMDI1Mjg=\",\n        \"avatar_url\": \"https://avatars2.githubusercontent.com/u/1202528?v=4\",\n        \"gravatar_id\": \"\",\n        \"url\": \"https://api.github.com/users/johnpapa\",\n        \"html_url\": \"https://github.com/johnpapa\",\n        \"followers_url\": \"https://api.github.com/users/johnpapa/followers\",\n        \"following_url\": \"https://api.github.com/users/johnpapa/following{/other_user}\",\n        \"gists_url\": \"https://api.github.com/users/johnpapa/gists{/gist_id}\",\n        \"starred_url\": \"https://api.github.com/users/johnpapa/starred{/owner}{/repo}\",\n        \"subscriptions_url\": \"https://api.github.com/users/johnpapa/subscriptions\",\n        \"organizations_url\": \"https://api.github.com/users/johnpapa/orgs\",\n        \"repos_url\": \"https://api.github.com/users/johnpapa/repos\",\n        \"events_url\": \"https://api.github.com/users/johnpapa/events{/privacy}\",\n        \"received_events_url\": \"https://api.github.com/users/johnpapa/received_events\",\n        \"type\": \"User\",\n        \"site_admin\": false\n      },\n      \"html_url\": \"https://github.com/johnpapa/PluralsightSpaJumpStartFinal\",\n      \"description\": \"Source code for the SPA JumpStart Pluralsight course at http://jpapa.me/spajsps\",\n      \"fork\": false,\n      \"url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal\",\n      \"forks_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/forks\",\n      \"keys_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/keys{/key_id}\",\n      \"collaborators_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/collaborators{/collaborator}\",\n      \"teams_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/teams\",\n      \"hooks_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/hooks\",\n      \"issue_events_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/issues/events{/number}\",\n      \"events_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/events\",\n      \"assignees_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/assignees{/user}\",\n      \"branches_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/branches{/branch}\",\n      \"tags_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/tags\",\n      \"blobs_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/git/blobs{/sha}\",\n      \"git_tags_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/git/tags{/sha}\",\n      \"git_refs_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/git/refs{/sha}\",\n      \"trees_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/git/trees{/sha}\",\n      \"statuses_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/statuses/{sha}\",\n      \"languages_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/languages\",\n      \"stargazers_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/stargazers\",\n      \"contributors_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/contributors\",\n      \"subscribers_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/subscribers\",\n      \"subscription_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/subscription\",\n      \"commits_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/commits{/sha}\",\n      \"git_commits_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/git/commits{/sha}\",\n      \"comments_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/comments{/number}\",\n      \"issue_comment_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/issues/comments{/number}\",\n      \"contents_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/contents/{+path}\",\n      \"compare_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/compare/{base}...{head}\",\n      \"merges_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/merges\",\n      \"archive_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/{archive_format}{/ref}\",\n      \"downloads_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/downloads\",\n      \"issues_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/issues{/number}\",\n      \"pulls_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/pulls{/number}\",\n      \"milestones_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/milestones{/number}\",\n      \"notifications_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/notifications{?since,all,participating}\",\n      \"labels_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/labels{/name}\",\n      \"releases_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/releases{/id}\",\n      \"deployments_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/deployments\",\n      \"created_at\": \"2013-03-08T16:33:51Z\",\n      \"updated_at\": \"2020-05-28T09:35:08Z\",\n      \"pushed_at\": \"2015-09-03T11:24:04Z\",\n      \"git_url\": \"git://github.com/johnpapa/PluralsightSpaJumpStartFinal.git\",\n      \"ssh_url\": \"git@github.com:johnpapa/PluralsightSpaJumpStartFinal.git\",\n      \"clone_url\": \"https://github.com/johnpapa/PluralsightSpaJumpStartFinal.git\",\n      \"svn_url\": \"https://github.com/johnpapa/PluralsightSpaJumpStartFinal\",\n      \"homepage\": null,\n      \"size\": 24392,\n      \"stargazers_count\": 133,\n      \"watchers_count\": 133,\n      \"language\": \"JavaScript\",\n      \"has_issues\": true,\n      \"has_projects\": true,\n      \"has_downloads\": true,\n      \"has_wiki\": true,\n      \"has_pages\": false,\n      \"forks_count\": 1430,\n      \"mirror_url\": null,\n      \"archived\": false,\n      \"disabled\": false,\n      \"open_issues_count\": 2,\n      \"license\": null,\n      \"forks\": 1430,\n      \"open_issues\": 2,\n      \"watchers\": 133,\n      \"default_branch\": \"master\",\n      \"score\": 1.0\n    }\n  ]\n}";
            _mockWebClient.Setup(x => x.GetHttpStringResponse("https://api.github.com/search/repositories?q=plural&page=1&per_page=1")).Returns(jsonRepositories);
            _mockConverter.Setup(x => x.DeserializeObject<GitHubRepository>(jsonRepositories))
                .Returns(new GitHubRepository())
                .Verifiable();
            _mockWebClient.Verify();
        }
    }
}
