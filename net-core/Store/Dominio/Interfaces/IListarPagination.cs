namespace Store.Dominio.Interfaces {
	public interface IListarPagination<TEntidad> {
		List<TEntidad> ListarPagination(int pagination);
	}
}
