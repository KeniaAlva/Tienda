using System.ComponentModel;
using System.Data.Entity;

namespace BLTienda
{
    public class TiposBL
    {

        Contexto _contexto; /*Agregamos el contexto para anexar el dbset tipos a la clase tiposbl*/

        public BindingList<Tipo> ListaTipos { get; set; }

        public TiposBL()
        {
            _contexto = new Contexto();
            ListaTipos = new BindingList<Tipo>();
        }

        public BindingList<Tipo> ObtenerTipos()
        {
            _contexto.Tipos.Load();
            ListaTipos = _contexto.Tipos.Local.ToBindingList();

            return ListaTipos;
        }
    }

 /*Propiedades de la clase tipo*/
    public class Tipo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
