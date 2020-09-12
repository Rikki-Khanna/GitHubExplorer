﻿using GitHubExplorer.Models;
using GitHubExplorer.Controllers;
using Moq;
using NUnit.Framework;
using GitHubExplorer.Service.Interfaces;
using FizzWare.NBuilder;
using System.Web.Mvc;
using System.Collections.Generic;

namespace GitHubExplorer.Tests.ControllerTests
{
    [TestFixture]
    public class GitHubControllerTest
    {
        private GitHubController _gitHubController;
        private Mock<IService<GitHubRepository, GitHubCommitHistoryCollection>> _mockService;

        [SetUp]
        public void SetUp()
        {
            _mockService = new Mock<IService<GitHubRepository, GitHubCommitHistoryCollection>>();
            _gitHubController = new GitHubController(_mockService.Object);
        }


        [Test]
        public void ReturnsRepository_To_View()
        {
            // Arrange
            var actualResult = Builder<GitHubRepository>.CreateNew()
                .With(x => x.RepositoryItems = Builder<Items>.CreateListOfSize(100).Build()).Build();

            _mockService.Setup(x => x.GetRepository( actualResult.SearchName, 1)).Returns(actualResult);

            // Assign
            var result =
                _gitHubController.SearchRepo(actualResult.SearchName, 1) as ViewResult;

            // Assert
            _mockService.Verify(x => x.GetRepository(actualResult.SearchName, 1), Times.Once);

            var model = result?.Model as GitHubRepository;

            if (model == null) return;
            Assert.AreEqual(model.RepositoryItems.Count, actualResult.RepositoryItems.Count);

        }

        [Test]
        public void ReturnsCommitHistoryResult_To_View()
        {
            // Arrange
            var actualResult = Builder<GitHubCommitHistoryCollection>.CreateNew()
                .With(x => x.GitHubCommitHistory = Builder<GitHubCommitHistory>.CreateListOfSize(100).Build()).Build();

            _mockService.Setup(x => x.GetCommitHistory(actualResult.CommitUrl, 1)).Returns(actualResult);

            // Assign
            var result =
                _gitHubController.CommitHistory(actualResult.CommitUrl, 1) as ViewResult;

            // Assert
            _mockService.Verify(x => x.GetCommitHistory(actualResult.CommitUrl, 1), Times.Once);

            var model = result?.Model as GitHubCommitHistoryCollection;

            if (model == null) return;
            Assert.AreEqual(model.GitHubCommitHistory.Count, actualResult.GitHubCommitHistory.Count);

        }
    }
}