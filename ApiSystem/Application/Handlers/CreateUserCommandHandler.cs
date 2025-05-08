using ApiSystem.Application.DTOs;
using ApiSystem.Domain;
using ApiSystem.Infrastructure;
using ApiSystem.Infrastructure.Command;
using MediatR;

namespace ApiSystem.Application.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly ApplicationDbContext _dbContext;

        public CreateUserCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        { 

            var user = new User
            {
                name = request.name,
                username = request.username,
                password = request.password
            };
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new UserDto
            {
                id = user.id,
                name = user.name,
                username = user.username,
                password = user.password
            };
        }
    }
}
