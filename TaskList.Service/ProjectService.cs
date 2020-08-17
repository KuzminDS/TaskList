using System;
using System.Collections.Generic;
using System.Text;
using TaskList.Core;
using TaskList.Core.Models;
using TaskList.Core.Services;

namespace TaskList.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateProject(Project project)
        {
            _unitOfWork.Projects.Add(project);
            _unitOfWork.Commit();
        }

        public void DeleteProject(Project project)
        {
            _unitOfWork.Projects.Delete(project);
            _unitOfWork.Commit();
        }

        public Project GetWithToDoItemsById(int id)
        {
            return _unitOfWork.Projects.GetWithToDoItemsById(id);
        }

        public IEnumerable<Project> GetAllWithToDoItems()
        {
            return _unitOfWork.Projects.GetAllWithToDoItems();
        }

        public IEnumerable<Project> GetProjects()
        {
            return _unitOfWork.Projects.GetAll();
        }

        public Project GetProject(int id)
        {
            return _unitOfWork.Projects.GetById(id);
        }

        public void UpdateProject(Project projectToBeUpdate, Project newProject)
        {
            projectToBeUpdate.Name = newProject.Name;
            projectToBeUpdate.IsCompleted = newProject.IsCompleted;

            _unitOfWork.Commit();
        }
    }
}
