using ExampleDeployment.API.Entity;
using Microsoft.EntityFrameworkCore;

namespace ExampleDeployment.API
{
    public class EDContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public EDContext(DbContextOptions<EDContext> options)
        : base(options)
        {
        }
    }
}
