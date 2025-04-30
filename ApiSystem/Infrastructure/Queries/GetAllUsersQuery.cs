using ApiSystem.Application.DTOs;
using MediatR;

namespace ApiSystem.Infrastructure.Queries
{
    public record GetAllUsersQuery : IRequest<IEnumerable<UserDto>>;
}
