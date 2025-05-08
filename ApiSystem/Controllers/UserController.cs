using ApiSystem.Application.DTOs;
using ApiSystem.Infrastructure.Command;
using ApiSystem.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            return await _mediator.Send(new GetAllUsersQuery());
        }
        [HttpGet("{username}")]
        public async Task<ActionResult<UserDto>> GetById(string username)
        {
            var user = await _mediator.Send(new GetUserByUsernameQuery (username));

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        [HttpPost]
        public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserCommand command)
        {
            var createdUser = await _mediator.Send(command);

            if (createdUser == null)
            {
                return BadRequest("User creation failed.");
            }

            return CreatedAtAction(nameof(GetById), new { createdUser.id }, createdUser);
        }
        [HttpPost("login")] 
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
        {
            var query = new LoginUserQuery(loginDto.username, loginDto.password);
            var user = await _mediator.Send(query);

            if(user == null)
            {
                return Unauthorized(new { message = "Credenciales invalidas"});
            }

            return Ok(new { message = "Inicio de sesión exitoso", user });

        } 

    }

}
