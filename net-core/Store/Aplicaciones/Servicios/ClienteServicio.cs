using Store.Dominio;
using Store.Dominio.Interfaces.Repositorios;
using Store.Aplicaciones.Interfaces;

namespace Store.Aplicaciones.Servicios {
	public class ClienteServicio : IServicioBase<Cliente, Guid> {

		private readonly IRepositorioBase<Cliente, Guid> repoCliente;

		public ClienteServicio(IRepositorioBase<Cliente, Guid> _repoCliente) {
			repoCliente = _repoCliente;
		}

		public Cliente Agregar(Cliente entidad) {
			if (entidad is null)
				throw new ArgumentNullException("Se requiere los datos del cliente a agregar");

			var resultCliente = repoCliente.Agregar(entidad);
			repoCliente.GuardarTodosLosCambios();
			return resultCliente;
		}

		public void Editar(Cliente entidad) {
			if (entidad is null)
				throw new ArgumentNullException("Se requiere los campos del cliente a editar");

			repoCliente.Editar(entidad);
			repoCliente.GuardarTodosLosCambios();

		}

		public void Eliminar(Guid entidadId) {
			repoCliente.Eliminar(entidadId);
			repoCliente.GuardarTodosLosCambios();
		}

		public List<Cliente> Listar() {
			return repoCliente.Listar();
		}

		public Cliente SeleccionarPorID(Guid entidadId) {
			return repoCliente.SeleccionarPorID(entidadId);
		}
	}
}
