using System;
using System.Collections.Generic;
using System.Text;
using TaskList.Core.Models;

namespace TaskList.Core.Services
{
    public interface IUserService
    {
        void Create(User user);
        void Delete(User user);
        void Update(User user);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User GetByCredentials(string login, string password);
    }
}
