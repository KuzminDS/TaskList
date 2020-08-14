using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList.Core.Repositories
{
    public interface IUnitOfWork
    {
        IToDoItemRepository ToDoItems { get; }
        IProjectRepository Projects { get; }
        int Commit();
    }
}
