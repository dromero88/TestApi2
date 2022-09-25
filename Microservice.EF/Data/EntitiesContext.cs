using Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Microservice.EF.Data
{
    public class EntitiesContext: DbContext
    {
        public EntitiesContext(DbContextOptions<EntitiesContext> options) : base(options)
        {
        }

        public DbSet<ItemVenta> ItemsVentas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemVenta>().ToTable(nameof(ItemVenta));

            modelBuilder.Entity<Producto>().ToTable(nameof(Producto));

            modelBuilder.Entity<Venta>().ToTable(nameof(Venta));
        }
    }
}
