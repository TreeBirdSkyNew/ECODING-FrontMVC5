using ECODING_RepositoryWrapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECODING_WebApiProject_UnitTest.Mock
{
    public class MockProjectRepositoryWrapper
    {
        public static Mock<IProjectRepositoryWrapper> GetMock()
        {
            var mock = new Mock<IProjectRepositoryWrapper>();
            var projectRepoMock = MockIProjectRepository.GetMock();
            mock.Setup(m => m.ProjectRepository).Returns(() => projectRepoMock.Object);
            return mock;
        }
    }
}
