using ApiSystem.Application.DTOs;
using MediatR;

namespace ApiSystem.Infrastructure.Queries
{
    public record LoginUserQuery : IRequest<UserDto>
    {
        public string Username { get; }

        public string Password { get; }

        public LoginUserQuery(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
