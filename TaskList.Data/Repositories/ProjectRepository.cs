using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskList.Core.Models;
using TaskList.Core.Repositories;

namespace TaskList.Data.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(TaskListDbContext context)
            : base(context) { }

        private TaskListDbContext TaskListDbContext
        {
            get { return _dbContext as TaskListDbContext; }
        }

        public Project GetProjectByName(string projectName)
        {
            return TaskListDbContext.Projects
                .SingleOrDefault(p => p.Name == projectName);
        }

        public IEnumerable<Project> GetAllWithToDoItems()
        {
            return TaskListDbContext.Projects
                .Include(p => p.ToDoItems)
                .ToList();
        }

        public Project GetWithToDoItemsById(int id)
        {
            return TaskListDbContext.Projects
                .Include(p => p.ToDoItems)
                .SingleOrDefault(p => p.ProjectId == id);
        }
    }
}
