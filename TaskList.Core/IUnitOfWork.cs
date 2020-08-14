using System;
using System.Collections.Generic;
using System.Text;
using TaskList.Core.Repositories;

namespace TaskList.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IToDoItemRepository ToDoItems { get; }
        IProjectRepository Projects { get; }
        int Commit();
    }
}
