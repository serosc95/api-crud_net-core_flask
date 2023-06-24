namespace Store.Dominio.Interfaces.Repositorios {
	public interface IRepositorioBase<TEntidad, TEntidadID>
		: IListarPagination<TEntidad>, IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>, ITransaccion {
	}
}
