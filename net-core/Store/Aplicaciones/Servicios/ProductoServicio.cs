using Store.Dominio;
using Store.Dominio.Interfaces.Repositorios;
using Store.Aplicaciones.Interfaces;

namespace Store.Aplicaciones.Servicios {
	public class ProductoServicio : IServicioBase<Producto, Guid> {

		private readonly IRepositorioBase<Producto, Guid> repoProducto;

		public ProductoServicio(IRepositorioBase<Producto, Guid> _repoProducto) {
			repoProducto = _repoProducto;
		}

		public Producto Agregar(Producto entidad) {
			if (entidad is null)
				throw new ArgumentNullException("Se requiere los datos del producto a agregar");

			var resultProducto = repoProducto.Agregar(entidad);
			repoProducto.GuardarTodosLosCambios();
			return resultProducto;
		}

		public void Editar(Producto entidad) {
			if (entidad is null)
				throw new ArgumentNullException("Se requiere los campos del producto a editar");

			repoProducto.Editar(entidad);
			repoProducto.GuardarTodosLosCambios();

		}

		public void Eliminar(Guid entidadId) {
			repoProducto.Eliminar(entidadId);
			repoProducto.GuardarTodosLosCambios();
		}

		public List<Producto> Listar() {
			return repoProducto.Listar();
		}

		public Producto SeleccionarPorID(Guid entidadId) {
			return repoProducto.SeleccionarPorID(entidadId);
		}
	}
}
