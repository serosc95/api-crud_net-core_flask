using Microsoft.AspNetCore.Mvc;
using Store.Dominio;
using Store.Aplicaciones.Servicios;
using Store.Infraestructura.Contextos;
using Store.Infraestructura.Repositorios;

namespace Store.Infraestructura.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class VentaController : ControllerBase {

		VentaServicio CrearServicio() {
			VentaContexto db = new VentaContexto();
			VentaRepositorio repoVenta = new VentaRepositorio(db);
			ProductoRepositorio repoProducto = new ProductoRepositorio(db);
			VentaDetalleRepositorio repoDetalle = new VentaDetalleRepositorio(db);
			VentaServicio servicio = new VentaServicio(repoVenta, repoProducto, repoDetalle);
			return servicio;
		}
		//GET api/venta
		[HttpGet]
		public ActionResult<List<Venta>> Get() {
			var servicio = CrearServicio();
			return Ok(servicio.Listar());
		}

		//GET api/venta/{id}
		[HttpGet("{id}")]
		public ActionResult<Venta> Get(Guid id) {
			var servicio = CrearServicio();
			return Ok(servicio.SeleccionarPorID(id));
		}

		//POST api/venta
		[HttpPost]
		public ActionResult Post([FromBody] Venta venta) {
			var servicio = CrearServicio();
			servicio.Agregar(venta);
			return Ok("Se creo la venta correctamente");
		}

		//PUT api/venta/{id}
		[HttpPut("{id}")]
		public ActionResult Put(Guid id) {
			var servicio = CrearServicio();
			servicio.Anular(id);
			return Ok(string.Format("Se anulo la venta {0:d} correctamente", id));
		}
	}
}
