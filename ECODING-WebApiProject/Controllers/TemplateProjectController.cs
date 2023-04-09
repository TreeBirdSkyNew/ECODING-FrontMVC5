using AutoMapper;
using ECODING_DAL;
using ECODING_FrontMVC5.Models;
using ECODING_RepositoryWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ECODING_WebApiProject.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/TemplateProject")]
    public class TemplateProjectController : ApiController
    {
        private readonly IProjectRepositoryWrapper _projectRepositoryWrapper;

        public TemplateProjectController(IProjectRepositoryWrapper projectRepositoryWrapper)
        {
            _projectRepositoryWrapper = projectRepositoryWrapper;
        }

        [HttpGet]
        [Route("Index")]
        public IHttpActionResult Index()
        {
            try
            {
                List<TemplateProject> templateTechniques = _projectRepositoryWrapper.ProjectRepository.GetAllTemplateProject();
                if(templateTechniques is null)
                {
                    return NotFound();
                }
                else
                {
                    List<TemplateProjectVM> templateTechniquesVM = Mapper.Map<List<TemplateProjectVM>>(templateTechniques);
                    return Ok(templateTechniquesVM);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }

        }

        [HttpGet()]
        [Route("TemplateProjectDetails/{id}")]
        public IHttpActionResult TemplateProjectDetails(int id)
        {
            try
            {
                TemplateProject templateProject = _projectRepositoryWrapper.ProjectRepository.GetTemplateProjectById(id);
                if (templateProject is null)
                {
                    return NotFound();
                }
                else
                {
                    TemplateProjectVM templateProjectVM = Mapper.Map<TemplateProjectVM>(templateProject);
                    return Ok(templateProjectVM);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}
