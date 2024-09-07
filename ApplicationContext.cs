using Microsoft.EntityFrameworkCore;

namespace WPF1
{
    internal class ApplicationContext : DbContext
    {
        internal DbSet<User> Users { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Users;Trusted_Connection=True;TrustServerCertificate=true;");
        }
    }
}
