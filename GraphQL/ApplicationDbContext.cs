using Microsoft.EntityFrameworkCore;
using GraphQL.Entities;

namespace GraphQL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().HasOne<Member>("Seller").WithMany(m => m.Sales);
            modelBuilder.Entity<Transaction>().HasOne<Member>("Buyer").WithMany(m => m.Purchases);
        }

        public DbSet<Locality> Localities { get; set; } = default!;
        public DbSet<Member> Members { get; set; } = default!;
        public DbSet<MemberType> MemberTypes { get; set; } = default!;
        public DbSet<Notice> Notices { get; set; } = default!;
        public DbSet<NoticeType> NoticeTypes { get; set; } = default!;
        public DbSet<Transaction> Transactions { get; set; } = default!;
        public DbSet<TransactionType> TransactionTypes { get; set; } = default!;

    }
}