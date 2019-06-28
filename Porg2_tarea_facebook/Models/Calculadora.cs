using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Porg2_tarea_facebook.Models
{
    public class Calculadora
    {

        public int Valor1 { get; set; }
        public int Valor2 { get; set; }

        //operaciones
        public int Sumar(int valor1, int valor2)
        {
            int total = 0;
            return total = valor1 + valor2;
        }

        public int Division(int valor1, int valor2)
        {
            int total = 0;
            return total = valor1 / valor2;
        }

        public int Resta(int valor1, int valor2)
        {
            int total = 0;
            return total = valor1 - valor2;
        }

        public int Multiplicacion(int valor1, int valor2)
        {
            int total = 0;
            return total = valor1 * valor2;
        }
    }
}