using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskList.Api.Resources;
using TaskList.Core.Models;
using TaskList.Core.Services;

namespace TaskList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly IToDoItemService _toDoItemService;
        private readonly IMapper _mapper;

        public ToDoItemsController(IToDoItemService toDoItemService, IMapper mapper)
        {
            _toDoItemService = toDoItemService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<ToDoItem>> GetAllToDoItems()
        {
            var toDoItems = _toDoItemService.GetAllWithProject();
            var toDoItemsResources = _mapper.Map<IEnumerable<ToDoItem>, IEnumerable<ToDoItemResource>>(toDoItems);
            return Ok(toDoItemsResources);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<ToDoItem>> GetById(int id)
        {
            var toDoItem = _toDoItemService.GetToDoItem(id);
            var toDoItemsResource = _mapper.Map<ToDoItem, ToDoItemResource>(toDoItem);
            return Ok(toDoItemsResource);
        }

    }
}
