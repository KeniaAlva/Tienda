using System.ComponentModel;
using System.Data.Entity;

namespace BLTienda
{
    public class Cliente
    {
        Contexto _contexto; /*Agregamos el contexto para anexar el dbset cleintes a la clase clientesbl*/

        public BindingList<Cliente> ListaClientes { get; set; }

        public Cliente()
        {
            _contexto = new Contexto();
            ListaClientes = new BindingList<Cliente>();
        }

        public BindingList<Cliente> ObtenerClientes()
        {
            _contexto.Tipos.Load();
            ListaClientes = _contexto.Tipos.Local.ToBindingList();

            return ListaClientes;
        }
    }

    /*Propiedades de la clase tipo*/
    public class Cliente
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}