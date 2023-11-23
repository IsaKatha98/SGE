using Ejercicio01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Data.SqlClient;

namespace Ejercicio01.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {

            SqlConnection connection = new SqlConnection();
            ViewBag.ConnectionState = "No se ha intentado conectar";

            try
            {
                connection.ConnectionString = "server=107-24\\SQLEXPRESS;database=Persona;uid=prueba;pwd=123;trustServerCertificate=true";
                connection.Open();
                ViewBag.ConnectionState = $"Se ha abierto la conexión: {connection.State}";

            } catch (Exception ex)
            {
                ViewBag.ConnectionState = $"Error al conectar: {ex.Message}";
            }
            return View();
        }

      
    }
}