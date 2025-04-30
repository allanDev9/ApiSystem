using ApiSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace ApiSystem.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

    }
}
