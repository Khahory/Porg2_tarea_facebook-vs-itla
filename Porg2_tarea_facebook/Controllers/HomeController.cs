using Porg2_tarea_facebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Porg2_tarea_facebook.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()

        {
            return View();
        }

        //vista acerca de..
        public ActionResult About()
        {

            return View();
        }

        //calculadora
        public ActionResult Calculadora()
        {
            return View();
        }

        //calculadora fahrenheit a grados
        public ActionResult CalculadoraFahren_To_Grados()
        {
            return View();
        }

        //total
        public ActionResult Total(int value1, int value2, String calculo)
        {
            Resultado resultado = new Resultado();

            Calculadora calculadora = new Calculadora();
            decimal total = 0;

            //traer operacion
            calculo = Request.Form["options"].ToString();


            switch (calculo)
            {
                case "+":
                    total = calculadora.Sumar(value1, value2);
                    break;
                case "-":
                    total = calculadora.Resta(value1, value2);
                    break;
                case "*":
                    total = calculadora.Multiplicacion(value1, value2);
                    break;
                case "/":
                    total = calculadora.Division(value1, value2);
                    break;
                default:
                    total = 0;
                    break;
            }

            resultado.Resultados = total;
            return Content("Resultado:" + total);

        }

        //total dos
        public ActionResult TotalDos(string calculo)
        {
            ResultadoFa_GradoModel resultado = new ResultadoFa_GradoModel();

            GradosToFahren calculadora = new GradosToFahren();
            double total = 0;
            string numeroString;

            //traer operacion
            calculo = Request.Form["Seleccion"].ToString();

            //traer el input de texto
            numeroString = Request.Form["valor"].ToString();
            double numeroInt = Convert.ToDouble(numeroString);

            switch (calculo)
            {
                case "1":
                    total = calculadora.FaToGrados(numeroInt);
                    break;

                case "2":
                    total = calculadora.GradosToFa(numeroInt);
                    break;

                default:
                    total = 0;
                    break;
            }

            resultado.Resultados_FaGra = total;
            return Content("Resultado:" + total);

        }
    }
}