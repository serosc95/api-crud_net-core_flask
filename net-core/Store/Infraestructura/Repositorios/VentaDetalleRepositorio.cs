using Store.Dominio;
using Store.Dominio.Interfaces.Repositorios;
using Store.Infraestructura.Contextos;

namespace Store.Infraestructura.Repositorios {
	public class VentaDetalleRepositorio : IRepositorioDetalle<VentaDetalle, Guid> {

		private VentaContexto db;

		public VentaDetalleRepositorio(VentaContexto _db) {
			db = _db;
		}

		public VentaDetalle Agregar(VentaDetalle entidad) {
			db.VentaDetalles.Add(entidad);
			return entidad;
		}

		public void GuardarTodosLosCambios() {
			db.SaveChanges();
		}
	}
}
