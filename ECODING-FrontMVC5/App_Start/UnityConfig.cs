using ECODING_FrontMVC5.InfraStructure.ApiClient;
using ECODING_FrontMVC5.InfraStructure.Project;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ECODING_FrontMVC5
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IApiClientService, ApiClientService>();
            container.RegisterType<ITemplateProjectApiClient, TemplateProjectApiClient>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}