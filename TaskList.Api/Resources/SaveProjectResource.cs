using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskList.Api.Resources
{
    public class SaveProjectResource
    {
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}
