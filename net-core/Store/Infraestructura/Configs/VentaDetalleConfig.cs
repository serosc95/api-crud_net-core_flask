using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Dominio;

namespace Store.Infraestructura.Configs {
	class VentaDetalleConfig : IEntityTypeConfiguration<VentaDetalle> {
		public void Configure(EntityTypeBuilder<VentaDetalle> builder) {
			builder.ToTable("VentasDetalles");
			builder.HasKey(c => new { c.productoId, c.ventaId });

			builder
				.HasOne(detalle => detalle.Producto)
				.WithMany(producto => producto.VentaDetalles);

			builder
				.HasOne(detalle => detalle.Venta)
				.WithMany(venta => venta.VentaDetalles);


		}
	}
}
