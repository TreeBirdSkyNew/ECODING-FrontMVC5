using AutoMapper;
using ECODING_FrontMVC5.Models;
using ECODING_WebApiProject;
using ECODING_WebApiProject.Controllers;
using ECODING_WebApiProject_UnitTest.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace ECODING_WebApiProject_UnitTest
{
    [TestClass]
    public class TemplateProjectControllerTests
    {
        public IMapper GetMapper()
        {
            var mappingProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
            return new Mapper(configuration);
        }

        [TestMethod]
        public void TemplateProjectController_ActionIndex_ReturnOk_CountOk()
        {
            var repositoryWrapperMock = MockProjectRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var templateProjectController = new TemplateProjectController(repositoryWrapperMock.Object, mapper);

            IHttpActionResult actionResult = templateProjectController.Index();
            var contentResult = actionResult as OkNegotiatedContentResult<List<TemplateProjectVM>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Count);
        }

        [TestMethod]
        public void TemplateProjectController_ActionDetails_VerifyPrimaryKey()
        {
            // Arrange
            var repositoryWrapperMock = MockProjectRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            repositoryWrapperMock.Setup(x => x.ProjectRepository.GetTemplateProjectById(1))
                .Returns(new ECODING_DAL.TemplateProject { TemplateProjectId = 1 });

            var templateProjectController = new TemplateProjectController(repositoryWrapperMock.Object, mapper);
            // Act
            IHttpActionResult actionResult = templateProjectController.TemplateProjectDetails(1);
            var contentResult = actionResult as OkNegotiatedContentResult<TemplateProjectVM>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.TemplateProjectId);
        }

        [TestMethod]
        public void TemplateProjectController_ActionDetails_NotFound()
        {
            // Arrange
            var repositoryWrapperMock = MockProjectRepositoryWrapper.GetMock();
            var mapper = GetMapper();

            // Act
            var templateProjectController = new TemplateProjectController(repositoryWrapperMock.Object, mapper);
            IHttpActionResult actionResult = templateProjectController.TemplateProjectDetails(10);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void TemplateProjectController_ActionDelete_ReturnsOk()
        {
            // Arrange
            var repositoryWrapperMock = MockProjectRepositoryWrapper.GetMock();
            var mapper = GetMapper();

            // Act
            var templateProjectController = new TemplateProjectController(repositoryWrapperMock.Object, mapper);
            IHttpActionResult actionResult = templateProjectController.TemplateProjectDelete(1);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        [TestMethod]
        public void TemplateProjectController_ActionCreate_ReturnsOk()
        {
            // Arrange
            var repositoryWrapperMock = MockProjectRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var templateProjectController = new TemplateProjectController(repositoryWrapperMock.Object, mapper);

            // Act
            IHttpActionResult actionResultCreate = templateProjectController.TemplateProjectCreate(
            new TemplateProjectVM { 
                TemplateProjectId = 10,
                TemplateProjectName = "TemplateProjectName10",
                TemplateProjectTitle = "TemplateProjectTitle10",
                TemplateProjectDescription = "TemplateProjectDescription10",
                TemplateProjectVersion = "TemplateProjectVersion10",
                TemplateProjectVersionNet = "TemplateProjectVersionNet10",

            });
            var createdResult = actionResultCreate as CreatedAtRouteNegotiatedContentResult<TemplateProjectVM>;
            // Assert
            Assert.IsNotNull(createdResult);
        }

    }
}
