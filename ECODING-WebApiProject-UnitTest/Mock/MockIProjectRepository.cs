using ECODING_DAL;
using ECODING_Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECODING_WebApiProject_UnitTest.Mock
{
    public class MockIProjectRepository
    {
        public static Mock<ITemplateProjectRepository> GetMock()
        {
            var mock = new Mock<ITemplateProjectRepository>();
            var templateProjects = new List<TemplateProject>()
            {
                new TemplateProject()
                {
                    TemplateProjectId=1,
                    TemplateProjectName="TemplateProjectName1",
                    TemplateProjectTitle="TemplateProjectTitle1",
                    TemplateProjectDescription="TemplateProjectDescription1",
                    TemplateProjectVersion="TemplateProjectVersion1",
                    TemplateProjectVersionNet="TemplateProjectVersionNet1",
                }
            };

            // Set up
            mock.Setup(m => m.GetAllTemplateProject()).Returns(() => templateProjects);

            mock.Setup(m => m.GetTemplateProjectById(It.IsAny<int>()))
                .Returns((int id) => templateProjects.FirstOrDefault(o => o.TemplateProjectId == id));

            mock.Setup(m => m.CreateTemplateProject(It.IsAny<TemplateProject>()))
                .Callback(() => { return; });
            mock.Setup(m => m.UpdateTemplateProject(It.IsAny<TemplateProject>()))
               .Callback(() => { return; });
            mock.Setup(m => m.DeleteTemplateProject(It.IsAny<int>()))
               .Callback(() => { return; });

            return mock;
        }
    }
}
