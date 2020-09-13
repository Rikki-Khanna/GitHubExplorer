using Moq;
using NUnit.Framework;
using GitHubExplorer.Models;
using GitHubExplorer.Service;
using GitHubExplorer.Service.Interfaces;

namespace GitHubExplorer.Tests.Service
{
    [TestFixture]
    public class GitHubCommitServiceTest
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
        private IGitHubCommitService _iService;

        /// <summary>
        /// Sets up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _mockConverter = new Mock<IJsonConverter>();
            _mockConfig = new Mock<IConfig>();
            _mockWebClient = new Mock<IHttpWebClient>();
            _iService = new GitHubCommitService(_mockConfig.Object, _mockWebClient.Object, _mockConverter.Object);
        }

        /// Behavioral testing to verifies deserialized commit history
        /// <summary>
        /// Defines the test method Returns_DeserializedCommitHistory.
        /// </summary>
        [Test]
        public void Returns_DeserializedCommitHistory()
        {
            const string jsonCommitHistory = "[\n  {\n    \"sha\": \"8e52ebee844d94c504e435f8578d8fc81596deb3\",\n    \"node_id\": \"MDY6Q29tbWl0ODY1NDk3NTo4ZTUyZWJlZTg0NGQ5NGM1MDRlNDM1Zjg1NzhkOGZjODE1OTZkZWIz\",\n    \"commit\": {\n      \"author\": {\n        \"name\": \"John Papa\",\n        \"email\": \"john@johnpapa.net\",\n        \"date\": \"2013-07-20T03:27:40Z\"\n      },\n      \"committer\": {\n        \"name\": \"John Papa\",\n        \"email\": \"john@johnpapa.net\",\n        \"date\": \"2013-07-20T03:27:40Z\"\n      },\n      \"message\": \"craig\",\n      \"tree\": {\n        \"sha\": \"56d95d788fbe3847ceaa5c0a51b90381638d0f76\",\n        \"url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/git/trees/56d95d788fbe3847ceaa5c0a51b90381638d0f76\"\n      },\n      \"url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/git/commits/8e52ebee844d94c504e435f8578d8fc81596deb3\",\n      \"comment_count\": 0,\n      \"verification\": {\n        \"verified\": false,\n        \"reason\": \"unsigned\",\n        \"signature\": null,\n        \"payload\": null\n      }\n    },\n    \"url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/commits/8e52ebee844d94c504e435f8578d8fc81596deb3\",\n    \"html_url\": \"https://github.com/johnpapa/PluralsightSpaJumpStartFinal/commit/8e52ebee844d94c504e435f8578d8fc81596deb3\",\n    \"comments_url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/commits/8e52ebee844d94c504e435f8578d8fc81596deb3/comments\",\n    \"author\": {\n      \"login\": \"johnpapa\",\n      \"id\": 1202528,\n      \"node_id\": \"MDQ6VXNlcjEyMDI1Mjg=\",\n      \"avatar_url\": \"https://avatars2.githubusercontent.com/u/1202528?v=4\",\n      \"gravatar_id\": \"\",\n      \"url\": \"https://api.github.com/users/johnpapa\",\n      \"html_url\": \"https://github.com/johnpapa\",\n      \"followers_url\": \"https://api.github.com/users/johnpapa/followers\",\n      \"following_url\": \"https://api.github.com/users/johnpapa/following{/other_user}\",\n      \"gists_url\": \"https://api.github.com/users/johnpapa/gists{/gist_id}\",\n      \"starred_url\": \"https://api.github.com/users/johnpapa/starred{/owner}{/repo}\",\n      \"subscriptions_url\": \"https://api.github.com/users/johnpapa/subscriptions\",\n      \"organizations_url\": \"https://api.github.com/users/johnpapa/orgs\",\n      \"repos_url\": \"https://api.github.com/users/johnpapa/repos\",\n      \"events_url\": \"https://api.github.com/users/johnpapa/events{/privacy}\",\n      \"received_events_url\": \"https://api.github.com/users/johnpapa/received_events\",\n      \"type\": \"User\",\n      \"site_admin\": false\n    },\n    \"committer\": {\n      \"login\": \"johnpapa\",\n      \"id\": 1202528,\n      \"node_id\": \"MDQ6VXNlcjEyMDI1Mjg=\",\n      \"avatar_url\": \"https://avatars2.githubusercontent.com/u/1202528?v=4\",\n      \"gravatar_id\": \"\",\n      \"url\": \"https://api.github.com/users/johnpapa\",\n      \"html_url\": \"https://github.com/johnpapa\",\n      \"followers_url\": \"https://api.github.com/users/johnpapa/followers\",\n      \"following_url\": \"https://api.github.com/users/johnpapa/following{/other_user}\",\n      \"gists_url\": \"https://api.github.com/users/johnpapa/gists{/gist_id}\",\n      \"starred_url\": \"https://api.github.com/users/johnpapa/starred{/owner}{/repo}\",\n      \"subscriptions_url\": \"https://api.github.com/users/johnpapa/subscriptions\",\n      \"organizations_url\": \"https://api.github.com/users/johnpapa/orgs\",\n      \"repos_url\": \"https://api.github.com/users/johnpapa/repos\",\n      \"events_url\": \"https://api.github.com/users/johnpapa/events{/privacy}\",\n      \"received_events_url\": \"https://api.github.com/users/johnpapa/received_events\",\n      \"type\": \"User\",\n      \"site_admin\": false\n    },\n    \"parents\": [\n      {\n        \"sha\": \"52a7e476a925f0e4f3fa0bf1e5e7cbeea6ccb4da\",\n        \"url\": \"https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/commits/52a7e476a925f0e4f3fa0bf1e5e7cbeea6ccb4da\",\n        \"html_url\": \"https://github.com/johnpapa/PluralsightSpaJumpStartFinal/commit/52a7e476a925f0e4f3fa0bf1e5e7cbeea6ccb4da\"\n      }\n    ]\n  }\n]";
            _mockWebClient.Setup(x => x.GetHttpStringResponse("https://api.github.com/repos/johnpapa/PluralsightSpaJumpStartFinal/commits?page=1&per_page=1")).Returns(jsonCommitHistory);
            _mockConverter.Setup(x => x.DeserializeObject<GitHubCommitHistoryCollection>(jsonCommitHistory))
                .Returns(new GitHubCommitHistoryCollection())
                .Verifiable();
            _mockWebClient.Verify();
        }
    }
}
