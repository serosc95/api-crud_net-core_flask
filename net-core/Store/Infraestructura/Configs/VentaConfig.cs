using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Dominio;

namespace Store.Infraestructura.Configs {
	class VentaConfig : IEntityTypeConfiguration<Venta> {
		public void Configure(EntityTypeBuilder<Venta> builder) {
			builder.ToTable("Ventas");
			builder.HasKey(c => c.ventaId);

			builder
				.HasMany(venta => venta.VentaDetalles)
				.WithOne(detalle => detalle.Venta);
		}
	}
}
