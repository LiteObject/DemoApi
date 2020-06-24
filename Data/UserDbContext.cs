namespace DemoApi.Data
{
    using DemoApi.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public class UserDbContext : DbContext
    {
        public DbSet<User> Blogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DemoApi-local;Trusted_Connection=True;MultipleActiveResultSets=true");
    }
}
