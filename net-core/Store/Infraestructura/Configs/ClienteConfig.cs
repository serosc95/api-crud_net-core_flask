using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Dominio;

namespace Store.Infraestructura.Configs {
	class ClienteConfig : IEntityTypeConfiguration<Cliente> {
		public void Configure(EntityTypeBuilder<Cliente> builder) {
			builder.ToTable("Cliente");
			builder.HasKey(c => c.clienteId);
		}
	}
}
