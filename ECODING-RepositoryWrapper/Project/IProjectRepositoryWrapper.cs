using ECODING_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECODING_RepositoryWrapper
{
    public interface IProjectRepositoryWrapper
    {
        ITemplateProjectRepository ProjectRepository { get; }
    }
}
