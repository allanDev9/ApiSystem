using ApiSystem.Application.DTOs;
using ApiSystem.Infrastructure;
using ApiSystem.Infrastructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiSystem.Application.Handlers
{
    public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsernameQuery, UserDto>
    {
        readonly ApplicationDbContext _dbContext;

        public GetUserByUsernameQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserDto> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .Where(u => u.username == request.Username)
                .Select(u => new UserDto
                {
                    id = u.id,
                    name = u.name,
                    username = u.username,
                    password = u.password
                })
                .FirstOrDefaultAsync(cancellationToken);

            if(user == null)
            {
                return null;
            }

            return user;            
        }
    }
}
