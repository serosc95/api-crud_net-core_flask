using Microsoft.AspNetCore.Mvc;
using Store.Dominio;
using Store.Aplicaciones.Servicios;
using Store.Infraestructura.Contextos;
using Store.Infraestructura.Repositorios;

namespace Store.Infraestructura.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class ProductoController : ControllerBase {

		ProductoServicio CrearServicio() {
			VentaContexto db = new VentaContexto();
			ProductoRepositorio repo = new ProductoRepositorio(db);
			ProductoServicio servicio = new ProductoServicio(repo);
			return servicio;
		}
		
		//GET api/producto
		[HttpGet]
		public ActionResult<List<Producto>> Get() {
			var servicio = CrearServicio();
			return Ok(servicio.Listar());
		}

		//GET api/producto/{id}
		[HttpGet("{id}")]
		public ActionResult<Producto> Get(Guid id) {
			var servicio = CrearServicio();
			return Ok(servicio.SeleccionarPorID(id));
			
		}

		//POST api/producto
		[HttpPost]
		public ActionResult Post([FromBody] Producto producto) {
			var servicio = CrearServicio();
			servicio.Agregar(producto);
			return Ok("Se creo el producto correctamente");
		}

		//PUT api/producto/{id}
		[HttpPut("{id}")]
		public ActionResult Put(Guid id, [FromBody] Producto producto) {
			var servicio = CrearServicio();
			producto.productoId = id;
			servicio.Editar(producto);
			return Ok(string.Format("Se edito el producto {0:d} correctamente", id));
		}

		//DELETE api/producto/{id}
		[HttpDelete("{id}")]
		public ActionResult Delete(Guid id) {
			var servicio = CrearServicio();
			servicio.Eliminar(id);
			return Ok(string.Format("Se elimino el producto {0:d} correctamente", id));
		}
	}
}
