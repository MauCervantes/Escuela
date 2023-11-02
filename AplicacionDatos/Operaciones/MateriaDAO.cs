using AplicacionDatos.Context;
using AplicacionDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionDatos.Operaciones
{
    public class MateriaDAO
    {
        //Consultar todas las materias
        //Consultar materias por ID
        //Insertar Materia --Nombre del profesor. Recordar
        //Actualizar Materia

        //creamos un obj de contexto db
        public EscuelaContext contexto = new EscuelaContext();

        //Consultar todas las materias
        public List<Asignatura> seleccionarAsignaturas()
        {
            var asignaturas = contexto.Asignaturas.ToList<Asignatura>();
            return asignaturas;
        }

        //Consultar Materia por ID
        public Asignatura seleccionar(int id)
        {
            var asignatura = contexto.Asignaturas.Where(a => a.Id == id).FirstOrDefault();
            return asignatura;
        }

        //Insertar Materia junto con profesor
        public bool insertarMateria(string nombre, int creditos, string profesor)
        {
            var profesorEncontrado = contexto.Profesors.Where(a => a.Usuario == profesor).FirstOrDefault();

            if (profesorEncontrado != null)
            {
                try
                {
                    Asignatura asignatura = new Asignatura();
                    asignatura.Nombre = nombre;
                    asignatura.Creditos = creditos;
                    asignatura.Profesor = profesor;

                    contexto.Asignaturas.Add(asignatura);
                    contexto.SaveChanges();
                    return true;
                }
                catch(Exception ex) 
                { 
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //Actualizar Materia
        public bool actualizarAsignatura(int id, string nombre, int creditos, string profesor)
        {
            var asignatura = seleccionar(id);
            
            if(asignatura != null)
            {
                var profesorEncontrado = contexto.Profesors.Where(a => a.Usuario == profesor).FirstOrDefault();

                if(profesorEncontrado != null)
                {
                    asignatura.Nombre = nombre;
                    asignatura.Creditos = creditos;
                    asignatura.Profesor = profesor;

                    contexto.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
