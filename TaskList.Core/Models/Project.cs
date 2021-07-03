using System.Collections.Generic;

namespace TaskList.Core.Models
{
    public class Project
    {
        public Project()
        {
            ToDoItems = new List<ToDoItem>();
        }

        public int ProjectId { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }

        public ICollection<ToDoItem> ToDoItems { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
