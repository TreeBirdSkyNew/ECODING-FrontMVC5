using ECODING_FrontMVC5.InfraStructure.Project;
using ECODING_FrontMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ECODING_FrontMVC5.Controllers
{
    [RoutePrefix("Project")]
    public class ProjectController : Controller
    {
        private readonly ITemplateProjectApiClient _templateProjectApiClient;

        public ProjectController(ITemplateProjectApiClient templateProjectApiClient)
        {
            _templateProjectApiClient = templateProjectApiClient;
        }

        [Route("Index")]
        public async Task<ActionResult> Index()
        {
            List<TemplateProjectVM> templateProjectVM = await _templateProjectApiClient.GetAllTemplateProject("api/TemplateProject/index");
            return View(templateProjectVM);
        }

        [HttpGet()]
        [Route("ProjectDetails/{id}")]
        public async Task<ActionResult> ProjectDetails(int id)
        {
            TemplateProjectVM templateProjectVM = await _templateProjectApiClient.GetTemplateProjectById($"api/TemplateProject/TemplateProjectDetails/{id}");
            return View(templateProjectVM);
        }
    }
}
