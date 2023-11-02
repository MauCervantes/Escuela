using AplicacionDatos.Context;
using AplicacionDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionDatos.Operaciones
{
    public class ProfesorDAO
    {

        //Consultar todos profesores
        //Consultar por ID
        //Agregar profesor
        //Modificar Profesor

        //Creamos obj de tipo context
        public EscuelaContext contexto =  new EscuelaContext();

        //Consultar todos los profesores
        public List<Profesor> seleccionarProfesores()
        {
            var profesores = contexto.Profesors.ToList<Profesor>();
            return profesores;
        }

        //Consultar profesor por usuario
        public Profesor seleccionar(string usuario)
        {
            var profesor = contexto.Profesors.Where(a => a.Usuario == usuario).FirstOrDefault();
            return profesor;
        }

        //Agregar profesor
        public bool agregarProfesor(string usuario, string pass, string nombre, string email)
        {
            try
            {
                Profesor profesor = new Profesor();
                profesor.Usuario = usuario;
                profesor.Pass = pass;
                profesor.Nombre = nombre;
                profesor.Email = email;

                contexto.Profesors.Add(profesor);
                contexto.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

        //Modificar Profesor
        public bool modificarProfesor(string usuario, string pass, string nombre, string email)
        {
            var profesor = seleccionar(usuario);

            if (profesor != null)
            {
                profesor.Pass = pass;
                profesor.Nombre = nombre;
                profesor.Email = email;

                contexto.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
