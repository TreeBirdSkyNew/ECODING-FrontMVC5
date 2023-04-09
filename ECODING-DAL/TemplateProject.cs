using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECODING_DAL
{
    public class TemplateProject
    {
        public int TemplateProjectId { get; set; }
        public string TemplateProjectName { get; set; } = string.Empty;
        public string TemplateProjectTitle { get; set; } = string.Empty;
        public string TemplateProjectDescription { get; set; } = string.Empty;
        public string TemplateProjectVersion { get; set; } = string.Empty;
        public string TemplateProjectVersionNet { get; set; } = string.Empty;
    }
}
