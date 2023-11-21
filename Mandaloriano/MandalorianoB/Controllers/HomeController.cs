using MandalorianoB.DAL;
using MandalorianoB.Entidades;
using MandalorianoB.Models;
using MandalorianoB.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MandalorianoB.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            
            //Hay que pasarle al VM una lista de misiones y un objeto clsMision.

           List<clsMision>listadoMisiones=clsListadoMisionesDAL.listadoMisiones();
            clsMision mision= new clsMision();
            clsListadoMisionesVM vistaVM = new clsListadoMisionesVM(listadoMisiones, mision);

            return View(vistaVM);
        }

        [HttpPost]
        public IActionResult Index (int idMision)
        {
            List<clsMision> listadoMisiones = clsListadoMisionesDAL.listadoMisiones();

              clsMision misionVM = new clsMision();

            //Aquí recorremos listadoMisiones para ver si encontramos el idMision.
            foreach (clsMision mision in listadoMisiones)
            {
                if (mision.Id == idMision)
                {
                    misionVM.Id = mision.Id;
                    misionVM.Titulo = mision.Titulo;
                    misionVM.Descripcion = mision.Descripcion;
                    misionVM.Creditos = mision.Creditos;
                }
            }

          

            //Creamos un objeto VM.
            clsListadoMisionesVM vistaVM = new clsListadoMisionesVM(listadoMisiones, misionVM);

            //Devolvemos el VM a la vista.
            return View(vistaVM);
        }

      
    }
}