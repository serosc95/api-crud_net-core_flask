﻿using Store.Dominio.Interfaces;

namespace Store.Aplicaciones.Interfaces {
	public interface IServicioMovimiento<TEntidad, TEntidadID>
		: IAgregar<TEntidad>, IListar<TEntidad, TEntidadID>{
		void Anular(TEntidadID entidadId);
	}
}
