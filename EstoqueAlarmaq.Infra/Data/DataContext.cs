using EstoqueAlarmaq.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EstoqueAlarmaq.Infra.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductObject> ProductsObjects { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<OrderService> OrderServices { get; set; }
        //public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var home = "Integrated Security=SSPI;Persist Security Info=False;" +
                "User ID=sa;Initial Catalog=dbEstoque;Data Source=DESKTOP-FELIPE";

            optionsBuilder.UseSqlServer(home);

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configura uma chave primária para IdentityUserLogin<string>
            builder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });
        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<Product>()
        //    //    .HasOne(p => p.OrderServices)
        //    //    .WithMany(b => b.Products)
        //    //    .HasForeignKey(p => p.OrderServicesId);
        //}

    }
}
