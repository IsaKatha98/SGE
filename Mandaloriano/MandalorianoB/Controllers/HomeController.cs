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
        /// <summary>
        /// Vista que ve el usuario al entrar por primera vez.
        /// Se instancia una lista de misiones que la coge de la capa DAL.
        /// Se crea e instancia un objeto misión.
        /// Se crea un objeto del ViewModel y se les pasa el listado de misiones y el objeto mision.
        /// </summary>
        /// <returns>Una vista a la que se le pasa el objeto vistaVM</returns>
        
        public IActionResult Index()
        {
            
            //Hay que pasarle al VM una lista de misiones y un objeto clsMision.
            List<clsMision>listadoMisiones=clsListadoMisionesDAL.listadoMisiones();
            clsMision mision= new clsMision();
            clsListadoMisionesVM vistaVM = new clsListadoMisionesVM(listadoMisiones, mision);

            return View(vistaVM);
        }
        /// <summary>
        /// Vista que ve el usuario tras elegir una misión , por eso [HttpPost].
        /// Recibe un entero idMision.
        /// Se crean e instancian los mismos objetos que en la vista anterior.
        /// Se hace un foreach que recorre el listado de misiones buscando la misión cuyo id es el que hemos pasado por parámetro.
        /// Si encuentra un objeto con ese id, se trae todos los atributos y los asigna al objeto vacío que nos hemos creado.
        /// Se crea un objeto del ViewModel y se les pasa el listado de misiones y el objeto mision.
        /// </summary>
        /// <param name="idMision">id de la misión que ha escogido el usuario</param>
        /// <returns>Una vista a la que se le pasa el objeto vistaVM</returns>
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