using Microsoft.EntityFrameworkCore;
using Store.Dominio;
using Store.Infraestructura.Configs;

namespace Store.Infraestructura.Contextos {
	public class VentaContexto : DbContext {

		public DbSet<Cliente>? Clientes { get; set; }

		public DbSet<Producto>? Productos { get; set; }

		public DbSet<Venta>? Ventas { get; set; }

		public DbSet<VentaDetalle>? VentaDetalles { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options) {
			var dbConect = "server=localhost; port=3306; database=store; user=root; password=";
			options.UseMySql(dbConect, ServerVersion.AutoDetect(dbConect));
		}

		protected override void OnModelCreating(ModelBuilder builder) {
			base.OnModelCreating(builder);

			builder.ApplyConfiguration(new ClienteConfig());
			builder.ApplyConfiguration(new ProductoConfig());
			builder.ApplyConfiguration(new VentaConfig());
			builder.ApplyConfiguration(new VentaDetalleConfig());
		}
	}
}
