﻿namespace Store.Dominio.Interfaces {
	public interface IAgregar<TEntidad> {
		TEntidad Agregar(TEntidad entidad);
	}
}
