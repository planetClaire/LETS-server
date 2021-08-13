using Microsoft.EntityFrameworkCore;
using Server.Entities;

namespace Server
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Members { get; set; } = default!;
    }
}