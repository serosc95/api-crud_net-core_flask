namespace Store.Dominio {
	public class Cliente {
		public Guid clienteId { get; set; }

		public string? nombre { get; set; }

		public string? nacionalidad { get; set; }

		public string? ciudad { get; set; }

		public string? email { get; set; }
	}
}
