using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Commands;
using SampleAPI.Domain;
using SampleAPI.Domain.Managers;
using SampleAPI.Queries;
using SampleAPI.ViewModels;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserBehavior _behavior;

        private readonly IUserQueries _queries;

        private readonly IMapper _mapper;

        public UsersController(IUserBehavior behavior, IUserQueries queries, IMapper mapper)
        {
            _behavior = behavior;
            _queries = queries;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<BasicUserViewModel>>> GetAllAsync()
        {
            return await _queries.FindAllAsync();
        }

        [HttpGet("{username}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BasicUserViewModel>> GetByUsernameAsync(string username)
        {
            var existingUser = await _queries.FindByUsernameAsync(username);
            if (existingUser == null)
            {
                return NotFound();
            }
            return existingUser;
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [Route("ValidateCredentiales/{username}")]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BasicUserViewModel>> ValidateCredentials(string username, LoginCommand loginCommand)
        {
            var existingUser = await _queries.FindByUsernameAsync(username);
            if (existingUser == null)
            {
                return NotFound();
            }
            if (existingUser.Password != loginCommand.Password)
            {
                return NotFound();
            }
            return existingUser;
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BasicUserViewModel>> CreateUserAsync(CreateUserCommand createUserCommand)
        {
            var user = _mapper.Map<User>(createUserCommand);
            await _behavior.CreateUserAsync(user);

            var userViewModel = await _queries.FindByUsernameAsync(user.Username);
            return userViewModel;
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPut("{username}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BasicUserViewModel>> UpdateUserAsync(string username, UpdateUserCommand updateUserCommand)
        {

            var existingUser = await _queries.FindByUsernameAsync(username);
            if (existingUser == null)
            {
                return NotFound();
            }

            var user = _mapper.Map<User>(existingUser);
            _mapper.Map(updateUserCommand, user);
            await _behavior.UpdateUserAsync(user);

            var userViewModel = await _queries.FindByUsernameAsync(user.Username);
            return userViewModel;
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpDelete("{username}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteUserAsync(string username)
        {
            var existingUser = await _queries.FindByUsernameAsync(username);
            if (existingUser == null)
            {
                return NotFound();
            }

            var user = _mapper.Map<User>(existingUser);

            await _behavior.DeleteUserAsync(user);
            return NoContent();
        }
    }
}
