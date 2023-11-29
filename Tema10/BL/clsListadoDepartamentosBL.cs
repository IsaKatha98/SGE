using Biblioteca;
using DAL.Listados;
using DAL.Manejadoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class clsListadoDepartamentosBL
    {
        public static List<clsDepartamento> listadoCompletoDepartamentosBL()
        {
            return clsListadoDepartamentosDAL.getListadoDepartamentos();
        }

        public static clsDepartamento getDepartamentoByIdBL(int id)
        {

            return clsListadoDepartamentosDAL.getDepartamentoById(id);

        }
    }
}
