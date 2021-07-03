using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskList.Api.Resources
{
    public class SaveToDoItemResource
    {
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsFromInbox { get; set; }
        public int UserId { get; set; }
        public int? ProjectId { get; set; }
    }
}
