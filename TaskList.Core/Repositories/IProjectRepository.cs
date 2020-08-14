using System;
using System.Collections.Generic;
using System.Text;
using TaskList.Core.Models;

namespace TaskList.Core.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        Project GetProjectByName(string projectName);
        IEnumerable<Project> GetAllWithToDoItems();
        Project GetWithToDoItemsById(int id);
    }
}
