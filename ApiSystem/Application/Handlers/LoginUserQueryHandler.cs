using ApiSystem.Application.DTOs;
using ApiSystem.Infrastructure;
using ApiSystem.Infrastructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiSystem.Application.Handlers
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, UserDto>
    {
        private readonly ApplicationDbContext _dbContext;

        public LoginUserQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<UserDto> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .Where(u => u.username == request.Username)
                .FirstOrDefaultAsync(cancellationToken);

            if (user == null)
            {
                return null;
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.password);

            if (!isPasswordValid)
            {
                return null;
            }

            return new UserDto
            {
                id = user.id,
                name = user.name,
                username = user.username,
                password = ""
            };
        }
    }
}
