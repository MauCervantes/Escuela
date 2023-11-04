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
        public bool agregarMateria([FromBody] Asignatura asig)
        {
            return materiaDAO.insertarMateria(asig.Nombre, asig.Creditos, asig.Profesor);
        }

        //EndPoint para actualizar asignatura por id
        [HttpPut("asignatura")]
        public bool modificarAsignatura([FromBody] Asignatura asig)
        {
            return materiaDAO.actualizarAsignatura(asig.Id, asig.Nombre, asig.Creditos, asig.Profesor);
        }
    }
}
