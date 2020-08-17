using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskList.Api.Resources;
using TaskList.Api.Validators;
using TaskList.Core.Models;
using TaskList.Core.Services;

namespace TaskList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<ProjectResource>> GetAllProjects()
        {
            var projects = _projectService.GetProjects();
            var projectsResource = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectResource>>(projects);
            return Ok(projectsResource);
        }

        [HttpGet("{id}")]
        public ActionResult<ProjectResource> GetById(int id)
        {
            var project = _projectService.GetProject(id);
            var projectResource = _mapper.Map<Project, ProjectResource>(project);
            return Ok(projectResource);
        }

        [HttpPost("")]
        public ActionResult<ProjectResource> CreateProject([FromBody] SaveProjectResource saveProjectResource)
        {
            var validator = new SaveProjectResourceValidator();
            var validationResult = validator.Validate(saveProjectResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var projectToCreate = _mapper.Map<SaveProjectResource, Project>(saveProjectResource);

            _projectService.CreateProject(projectToCreate);

            var project = _projectService.GetProject(projectToCreate.ProjectId);
            var projectResource = _mapper.Map<Project, ProjectResource>(project);

            return Ok(projectResource);
        }

        [HttpPut("(id)")]
        public ActionResult<ProjectResource> UpdateProject(int id, [FromBody] SaveProjectResource saveProjectResource)
        {
            var validator = new SaveProjectResourceValidator();
            var validationResult = validator.Validate(saveProjectResource);

            bool requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);

            var projectToBeUpdate = _projectService.GetProject(id);

            if (projectToBeUpdate == null)
                return NotFound();

            var project = _mapper.Map<SaveProjectResource, Project>(saveProjectResource);
            _projectService.UpdateProject(projectToBeUpdate, project);

            var updatedProject = _projectService.GetProject(id);
            var updatedProjectResource = _mapper.Map<Project, ProjectResource>(updatedProject);
            return Ok(updatedProjectResource);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            if (id == 0)
                return BadRequest();

            var project = _projectService.GetProject(id);

            if (project == null)
                return NotFound();

            _projectService.DeleteProject(project);

            return NoContent();
        }
    }
}
