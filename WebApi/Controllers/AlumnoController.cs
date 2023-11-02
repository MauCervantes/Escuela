using AplicacionDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AplicacionDatos.Models;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private AlumnoDAO alumnosDAO = new AlumnoDAO();

        /**
         * EndPoint para obtener **
         */

        [HttpGet("alumno")]
        public Alumno GetAlumno(int id)
        {
            return alumnosDAO.seleccionar(id);
        }


        /**
         * EndPoint para insertar y matricular un alumno
         */
        [HttpPost("alumno")]
        public bool insertarMatricular([FromBody] Alumno alumno, int id_asig)
        {
            return alumnosDAO.insertarMatricular(alumno.Dni, alumno.Nombre, alumno.Direccion, alumno.Edad, alumno.Email, id_asig);
        }

        /**
         * EndPoint para obtener loa alumnos asignados a un profesor
         */
        [HttpGet("alumnoProfesor")]
        public List<AlumnoProfesor> alumnosProfesor(string usuario)
        {
            return alumnosDAO.seleccionarAlumnoProfesor(usuario);
        }

        /**
         * EndPoint para actualizar datos del alumno
         */
        [HttpPut("alumno")]
        public bool actualizarAlumno([FromBody] Alumno alumno)
        {
            return alumnosDAO.actualizarAlumno(alumno.Id, alumno.Dni, alumno.Nombre, alumno.Direccion, alumno.Edad, alumno.Email);
        }

        /**
         * EndPoint para eliminar a alumno
         */
        [HttpDelete("alumno")]
        public bool eliminarAlumno(int id) 
        {
            return alumnosDAO.eliminarCalificacionesAlumno(id);
        }
    }
}
