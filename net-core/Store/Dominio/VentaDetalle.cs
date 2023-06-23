﻿namespace Store.Dominio {
	public class VentaDetalle {
		public Guid productoId { get; set; }

		public Guid ventaId { get; set; }

		public decimal costoUnitario { get; set; }

		public decimal precioUnitario { get; set; }

		public int cantidadVendida { get; set; }

		public decimal total { get; set; }

		public Producto? Producto { get; set; }

		public Venta? Venta { get; set; }
	}
}
