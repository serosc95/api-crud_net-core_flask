﻿namespace Store.Dominio {
	public class Producto {
		public Guid productoId { get; set; }

		public string? nombre { get; set; }

		public string? descripcion { get; set; }

		public decimal costo { get; set; }

		public decimal precio { get; set; }

		public int cantidadEnStock { get; set; }

		public List<VentaDetalle>? VentaDetalles { get; set; }
	}
}
