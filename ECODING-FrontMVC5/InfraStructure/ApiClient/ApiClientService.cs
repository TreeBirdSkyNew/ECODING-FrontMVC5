using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ECODING_FrontMVC5.InfraStructure.ApiClient
{
    public class ApiClientService : IApiClientService
    {
        protected readonly HttpClient httpClient;

        public ApiClientService(string UrlTemplateProject)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.BaseAddress = new Uri(UrlTemplateProject);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<HttpResponseMessage> GetList<TReturn>(string urlApi)
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(urlApi);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return httpResponseMessage;
            }
            return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
        }

        public async Task<HttpResponseMessage> GetObject<TReturn>(string urlApi)
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(urlApi);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return httpResponseMessage;
            }
            return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
        }

        
    }
}