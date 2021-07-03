using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskList.Core.Models;
using TaskList.Core.Repositories;

namespace TaskList.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(TaskListDbContext context)
            : base(context) { }

        public User GetByCredentials(string login, string password)
        {
            return TaskListDbContext.Users.SingleOrDefault(u => u.Login == login && u.Password == password);
        }
    }
}
