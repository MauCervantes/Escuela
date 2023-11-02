using AplicacionDatos.Models;
using AplicacionDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class AsignaturaController : ControllerBase
    {
        private MateriaDAO materiaDAO = new MateriaDAO();

        //EndPoint para obtener lista de materias 
        [HttpGet("asignatura")]
        public List<Asignatura> getAsignaturas()
        {
            return materiaDAO.seleccionarAsignaturas();
        }

        //EndPoint para obtener asignatura por id
        [HttpGet("asignaturaID")]
        public Asignatura getAsignatura(int id)
        {
            return materiaDAO.seleccionar(id);
        }

        //EndPoint para agregar nueva asignatura
        [HttpPost("asignatura")]
        public bool agregarMateria([FromBody] string nombre, int creditos, string profesor)
        {
            return materiaDAO.insertarMateria(nombre, creditos, profesor);
        }

        //EndPoint para actualizar asignatura por id
        [HttpPut("asignatura")]
        public bool modificarAsignatura(int id, string nombre, int creditos, string profesor)
        {
            return materiaDAO.actualizarAsignatura(id, nombre, creditos, profesor);
        }
    }
}
