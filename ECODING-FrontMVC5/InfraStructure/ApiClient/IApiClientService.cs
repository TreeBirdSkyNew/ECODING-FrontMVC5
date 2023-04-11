using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ECODING_FrontMVC5.InfraStructure.ApiClient
{
    public interface IApiClientService
    {
        Task<HttpResponseMessage> GetList<TReturn>(string api);
        Task<HttpResponseMessage> GetObject<TReturn>(string api);
        Task<HttpResponseMessage> PostObject<TReturn>(string api, StringContent client);
        Task<HttpResponseMessage> DeleteObject<TReturn>(string api);
    }
}