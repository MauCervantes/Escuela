using AplicacionDatos.Context;
using AplicacionDatos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionDatos.Operaciones
{
    public class AlumnoDAO
    {
        //creamos un obj de contexto DB 
        public EscuelaContext contexto = new EscuelaContext();

        //Método para seleccionar los alumos 
        public List<Alumno> seleccionarTodos()
        {
            var alumnos = contexto.Alumnos.ToList<Alumno>();
            return alumnos;
        }

        public Alumno seleccionar(int id)
        {
            var alumno = contexto.Alumnos.Where(a => a.Id == id).FirstOrDefault();
            return alumno;
        }

        public Alumno seleccionarPorDni(string dni)
        {
            var alumno = contexto.Alumnos.Where(a => a.Dni == dni).FirstOrDefault();
            return alumno;
        }

        public bool insertarAlumno(string dni, string nombre, string direccion, int edad, string email)
        {
            try
            {
                Alumno alumno = new Alumno();
                alumno.Dni = dni;
                alumno.Nombre = nombre;
                alumno.Direccion = direccion;
                alumno.Edad = edad;
                alumno.Email = email;

                contexto.Alumnos.Add(alumno);
                contexto.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        //Actualizar los datos de Alumno
        public bool actualizarAlumno(int id, string dni, string nombre, string direccion, int edad, string email)
        {
            try
            {
                var alumno = seleccionar(id);

                if(alumno == null)
                {
                    return false;
                }
                else
                {
                    alumno.Dni = dni;
                    alumno.Nombre = nombre;
                    alumno.Direccion = direccion;
                    alumno.Edad = edad;
                    alumno.Email = email;

                    contexto.SaveChanges();
                    
                    return true;
                }

            }catch (Exception ex)
            {
                return false;
            }
        }

        //Eliminar Alumno
        public bool eliminarAlumno(int id)
        {
            try
            {
                var alumno = seleccionar(id);
                if (alumno == null)
                {
                    return false;
                }
                else
                {
                    contexto.Alumnos.Remove(alumno);
                    contexto.SaveChanges();
                    return true;
                }
            }catch(Exception ex){
                return false;
            }
        }

        //Seleccionar alumno con asignaturas.
        //Para eso necesitamos un nuevo modelo
        public List<AlumnoAsignatura> seleccionarAlumnosAsignaturas()
        {
            var query = from a in contexto.Alumnos
                        join m in contexto.Matriculas on a.Id
                equals m.AlumnoId
                        join asig in contexto.Asignaturas on
                m.AsignaturaId equals asig.Id
                        select new AlumnoAsignatura
                        {
                            nombreAlumno = a.Nombre,
                            nombreAsignatura = asig.Nombre
                        };
            return query.ToList();
        }

        public List<AlumnoProfesor> seleccionarAlumnoProfesor(String usuario)
        {
            var query = from a in contexto.Alumnos
                        join m in contexto.Matriculas on a.Id equals m.AlumnoId
                        join asig in contexto.Asignaturas on m.AsignaturaId equals asig.Id
                        where asig.Profesor == usuario
                        select new AlumnoProfesor
                        {
                            id = a.Id,
                            Dni = a.Dni,
                            Nombre = a.Nombre,
                            Direccion = a.Direccion,
                            Edad = a.Edad,
                            Email = a.Email,
                            Asignatura = asig.Nombre
                        };
            return query.ToList();
        }

        public bool insertarMatricular(string dni, string nombre, string direccion, int edad, string email, int id_asig)
        {
            try
            {
                var existe = seleccionarPorDni(dni);

                if(existe == null)
                {
                    insertarAlumno(dni, nombre, direccion, edad, email);
                    var insertado = seleccionarPorDni(dni);
                    Matricula m = new Matricula();
                    m.AlumnoId = insertado.Id;
                    m.AsignaturaId = id_asig;

                    contexto.Matriculas.Add(m);
                    contexto.SaveChanges();
                }
                else
                {
                    Matricula m = new Matricula();
                    m.AlumnoId = existe.Id;
                    m.AsignaturaId = id_asig;

                    contexto.Matriculas.Add(m);
                    contexto.SaveChanges();
                }
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public bool eliminarCalificacionesAlumno(int id)
        {
            try
            {
                var alumno = contexto.Alumnos.Where(a => a.Id == id).FirstOrDefault();

                if (alumno != null)
                {
                    //Recuperamos todas las matriculas
                    var matriculas = contexto.Matriculas.Where(m => m.AsignaturaId == id);

                    foreach (Matricula m in matriculas)
                    {
                        //Recuperamos las calificaciones del alumno
                        var calificaciones = contexto.Calificacions.Where(c => c.MatriculaId == m.Id);
                        contexto.Calificacions.RemoveRange(calificaciones);
                    }
                    contexto.Matriculas.RemoveRange(matriculas);
                    contexto.Alumnos.Remove(alumno);
                    contexto.SaveChanges();
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
