using DLL.ModeloInyeccion;
using DLL.Models;
using IoC.ModeloInyeccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
  class Program
  {
    public static object Inyecto { get; private set; }

    public static void GetMenu()
    {
      Console.WriteLine("*************MENU*************");
      Console.WriteLine("1-Consultar lista de personas");
      Console.WriteLine("2-Consultar persona por id");
      Console.WriteLine("3-Eliminar persona");
      Console.WriteLine("4-Agregar registro");
      Console.WriteLine("5-Actualizar registro");
      Console.WriteLine("6-Salir");
      Console.WriteLine("Ingrese su opcion:");
    }


    public static void Main(string[] args)
    {//registratr independecias
      int opcion, id;

      Inyector.Map<IBaseDatos, BaseDatos>();
      //Inyector.Map<IPersona, Persona>();
      Inyector.Map<IPersona, Alumno>();


      var alumno = Inyector.Get<IPersona>();
      var gestion = Inyector.Get<IBaseDatos>();

      GetMenu();
      opcion = int.Parse(Console.ReadLine());

      //Lista de regisdtros

      alumno.IdPersona = 1;
      alumno.Nombre = "José";
      alumno.Apellido = "Salvador";
      alumno.Direccion = "satein";
      alumno.Edad = 25;
      gestion.Save(alumno);

      alumno = Inyector.Get<IPersona>();
      alumno.IdPersona = 2;
      alumno.Nombre = "Maria";
      alumno.Apellido = "carcamo";
      alumno.Direccion = "satein";
      alumno.Edad = 25;
      gestion.Save(alumno);

      if (opcion == 1)
      {
        foreach (var item in gestion.GetAll() )
        {
          Console.WriteLine("ID: " + item.IdPersona + " Nombre: " + item.Nombre + " " + item.Apellido);

        }
      }

      if (opcion ==2)
      {
        Console.WriteLine("Ingrese el ID  a encontrar");
        int i = int.Parse(Console.ReadLine() );
        var item = gestion.GetById(i);

        Console.WriteLine("ID: " + item.IdPersona + " Nombre: " + item.Nombre + " " + item.Apellido);

      }
      Console.ReadKey();





    }

  }
}
