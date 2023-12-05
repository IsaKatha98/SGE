using IU.Models;
using IU.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Entities;
using System.Diagnostics;
using BL.Handler;

namespace IU.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Listado()
        {
            try
            {
                //Instanciamos el vm, el contructor vacío que nos devuelve el listado de marcas.

                clsListadoMarcasListadoModelosObjModelo vm = new clsListadoMarcasListadoModelosObjModelo();

                return View(vm);
            }
            catch (Exception ex)
            {
                return View("Error");
            }

        }

        [HttpPost]
        public ActionResult Listado(int idMarca)

        {
            try
            {
                //Instanciamos el vm, el contructor con idMarca que nos devuelve el listado de modelos asociados a ese idMarca.
                clsListadoMarcasListadoModelosObjModelo vm = new clsListadoMarcasListadoModelosObjModelo(idMarca);

                return View();
            }
            catch (Exception ex)
            {
                return View("Error");
            }


        }

        public ActionResult Edit(int idModelo)
        {

            try
            {
                //Instanciamos un objeto modelo.
                clsModelo modelo = clsHandlerModelosBL.getModeloById(idModelo);

                //Instanciamos el vm.
                clsMarcaModelo vm = new clsMarcaModelo(modelo);

                return View();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }



        [HttpPost]
        public ActionResult Edit (clsModelo modelo)
        {
            try
            {
                int numFilasAfectadas = clsHandlerModelosBL.editPrecio(modelo);


                if (numFilasAfectadas == 0)
                {
                    ViewBag.Info = "No se ha podido editar el precio";
                }

                else
                {
                    ViewBag.Info = "El precio se ha editato correctamente";
                }

                return View("Index");




            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}