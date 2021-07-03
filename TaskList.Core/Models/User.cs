using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList.Core.Models
{
    public class User
    {
        public User()
        {
            Projects = new List<Project>();
            ToDoItems = new List<ToDoItem>();
        }

        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Project> Projects { get; set; }
        public ICollection<ToDoItem> ToDoItems { get; set; }
    }
}
