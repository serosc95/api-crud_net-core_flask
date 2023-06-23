namespace Store.Dominio {
	public class Venta {
		public Guid ventaId { get; set; }

		public DateTime fecha { get; set; }

		public decimal total { get; set; }

		public Boolean anulado { get; set; } = false;

		public List<VentaDetalle>? VentaDetalles { get; set; }
	}
}
