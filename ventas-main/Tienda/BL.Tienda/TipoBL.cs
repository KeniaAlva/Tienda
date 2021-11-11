using System.ComponentModel;
using System.Data.Entity;

namespace BL.Tienda
{
    public class TipoBL
    {

        Contexto _contexto;   //*Declarar la variable de tipo contexto*//
        public BindingList<Tipo> ListaTipos { get; set; }  //*Permite realizar una lista de productos*//


        public TipoBL()
        {
            _contexto = new Contexto();      //*Instanciamos la variable contexto*//
            ListaTipos = new BindingList<Tipo>();

            //* Datos de prueba fueron eliminados*//
        }

        public BindingList<Tipo> Obtenertipos()
        {
            _contexto.Tipos.Load();           //* Carga los productos*//
            ListaTipos = _contexto.Tipos.Local.ToBindingList();   //*LLenamos la lista de productos*//

            return ListaTipos;



        }
    }
    public class Tipo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
