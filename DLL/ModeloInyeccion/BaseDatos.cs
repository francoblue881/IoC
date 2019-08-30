using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.Models;

namespace DLL.ModeloInyeccion
{
  public class BaseDatos : IBaseDatos
  {

    private static List<IPersona> dbPersonas;
    private int index;

    public BaseDatos()
    {
      if (dbPersonas==null)
      {
        dbPersonas = new List<IPersona>();
      }
     
    }


    public bool Delete(IPersona item)
    {
      try
      {
        index = dbPersonas.FindIndex(p => p.IdPersona.Equals(item.IdPersona));
        dbPersonas.RemoveAt(index);
        return true;
      }
      catch (Exception)
      {

        return false;
      }
    }

    public List<IPersona> GetAll()
    {
      return dbPersonas;
    }

    public IPersona GetById(int id)
    {
      return dbPersonas.Find(p=>p.IdPersona.Equals(id));

    }

    public bool Save(IPersona item)
    {
      try
      {
        index = dbPersonas.Count - 1;
        if (index < 0)
        {
          item.IdPersona = 1;
        }
        else
        {
          item.IdPersona = (dbPersonas[index].IdPersona) + 1;
        }
        dbPersonas.Add(item);
        return true;
      }
      catch (Exception)
      {

        return false;
      }
    }

    public bool Update(IPersona item)
    {
      try
      {
        index = dbPersonas.FindIndex(p => p.IdPersona.Equals(item.IdPersona));
        dbPersonas[index] = item;
        return true;
      }
      catch (Exception)
      {

        return false;
      }

    }
  }
}
