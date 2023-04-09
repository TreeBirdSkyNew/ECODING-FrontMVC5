using ECODING_FrontMVC5.InfraStructure.ApiClient;
using ECODING_FrontMVC5.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ECODING_FrontMVC5.InfraStructure.Project
{
    public class TemplateProjectApiClient : ApiClientService, ITemplateProjectApiClient
    {
        public TemplateProjectApiClient() : base("https://localhost:44318/")
        {
        }

        public async Task<List<TemplateProjectVM>> GetAllTemplateProject(string api)
        {
            HttpResponseMessage httpResponseMessage = await GetObject<TemplateProjectVM>(api);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentStream))
                {
                    var templateProject = JsonConvert.DeserializeObject<List<TemplateProjectVM>>(contentStream);
                    if (templateProject != null)
                        return templateProject;
                }
            }
            return null;
        }

        public async Task<TemplateProjectVM> GetTemplateProjectById(string api)
        {
            HttpResponseMessage httpResponseMessage = await GetObject<TemplateProjectVM>(api);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(contentStream))
                {
                    var templateProject = JsonConvert.DeserializeObject<TemplateProjectVM>(contentStream);
                    if (templateProject != null)
                        return templateProject;
                }
            }
            return null;
        }
    }
}