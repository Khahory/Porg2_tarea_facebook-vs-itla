using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Porg2_tarea_facebook.Models
{
    public class MateriaModel
    {
        public string Nombre { get; set; }
        public int CantidadMateria { get; set; }
        public int CantidadTarea { get; set; }

        public ArrayList nombres = new ArrayList();
        public ArrayList candidadesMateriaArray = new ArrayList();
        public ArrayList candidadesTareasArray = new ArrayList();
        public ArrayList tareas = new ArrayList();
    }
}