using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Dominio;

namespace Store.Infraestructura.Configs {
	class ProductoConfig : IEntityTypeConfiguration<Producto> {
		public void Configure(EntityTypeBuilder<Producto> builder) {
			builder.ToTable("Productos");
			builder.HasKey(c => c.productoId);

			builder
				.HasMany(producto => producto.VentaDetalles)
				.WithOne(detalle => detalle.Producto);
		}
	}
}
