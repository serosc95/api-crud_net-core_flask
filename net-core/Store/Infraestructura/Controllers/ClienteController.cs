using Microsoft.AspNetCore.Mvc;
using Store.Dominio;
using Store.Aplicaciones.Servicios;
using Store.Infraestructura.Contextos;
using Store.Infraestructura.Repositorios;

namespace Store.Infraestructura.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class ClienteController : ControllerBase {

		ClienteServicio CrearServicio() {
			VentaContexto db = new VentaContexto();
			ClienteRepositorio repo = new ClienteRepositorio(db);
			ClienteServicio servicio = new ClienteServicio(repo);
			return servicio;
		}
		
		//GET api/cliente
		[HttpGet("{pagination}")]
		public ActionResult<List<Cliente>> Get(int pagination) {
			var servicio = CrearServicio();
			return Ok(servicio.ListarPagination(pagination));
		}

		//POST api/cliente
		[HttpPost]
		public ActionResult Post([FromBody] Cliente cliente) {
			var servicio = CrearServicio();
			servicio.Agregar(cliente);
			return Ok("Se creo el cliente correctamente");
		}

		//PUT api/cliente/{id}
		[HttpPut("{id}")]
		public ActionResult Put(Guid id, [FromBody] Cliente cliente) {
			var servicio = CrearServicio();
			cliente.clienteId = id;
			servicio.Editar(cliente);
			return Ok(string.Format("Se edito el cliente {0:d} correctamente", id));
		}

		//DELETE api/cliente/{id}
		[HttpDelete("{id}")]
		public ActionResult Delete(Guid id) {
			var servicio = CrearServicio();
			servicio.Eliminar(id);
			return Ok(string.Format("Se elimino el cliente {0:d} correctamente", id));
		}
	}
}
