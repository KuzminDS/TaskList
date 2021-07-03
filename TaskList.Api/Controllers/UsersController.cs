using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskList.Api.Resources;
using TaskList.Api.Validators;
using TaskList.Core.Models;
using TaskList.Core.Services;

namespace TaskList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<UserResource>> GetAllUsers()
        {
            var users = _userService.GetAll();
            var usersResource = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return Ok(usersResource);
        }

        [HttpGet("{id}")]
        public ActionResult<UserResource> GetById(int id)
        {
            var user = _userService.GetById(id);
            var userResource = _mapper.Map<User, UserResource>(user);
            return Ok(userResource);
        }

        [HttpGet("(login, password)")]
        public ActionResult<UserResource> GetById(string login, string password)
        {
            var user = _userService.GetByCredentials(login, password);
            var userResource = _mapper.Map<User, UserResource>(user);
            return Ok(userResource);
        }

        [HttpPost("")]
        public ActionResult<UserResource> CreateUser([FromBody] SaveUserResource saveUserResource)
        {
            var validator = new SaveUserResourceValidator();
            var validationResult = validator.Validate(saveUserResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var userToCreate = _mapper.Map<SaveUserResource, User>(saveUserResource);

            _userService.Create(userToCreate);

            var user = _userService.GetById(userToCreate.UserId);
            var userResource = _mapper.Map<User, UserResource>(user);

            return Ok(userResource);
        }

        [HttpPut("(id)")]
        public ActionResult<UserResource> UpdateUser(int id, [FromBody] SaveUserResource saveUserResource)
        {
            var validator = new SaveUserResourceValidator();
            var validationResult = validator.Validate(saveUserResource);

            bool requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);

            var userToBeUpdate = _userService.GetById(id);

            if (userToBeUpdate == null)
                return NotFound();

            var user = _mapper.Map<SaveUserResource, User>(saveUserResource);
            user.UserId = id;
            _userService.Update(user);

            var updatedUser = _userService.GetById(id);
            var updatedUserResource = _mapper.Map<User, UserResource>(updatedUser);
            return Ok(updatedUserResource);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (id == 0)
                return BadRequest();

            var user = _userService.GetById(id);

            if (user == null)
                return NotFound();

            _userService.Delete(user);

            return NoContent();
        }
    }
}