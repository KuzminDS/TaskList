using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskList.Api.Resources;
using TaskList.Api.Validators;
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
        public ActionResult<IEnumerable<ToDoItemResource>> GetAllToDoItems()
        {
            var toDoItems = _toDoItemService.GetAllWithProject();
            var toDoItemsResources = _mapper.Map<IEnumerable<ToDoItem>, IEnumerable<ToDoItemResource>>(toDoItems);
            return Ok(toDoItemsResources);
        }

        [HttpGet("{id}")]
        public ActionResult<ToDoItemResource> GetById(int id)
        {
            var toDoItem = _toDoItemService.GetToDoItem(id);
            var toDoItemsResource = _mapper.Map<ToDoItem, ToDoItemResource>(toDoItem);
            return Ok(toDoItemsResource);
        }

        [HttpPost("")]
        public ActionResult<ToDoItemResource> CreateToDoItem([FromBody] SaveToDoItemResource saveToDoItemResource)
        {
            var validator = new SaveToDoItemResourceValidator();
            var validationResult = validator.Validate(saveToDoItemResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var toDoItemToCreate = _mapper.Map<SaveToDoItemResource, ToDoItem>(saveToDoItemResource);

            _toDoItemService.CreateToDoItem(toDoItemToCreate);

            var toDoItem = _toDoItemService.GetToDoItem(toDoItemToCreate.ToDoItemId);
            var toDoItemResource = _mapper.Map<ToDoItem, ToDoItemResource>(toDoItem);

            return Ok(toDoItemResource);
        }

        [HttpPut("{id}")]
        public ActionResult<ToDoItemResource> UpdateToDoItem(int id, [FromBody] SaveToDoItemResource saveToDoItemResource)
        {
            var validator = new SaveToDoItemResourceValidator();
            var validationResult = validator.Validate(saveToDoItemResource);

            bool requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);

            var toDoItemToBeUpdate = _toDoItemService.GetToDoItem(id);

            if (toDoItemToBeUpdate == null)
                return NotFound();

            var toDoItem = _mapper.Map<SaveToDoItemResource, ToDoItem>(saveToDoItemResource);
            _toDoItemService.UpdateToDoItem(toDoItemToBeUpdate, toDoItem);

            var updatedToDoItem = _toDoItemService.GetToDoItem(id);
            var updatedToDoItemResource = _mapper.Map<ToDoItem, ToDoItemResource>(updatedToDoItem);
            return Ok(updatedToDoItemResource);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteToDoItem(int id)
        {
            if (id == 0)
                return BadRequest();

            var toDoItem = _toDoItemService.GetToDoItem(id);

            if (toDoItem == null)
                return NotFound();

            _toDoItemService.DeleteToDoItem(toDoItem);

            return NoContent();
        }
    }
}
