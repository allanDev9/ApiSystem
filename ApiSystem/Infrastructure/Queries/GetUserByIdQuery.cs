using ApiSystem.Application.DTOs;
using MediatR;

namespace ApiSystem.Infrastructure.Queries
{
    public record GetUserByIdQuery(int id) : IRequest<UserDto>;
}
