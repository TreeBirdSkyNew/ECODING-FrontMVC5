using ECODING_FrontMVC5.InfraStructure.Project;
using ECODING_FrontMVC5.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

        [HttpGet]
        [Route("ProjectDetails/{id}")]
        public async Task<ActionResult> ProjectDetails(int id)
        {
            TemplateProjectVM templateProjectVM = await _templateProjectApiClient.GetTemplateProjectById($"api/TemplateProject/TemplateProjectDetails/{id}");
            return View(templateProjectVM);
        }

        [HttpGet]
        [Route("TemplateProjectEdit/{id}")]
        public async Task<ActionResult> TemplateProjectEdit(int id)
        {
            TemplateProjectVM templateProjectVM = await _templateProjectApiClient.GetTemplateProjectById($"api/TemplateProject/TemplateProjectDetails/{id}");
            return View(templateProjectVM);
        }

        [HttpPost]
        [Route("TemplateProjectEdit")]
        public async Task<ActionResult> TemplateProjectEdit(TemplateProjectVM templateProjectVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateProjectVM), Encoding.UTF8, "application/json");
            await this._templateProjectApiClient.PostTemplateProject("api/TemplateProject/TemplateProjectEdit", content);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("TemplateProjectCreate")]
        public ActionResult TemplateProjectCreate()
        {
            TemplateProjectVM templateProjectVM = new TemplateProjectVM();
            return View(templateProjectVM);
        }
        
        [HttpPost]
        [Route("TemplateProjectCreate")]
        public async Task<ActionResult> TemplateProjectCreate(TemplateProjectVM templateProjectVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(templateProjectVM), Encoding.UTF8, "application/json");
            await this._templateProjectApiClient.PostTemplateProject("api/TemplateProject/TemplateProjectCreate", content);
            return RedirectToAction("Index");
        }

        [Route("TemplateProjectDelete/{id}")]
        public async Task<ActionResult> TemplateProjectDelete(int id)
        {
            await this._templateProjectApiClient.DeleteTemplateProject($"api/TemplateProject/TemplateProjectDelete/{id}");
            return RedirectToAction("Index");
        }
    }
}
