using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionDatos.Models
{
    public class AlumnoProfesor
    {
        public int id { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }
        public string Asignatura { get; set; }
    }
}
