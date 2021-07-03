using System;
using System.Collections.Generic;
using System.Text;
using TaskList.Core;
using TaskList.Core.Repositories;
using TaskList.Data.Repositories;

namespace TaskList.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TaskListDbContext _context;
        private ToDoItemRepository _itemRepository;
        private ProjectRepository _projectRepository;
        private UserRepository _userRepository;

        public UnitOfWork(TaskListDbContext context)
        {
            _context = context;
        }

        public IToDoItemRepository ToDoItems =>
            _itemRepository ??= new ToDoItemRepository(_context);

        public IProjectRepository Projects =>
            _projectRepository ??= new ProjectRepository(_context);

        public IUserRepository Users =>
            _userRepository ??= new UserRepository(_context);

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
