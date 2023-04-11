using ECODING_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECODING_Repository
{
    public interface ITemplateProjectRepository
    {
        List<TemplateProject> GetAllTemplateProject();
        TemplateProject GetTemplateProjectById(int id);
        void UpdateTemplateProject(TemplateProject templateProject);
        void CreateTemplateProject(TemplateProject templateProject);
        void DeleteTemplateProject(int id);
    }
}
