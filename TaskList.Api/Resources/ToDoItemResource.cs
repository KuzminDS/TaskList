using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskList.Api.Resources
{
    public class ToDoItemResource
    {
        public int ToDoItemId { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsFromInbox { get; set; }
        public ProjectResource Project { get; set; }
        public UserResource User { get; set; }
    }
}
