using EstoqueAlarmaq.Domain;
using Microsoft.EntityFrameworkCore;

namespace EstoqueAlarmaq.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<OrderService> OrderServices { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var home = "Integrated Security=SSPI;Persist Security Info=False;" +
                "User ID=sa;Initial Catalog=dbEstoque;Data Source=DESKTOP-FELIPE";
            var work = "Integrated Security=SSPI;Persist Security Info=False;" +
                "User ID=sa;Initial Catalog=dbEstoque;Data Source=A002";

            optionsBuilder.UseSqlServer(work);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.OrderServices)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.OrderServicesId);
        }

    }
}
