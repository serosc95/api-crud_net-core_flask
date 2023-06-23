using Store.Dominio;
using Store.Dominio.Interfaces.Repositorios;
using Store.Infraestructura.Contextos;

namespace Store.Infraestructura.Repositorios {
	public class VentaRepositorio : IRepositorioMovimiento<Venta, Guid> {

		private VentaContexto db;

		public VentaRepositorio(VentaContexto _db) {
			db = _db;
		}

		public Venta Agregar(Venta entidad) {
			entidad.ventaId = Guid.NewGuid();
			db.Ventas.Add(entidad);
			return entidad;
		}

		public void Anular(Guid entidadId) {
			var ventaSeleccionada = db.Ventas.Where(c => c.ventaId == entidadId).FirstOrDefault();
			if (ventaSeleccionada == null)
				throw new NullReferenceException("No existe la venta");

			ventaSeleccionada.anulado = true;
			db.Entry(ventaSeleccionada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		}

		public void GuardarTodosLosCambios() {
			db.SaveChanges();
		}

		public List<Venta> Listar() {
			return db.Ventas.ToList();
		}

		public Venta SeleccionarPorID(Guid entidadId) {
			var ventaSeleccionada = db.Ventas.Where(c => c.ventaId == entidadId).FirstOrDefault();
			return ventaSeleccionada;
		}
	}
}
