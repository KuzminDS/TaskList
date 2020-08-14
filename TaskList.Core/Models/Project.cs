using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TaskList.Core.Models
{
    public class Project
    {
        public Project()
        {
            ToDoItems = new Collection<ToDoItem>();
        }

        public int ProjectId { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }

        public ICollection<ToDoItem> ToDoItems { get; set; }
    }
}
