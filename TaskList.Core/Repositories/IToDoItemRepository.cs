using System;
using System.Collections.Generic;
using System.Text;
using TaskList.Core.Models;
using TaskList.Core.Repositories;

namespace TaskList.Core.Repositories
{
    public interface IToDoItemRepository : IRepository<ToDoItem>
    {
        IEnumerable<ToDoItem> GetAllWithProject();
        ToDoItem GetWithProjectById(int id);
    }
}
