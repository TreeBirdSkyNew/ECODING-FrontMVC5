using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECODING_FrontMVC5.Models
{
    public class TemplateProjectVMForUpdate
    {
        public string TemplateProjectName { get; set; } = string.Empty;
        public string TemplateProjectTitle { get; set; } = string.Empty;
        public string TemplateProjectDescription { get; set; } = string.Empty;
        public string TemplateProjectVersion { get; set; } = string.Empty;
        public string TemplateProjectVersionNet { get; set; } = string.Empty;
    }
}