using Ejercicio03.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Biblioteca;
using BL;
using DAL;
using Ejercicio03.Models.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ejercicio03.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            //Hay que pasale al VM una lista de personas y el objeto clsPersona.
            List<clsPersona> listadoPersonas = clsListaPersonasBL.listadoCompletoPersonasBL();

            return View(listadoPersonas);
        }

        public IActionResult Details(int id) {

            try
            {
                clsPersona persona= clsListaPersonasBL.getPersonaByIdBL(id);
                //guardamos en una variable clsPersona el resultado de la función que lee los detalles de la persona.
                clsPersonaDepartamento vm = new clsPersonaDepartamento(persona);

                return View(vm);
            }
            catch (Exception ex)
            {
                return View("Error");
            }       
        
        }

        public ActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create (int id, string nombre, string apellidos, string direccion, string tlf, string fotoURL, DateTime fechaNac, int idDepartamento)
        {
            //Creamos una persona con los siguientes datos.
            //int persona = clsManejadoraPersonaDAL.insertPersonaDAL(id, nombre, apellidos, direccion, tlf, fotoURL, fechaNac, idDepartamento);

            try
            {
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult Edit (int id)
        {
            //Mostramos los detalles de la persona que vamos a editar
            clsPersona persona = clsListaPersonasBL.getPersonaByIdBL(id);

            //Instanciamos el Viewmodel que nos hace falta.
            clsPersonaListadoDepartamentos vm= new clsPersonaListadoDepartamentos(persona);

            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit (clsPersona persona) 
        {
           //Llamamos a la función que actualiza.
            int numFilasAfectadas = clsManejadoraBL.editPersonaBL(persona);

            try
            {

                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                return View("Error");
            }



        }

        public ActionResult Delete (int id) {
            try
            {
                clsPersona persona = clsListaPersonasBL.getPersonaByIdBL(id);
                //guardamos en una variable clsPersona el resultado de la función que lee los detalles de la persona.
                clsPersonaDepartamento vm = new clsPersonaDepartamento(persona);

                return View(vm);
            }
            catch (Exception ex)
            {
                return View("Error");
            }



        }
        [ActionName("Delete")]
        [HttpPost]
        public ActionResult DeletePost (int id)
        {
            try
            {
                int numFilas = clsManejadoraBL.deletePersonaBL(id);

                if (numFilas == 0)
                {
                    ViewBag.Info = "No existe esa persona";
                }
                else if (numFilas == -1)
                {
                    ViewBag.Info = "Hoy es miércoles, no se pueden borrar elementos";
                }
                else
                {
                    ViewBag.Info = "La persona se ha borrado correctamente";
                }

                return View( "Index", clsListaPersonasBL.listadoCompletoPersonasBL());

                

            } catch (Exception e)
            {
                return View("Error");
            }



        }

    }
}