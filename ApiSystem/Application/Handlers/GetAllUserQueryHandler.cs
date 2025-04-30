using ApiSystem.Application.DTOs;
using ApiSystem.Infrastructure;
using ApiSystem.Infrastructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiSystem.Application.Handlers
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetAllUserQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _dbContext.Users.Select(u => new UserDto
            {
                id = u.id,
                name = u.name,
                username = u.username,
                password = u.password
            })
               .ToListAsync(cancellationToken);

            return users;
        }
    }
}
