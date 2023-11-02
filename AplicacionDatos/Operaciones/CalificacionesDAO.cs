using AplicacionDatos.Context;
using AplicacionDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionDatos.Operaciones
{
    public class CalificacionesDAO
    {
        EscuelaContext contexto = new EscuelaContext();

        //retornar calificacioens por id de alumno
        public List<Calificacion> seleccionar(int id)
        {
            var calificaciones = contexto.Calificacions.Where(a => a.Matricula.Id == id).ToList();
            return calificaciones;
        }

        public bool agregarCalificacion(Calificacion calificacion)
        {
            try
            {
                contexto.Calificacions.Add(calificacion);
                contexto.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public bool eliminarCalificacion (int id)
        {

            var calificacion = contexto.Calificacions.Where(c => c.Id == id).FirstOrDefault();
            if (calificacion != null)
            {
                try
                {
                    contexto.Calificacions.Remove(calificacion);
                    contexto.SaveChanges();
                    return true;
                }
                catch (Exception ex)
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
