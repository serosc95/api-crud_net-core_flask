namespace Store.Dominio.Interfaces {
	public interface IEliminar<TEntidadID> {
		void Eliminar(TEntidadID entidadId);
	}
}
