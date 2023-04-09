using ECODING_FrontMVC5.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECODING_FrontMVC5.InfraStructure.Project
{
    public interface ITemplateProjectApiClient
    {
        Task<List<TemplateProjectVM>> GetAllTemplateProject(string api);
        Task<TemplateProjectVM> GetTemplateProjectById(string api);
    }
}