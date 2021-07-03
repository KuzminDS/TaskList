using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskList.Core.Models;
using TaskList.Core.Repositories;

namespace TaskList.Data.Repositories
{
    public class ToDoItemRepository : Repository<ToDoItem>, IToDoItemRepository
    {
        public ToDoItemRepository(TaskListDbContext dbContext)
            : base(dbContext) { }

        public IEnumerable<ToDoItem> GetAllWithProject()
        {
            return TaskListDbContext.ToDoItems
                .Include(t => t.Project)
                .ToList();
        }

        public ToDoItem GetWithProjectById(int id)
        {
            return TaskListDbContext.ToDoItems
                .Include(t => t.Project)
                .SingleOrDefault(t => t.ToDoItemId == id);
        }
    }
}
