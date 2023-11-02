using AplicacionDatos.Models;
using AplicacionDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class CalificacionController : ControllerBase
    {
        private CalificacionesDAO calificacionesDAO = new CalificacionesDAO();

        [HttpGet("calificaciones")]
        public List<Calificacion> get(int idMatricula)
        {
            return calificacionesDAO.seleccionar(idMatricula);
        }

        [HttpPost("calificacion")]
        public bool agregarCalificacion([FromBody] Calificacion calificacion)
        {
            return calificacionesDAO.agregarCalificacion(calificacion);
        }

        [HttpDelete ("calificacion")]
        public bool eliminarCalificacion(int id)
        {
            return calificacionesDAO.eliminarCalificacion (id);
        }
    }
}
