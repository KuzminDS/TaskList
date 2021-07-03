using System;
using System.Collections.Generic;
using System.Text;
using TaskList.Core.Models;

namespace TaskList.Core.Services
{
    public interface IProjectService
    {
        IEnumerable<Project> GetProjects();
        IEnumerable<Project> GetAllWithToDoItems();
        Project GetProject(int id);
        Project GetWithToDoItemsById(int id);
        void CreateProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(Project project);
    }
}
