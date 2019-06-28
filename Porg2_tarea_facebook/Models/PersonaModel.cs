using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Porg2_tarea_facebook.Models;

namespace Porg2_tarea_facebook.Models
{
    public class PersonaModel
    {
        //variables de la tabla que tenemos en excel
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Carrera { get; set; }
    }
}