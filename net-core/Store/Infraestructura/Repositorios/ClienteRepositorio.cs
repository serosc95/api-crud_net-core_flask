using Store.Dominio;
using Store.Dominio.Interfaces.Repositorios;
using Store.Infraestructura.Contextos;

namespace Store.Infraestructura.Repositorios {
	public class ClienteRepositorio : IRepositorioBase<Cliente, Guid> {

		private VentaContexto db;

		public ClienteRepositorio(VentaContexto _db) {
			db = _db;
		}

		public Cliente Agregar(Cliente entidad) {
			entidad.clienteId = Guid.NewGuid();
			db.Clientes.Add(entidad);
			return entidad;
		}

		public void Editar(Cliente entidad) {
			var clienteSeleccionado = db.Clientes.Where(c => c.clienteId == entidad.clienteId).FirstOrDefault();
			if (clienteSeleccionado != null) {
				clienteSeleccionado.nombre = entidad.nombre;
				clienteSeleccionado.nacionalidad = entidad.nacionalidad;
				clienteSeleccionado.ciudad = entidad.ciudad;
				clienteSeleccionado.email = entidad.email;

				db.Entry(clienteSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			}
		}

		public void Eliminar(Guid entidadId) {
			var clienteSeleccionado = db.Clientes.Where(c => c.clienteId == entidadId).FirstOrDefault();
			if (clienteSeleccionado != null) {
				db.Clientes.Remove(clienteSeleccionado);
			}
		}

		public void GuardarTodosLosCambios() {
			db.SaveChanges();
		}

		public List<Cliente> Listar() {
			return db.Clientes.ToList();
		}

		public Cliente SeleccionarPorID(Guid entidadId) {
			var clienteSeleccionado = db.Clientes.Where(c => c.clienteId == entidadId).FirstOrDefault();
			return clienteSeleccionado;
		}
	}
}
