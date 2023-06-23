using Store.Dominio;
using Store.Dominio.Interfaces.Repositorios;
using Store.Aplicaciones.Interfaces;

namespace Store.Aplicaciones.Servicios {
	public class VentaServicio : IServicioMovimiento<Venta, Guid> {

		IRepositorioMovimiento<Venta, Guid> repoVenta;
		IRepositorioBase<Producto, Guid> repoProducto;
		IRepositorioDetalle<VentaDetalle, Guid> repoDetalle;

		public VentaServicio(
			IRepositorioMovimiento<Venta, Guid> _repoVenta,
			IRepositorioBase<Producto, Guid> _repoProducto,
			IRepositorioDetalle<VentaDetalle, Guid> _repoDetalle
		) {
			repoVenta = _repoVenta;
			repoProducto = _repoProducto;
			repoDetalle = _repoDetalle;
		}

		public Venta Agregar(Venta entidad) {
			if (entidad is null || entidad.VentaDetalles is null)
				throw new ArgumentNullException("Se requiere los datos de la venta a agregar");

			var ventaAgregada = repoVenta.Agregar(entidad);
			
			entidad.VentaDetalles.ForEach(detalle => {
				var productoSeleccionado = repoProducto.SeleccionarPorID(detalle.productoId);
				if (productoSeleccionado == null)
					throw new NullReferenceException("No existe el producto");

				
				detalle.costoUnitario = productoSeleccionado.costo;
				detalle.precioUnitario = productoSeleccionado.precio;
				detalle.total = detalle.precioUnitario * detalle.cantidadVendida;
				repoDetalle.Agregar(detalle);

				productoSeleccionado.cantidadEnStock -= detalle.cantidadVendida;
				repoProducto.Editar(productoSeleccionado);
				
				entidad.total += detalle.total;
			});

			repoVenta.GuardarTodosLosCambios();
			return entidad;
		}

		public void Anular(Guid entidadId) {
			repoVenta.Anular(entidadId);
			repoVenta.GuardarTodosLosCambios();
		}

		public List<Venta> Listar() {
			return repoVenta.Listar();
		}

		public Venta SeleccionarPorID(Guid entidadId) {
			return repoVenta.SeleccionarPorID(entidadId);
		}
	}
}
