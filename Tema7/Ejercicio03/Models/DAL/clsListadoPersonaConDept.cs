namespace Ejercicio03.Models.DAL;

using Ejercicio03.Models.Entities;
    
public static class clsListadoPersonaConDept
    {
    //Nos creamos una función de tipo lista de clsPersona
    public static List<clsPersona> listadoPersonasConDept()
    {

        List<clsPersona> deptPersonas = new List<clsPersona>()
        {
            new clsPersona() { Nombre = "Isabel", Apellidos = "Loerzer", IdDepartamento = 1 },
            new clsPersona() { Nombre = "Isaac", Apellidos = "Ramos", IdDepartamento = 1 },
            new clsPersona() { Nombre = "Carmen", Apellidos = "Martín", IdDepartamento = 1 },
            new clsPersona() { Nombre = "Pedro", Apellidos = "Cornejo", IdDepartamento = 1 },
            new clsPersona() { Nombre = "Luisa", Apellidos = "Alejandra", IdDepartamento = 2 },
            new clsPersona() { Nombre = "Paco", Apellidos = "Rodriguez", IdDepartamento = 3 },
            new clsPersona() { Nombre = "Javi", Apellidos = "Gonzalez", IdDepartamento = 2 },
            new clsPersona() { Nombre = "Miguel", Apellidos = "Domínguez", IdDepartamento = 3 }


        };

        return deptPersonas;

    }
        
    }

