using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Porg2_tarea_facebook.Models
{
    public class GradosToFahren
    {
        public double Valor1 { get; set; }
        public double Valor2 { get; set; }

        public double GradosToFa(double valor)
        {
            double total = (valor * 9 / 5) + (32);
            return total;
        }

        public double FaToGrados(double valor)
        {
            double total = (valor - 32) * 5 / 9;
            return total;
        }
    }
}