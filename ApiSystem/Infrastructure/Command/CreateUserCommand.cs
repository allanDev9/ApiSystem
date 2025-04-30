using ApiSystem.Application.DTOs;
using MediatR;

namespace ApiSystem.Infrastructure.Command
{
    public record CreateUserCommand(int id, string name, string username, string password) : IRequest<UserDto>;
}
