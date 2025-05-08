using ApiSystem.Application.DTOs;
using MediatR;

namespace ApiSystem.Infrastructure.Queries
{
    public record GetUserByUsernameQuery : IRequest<UserDto>
    {
        public string Username { get; }

        public GetUserByUsernameQuery(string username)
        {
            Username = username;
        }
    }
}
