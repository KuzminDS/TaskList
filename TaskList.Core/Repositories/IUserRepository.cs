using System;
using System.Collections.Generic;
using System.Text;
using TaskList.Core.Models;

namespace TaskList.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByCredentials(string login, string password);
    }
}
