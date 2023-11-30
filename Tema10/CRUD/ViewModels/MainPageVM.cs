using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca;
using BL;

namespace CRUD.ViewModels
{
    internal class MainPageVM
    {
        private ObservableCollection<clsPersona> listadoCompletoPersonas;

        public MainPageVM()
        {
            try
            {
                listadoCompletoPersonas = new ObservableCollection<clsPersona>(clsListaPersonasBL.listadoCompletoPersonasBL());
            }
            catch (Exception ex)
            {

            }
            
        }

        public ObservableCollection<clsPersona> ListadoCompletoPersonas
        {
            get { return listadoCompletoPersonas; }
        }


    }
}
