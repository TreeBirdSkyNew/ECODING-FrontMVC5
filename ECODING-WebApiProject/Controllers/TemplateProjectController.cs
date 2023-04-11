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
        private readonly IMapper _mapper;

        public TemplateProjectController(IProjectRepositoryWrapper projectRepositoryWrapper,
            IMapper mapper)
        {
            _projectRepositoryWrapper = projectRepositoryWrapper;
            _mapper = mapper;
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
                    List<TemplateProjectVM> templateTechniquesVM = _mapper.Map<List<TemplateProjectVM>>(templateTechniques);
                    return Ok(templateTechniquesVM);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }

        }

        [HttpGet]
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
                    TemplateProjectVM templateProjectVM = _mapper.Map<TemplateProjectVM>(templateProject);
                    return Ok(templateProjectVM);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("TemplateProjectCreate")]
        public IHttpActionResult TemplateProjectCreate([FromBody] TemplateProjectVM templateProjectVM)
        {
            try
            {
                if (templateProjectVM is null)
                {
                    return BadRequest("templateTechnique object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                TemplateProject TemplateProjectEntity = _mapper.Map<TemplateProject>(templateProjectVM);
                _projectRepositoryWrapper.ProjectRepository.CreateTemplateProject(TemplateProjectEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("TemplateProjectEdit")]
        public IHttpActionResult TemplateProjectEdit([FromBody] TemplateProjectVM templateProjectVM)
        {
            try
            {
                if (templateProjectVM is null)
                {
                    return BadRequest("TemplateProjectEdit object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                TemplateProject templateProject = _mapper.Map<TemplateProject>(templateProjectVM);
                _projectRepositoryWrapper.ProjectRepository.UpdateTemplateProject(templateProject);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [Route("TemplateProjectDelete/{id}")]
        [HttpDelete]
        public IHttpActionResult TemplateProjectDelete(int id)
        {
            try
            {
                _projectRepositoryWrapper.ProjectRepository.DeleteTemplateProject(id);
                return Ok();
             }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}


