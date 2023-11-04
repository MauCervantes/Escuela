using AplicacionDatos.Models;
using AplicacionDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private ProfesorDAO profesorDAO = new ProfesorDAO();

        ////EndPoint para obtener profesores
        [HttpGet("profesor")]
        public List<Profesor> obtenerProfesores()
        {
            return profesorDAO.seleccionarProfesores();
        }

        //EndPoint para obtener profesor por usuario
        [HttpGet("profesorId")]
        public Profesor obtenerProfesor(string usuario)
        {
            return profesorDAO.seleccionar(usuario);
        }

        //EndPoint para agregar nuevo profesor
        [HttpPost("profesor")]
        public bool agregarProfesor([FromBody] Profesor profesor)
        {
            return profesorDAO.agregarProfesor(profesor.Usuario, profesor.Pass, profesor.Nombre, profesor.Email);
        }

        //EndPoint para modificar profesor
        [HttpPut("profesor")]
        public bool actualizarProfesor([FromBody] Profesor profesor)
        {
            return profesorDAO.modificarProfesor(profesor.Usuario, profesor.Pass, profesor.Nombre, profesor.Email);
        }
    }
}
