using Core.Entidades;
using Core.Interfaces.Repositorios;
using Core.Interfaces.Servicios;
using Core.Respuestas;
using Microsoft.AspNetCore.Mvc;
using Web.Helpers;

namespace Web.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamoController : ControllerBase
    {
        private IPrestamoServicio _servicio;
		public PrestamoController(IPrestamoServicio servicio)
		{
			_servicio = servicio;
		}

        /// <summary>
        /// Creación de un préstamo
        /// </summary>
        /// <param name="prestamo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Respuesta<Prestamo>>> Post([FromBody] Prestamo prestamo) {
            try
            {
                var respuesta = await _servicio.Agregar(prestamo);
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Respuesta<IEnumerable<Prestamo>>>> Get(int id) {
            try
            {
                var respuesta = await _servicio.ConsultarPrestamosDeCliente(id);
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

    }
}