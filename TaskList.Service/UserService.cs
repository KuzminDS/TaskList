using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using TaskList.Core;
using TaskList.Core.Models;
using TaskList.Core.Services;

namespace TaskList.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(User user)
        {
            user.Password = new PasswordHasher<object>().HashPassword(null, user.Password);
            _unitOfWork.Users.Add(user);
            _unitOfWork.Commit();
        }

        public void Delete(User user)
        {
            _unitOfWork.Users.Delete(user);
            _unitOfWork.Commit();
        }

        public IEnumerable<User> GetAll()
        {
            return _unitOfWork.Users.GetAll();
        }

        public User GetByCredentials(string login, string password)
        {
            var user = _unitOfWork.Users.GetMany(u => u.Login == login).FirstOrDefault();

            var passwordVerificationResult = new PasswordHasher<object>().VerifyHashedPassword(null, user.Password, password);

            switch (passwordVerificationResult)
            {
                case PasswordVerificationResult.Success:
                    return user;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public User GetById(int id)
        {
            return _unitOfWork.Users.GetById(id);
        }

        public void Update(User user)
        {
            user.Password = new PasswordHasher<object>().HashPassword(null, user.Password);
            _unitOfWork.Users.Update(user);
            _unitOfWork.Commit();
        }
    }
}
