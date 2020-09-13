using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using FizzWare.NBuilder;
using GitHubExplorer.Models;
using GitHubExplorer.Controllers;
using GitHubExplorer.Service.Interfaces;

namespace GitHubExplorer.Tests.Controller
{
    /// <summary>
    /// Defines test class GitHubControllerTest.
    /// </summary>
    [TestFixture]
    public class GitHubControllerTest
    {
        /// <summary>
        /// The git hub controller
        /// </summary>
        private GitHubController _gitHubController;

        /// <summary>
        /// The mock repo service
        /// </summary>
        private Mock<IGitHubRepoService> _mockRepoService;

        /// <summary>
        /// The mock commit service
        /// </summary>
        private Mock<IGitHubCommitService> _mockCommitService;

        /// <summary>
        /// Sets up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _mockRepoService = new Mock<IGitHubRepoService>();
            _mockCommitService = new Mock<IGitHubCommitService>();
            _gitHubController = new GitHubController(_mockRepoService.Object, _mockCommitService.Object);
        }


        /// <summary>
        /// Defines the test method ReturnsRepository_To_View.
        /// </summary>
        [Test]
        public void ReturnsRepository_To_View()
        {
            // Arrange
            var actualResult = Builder<GitHubRepository>.CreateNew()
                .With(x => x.RepositoryItems = Builder<Items>.CreateListOfSize(100).Build()).Build();

            // Passed -> string and page number, method GetRepository returns GitHubRepository.
            _mockRepoService.Setup(x => x.GetRepository(It.IsAny<string>(), 1)).Returns(actualResult);

            // Assign
            var result =
                _gitHubController.SearchRepo(actualResult.SearchName, 1) as ViewResult;

            // Assert
            _mockRepoService.Verify(x => x.GetRepository(It.IsAny<string>(), 1), Times.Once);

             var model = result?.Model as GitHubRepository;

             if (model == null) return;
             Assert.AreEqual(model.RepositoryItems.Count, actualResult.RepositoryItems.Count);

        }

        /// <summary>
        /// Defines the test method ReturnsCommitHistoryResult_To_View.
        /// </summary>
        [Test]
        public void ReturnsCommitHistoryResult_To_View()
        {
            // Arrange
            var actualResult = Builder<GitHubCommitHistoryCollection>.CreateNew()
                .With(x => x.GitHubCommitHistory = Builder<GitHubCommitHistory>.CreateListOfSize(100).Build()).Build();

            // Passed path of commit url and page number, method GetCommitHistory returns GitHubCommitHistoryCollection.
            _mockCommitService.Setup(x => x.GetCommitHistory(It.IsAny<string>(), 1)).Returns(actualResult);

            // Assign
            var result =
                _gitHubController.CommitHistory(actualResult.CommitUrl, 1) as ViewResult;

            // Assert
            _mockCommitService.Verify(x => x.GetCommitHistory(It.IsAny<string>(), 1), Times.Once);

            var model = result?.Model as GitHubCommitHistoryCollection;

            if (model == null) return;
            Assert.AreEqual(model.GitHubCommitHistory.Count, actualResult.GitHubCommitHistory.Count);

        }
    }
}
