using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskList.Api.Resources;
using TaskList.Core.Models;

namespace TaskList.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<ToDoItem, ToDoItemResource>();
            CreateMap<Project, ProjectResource>();

            // Resource to Domain
            CreateMap<ToDoItemResource, ToDoItem>();
            CreateMap<ProjectResource, Project>();

            CreateMap<SaveToDoItemResource, ToDoItem>();
            CreateMap<SaveProjectResource, Project>();
        }
    }
}
