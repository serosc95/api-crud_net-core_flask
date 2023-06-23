using Store.Dominio.Interfaces;

namespace Store.Aplicaciones.Interfaces {
	interface IServicioBase<TEntidad, TEntidadID>
		: IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>{
	}
}
