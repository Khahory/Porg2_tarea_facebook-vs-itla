using Porg2_tarea_facebook.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel;

namespace CalculadoraMvc.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost] //metodo para comprobar si el archivo que se introduce termina en xls o xlsx
        public ActionResult Import(HttpPostedFileBase excelFile)
        {
            //saber si coloco un .xls
            if (excelFile == null || excelFile.ContentLength == 0)
            {
                ViewBag.Error = "Please select a excel file";
                return View("Index");
            }
            else
            {
                //otro if
                if (excelFile.FileName.EndsWith("xls") || excelFile.FileName.EndsWith("xlsx"))
                {
                    //guardar el archivo en la carpeta "Content" (Solo es esta parte del codigo)
                    string path = Server.MapPath("~/Content/" + excelFile.FileName);
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                    excelFile.SaveAs(path);
                    //Fin del guardado

                    //Read data from excel file
                    Excel.Application application = new Excel.Application();
                    Excel.Workbook workbook = application.Workbooks.Open(path);
                    Excel.Worksheet worksheet = workbook.ActiveSheet;
                    Excel.Range range = worksheet.UsedRange;
                    
                    //hay que crear un modelo para el producto
                    List<PersonaModel> listPersona = new List<PersonaModel>();
                    for (int row = 3; row <= range.Rows.Count; row++)
                    {
                        PersonaModel PersonaModel = new PersonaModel(); //supongo que esto es para leer los datos del File Excel
                        PersonaModel.Nombre = ((Excel.Range)range.Cells[row, 1]).Text; //asignamos los valores al modelo
                        PersonaModel.Edad = int.Parse(((Excel.Range)range.Cells[row, 2]).Text);
                        PersonaModel.Carrera = ((Excel.Range)range.Cells[row, 3]).Text;
                        listPersona.Add(PersonaModel);
                    }
                    ViewBag.ListPersona = listPersona;

                    //para cerrar el documento cuando ya se leyo todo
                    application.Workbooks.Close();
                    return View("Success");
                }
                else
                {
                    ViewBag.Error = "Please select a excel file";
                    return View("Index");
                }
            }

        }

        //enviar al modelos la cantidad de materias y de tareas
        public ActionResult CapturarMateriaTarea()
        {


            return View();
        }

        //Cuando le da al boton enviar pues la cantidades se enviaran al modelo
        MateriaModel materiaModel = new MateriaModel();
        public ActionResult EnviarDatos()
        {
            //caundo se ejecuta se asignaran lo que esta en el box de las dos cantidades al modelo
            materiaModel.CantidadMateria = Convert.ToInt32(Request.Form["MateriaTotalInt"].ToString());
            materiaModel.CantidadTarea = Convert.ToInt32(Request.Form["TareaTotalInt"].ToString());

            //El agrega una lista por cada numero que hemos enviado al medelo materia
            int cantMaterias = materiaModel.CantidadMateria;
            int catTareas = materiaModel.CantidadTarea;
            for (int i = 0; i < cantMaterias; i++)
            {
                materiaModel.candidadesMateriaArray.Add("");
                for (int j = 0; j < catTareas; j++)
                {
                    materiaModel.candidadesTareasArray.Add("");
                }
            }

            //ejecutara la accion "mostraBox" y trabajara con el objeto "materiaModel"
            return View("MostrarBox", materiaModel);
        }

        public ActionResult MostrarBox()
        {


            return View(materiaModel);
        }

        public ActionResult Capturar()
        {
            //asignar las variables
            for (int i = 0; i < 1; i++) //no importa si pongo 1 o 500 en el i<1, siempre dara lo mismo wtf
            {
                materiaModel.nombres.Add(Request.Form["nombre"].ToString());
                materiaModel.tareas.Add(Request.Form["tareas"].ToString());
            }

            //mostra materias y tareas
            //for uno
            foreach (var item in materiaModel.nombres)
            {
                materiaModel.Nombre = item.ToString();
                //for dos
                foreach (var itemDos in materiaModel.tareas)
                {
                    return Content("Las materias son: " + materiaModel.Nombre + " --- Las tareas son: " + itemDos);
                }
            }

            return Content("null");
            // return RedirectToAction("About");
        }
    }
}