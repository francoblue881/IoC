namespace IoC.ModeloInyeccion
{

  using System;
  using System.Collections.Generic;
  using System.Linq;

  public class Inyector
  {

    public static Dictionary<Type, Type> mapeoClases = new Dictionary<Type, Type>();
    public static T Get<T>()
    {
      var type = typeof(T);
      return (T)Get(type);
    }

    public static void Map<T, V>() where V : T
    {
      //T= interfaz
      mapeoClases.Add(typeof(T), typeof(V));
    }

    private static object Get(Type tipo)
    {
      var target = ResolverTipo(tipo);
      var constructor = target.GetConstructors()[0];
      var parametrosConstructor = constructor.GetParameters();
      List<Object> parametrosResueltos = new List<object>();

      foreach (var item in parametrosConstructor)
      {
        parametrosResueltos.Add(Get(item.ParameterType) );
      }

      return constructor.Invoke(parametrosResueltos.ToArray());
    }


    private static Type ResolverTipo(Type tipo)
    {
      if (mapeoClases.Keys.Contains(tipo))
      {

        return mapeoClases[tipo];

      }
      return tipo;
    }

  }
}
