

namespace DLL.Models
{
  using DLL.ModeloInyeccion;
  using IoC.ModeloInyeccion;
  using System.Collections.Generic;
  public class Alumno : IPersona
  {
    private IBaseDatos db;


    public int IdPersona { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Direccion { get; set; }
    public int Edad { get; set; }


    public Alumno()
    {
      this.db = Inyector.Get<IBaseDatos>();
    }


    public bool Delete(IPersona item)
    {
      if (item == null)
      {
        return false;
      }
      return db.Delete(item);
    }

    public List<IPersona> GetAll()
    {
      return db.GetAll();
    }

    public IPersona GetById(int id)
    {
      return db.GetById(id);
    }

    public bool Save(IPersona item)
    {
      if (item == null)
      {
        return false;
      }
      return db.Save(item);


    }

    public bool Update(IPersona item)
    {
      if (item == null)
      {
        return false;
      }
      return db.Update(item);
    }
  }
}
