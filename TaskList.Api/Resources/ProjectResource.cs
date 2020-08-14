using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskList.Api.Resources
{
    public class ProjectResource
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}
