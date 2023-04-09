using ECODING_Repository;
using ECODING_Repository.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECODING_RepositoryWrapper.Project
{
    public class ProjectRepositoryWrapper : IProjectRepositoryWrapper
    {
        private ITemplateProjectRepository _projectRepository;
        public ITemplateProjectRepository ProjectRepository
        {
            get
            {
                if (_projectRepository == null)
                {
                    _projectRepository = new TemplateProjectRepository();
                }
                return _projectRepository;
            }
        }


        public ProjectRepositoryWrapper()
        {
        }
    }
}
