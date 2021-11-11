using BL.Tienda;
using BLTienda;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace BL.Tienda
{
    public class SeguridadBL
    {
        Contexto _contexto;
        public BindingList<Usuarios> ListaUsuarios { get; set; }
        public object Clientes { get; private set; }

        public SeguridadBL()
        {
            _contexto = new Contexto();
            ListaUsuarios = new BindingList<Usuarios>();
        }

        public BindingList<Usuarios> ObtenerUsuarios()
        {
            _contexto.Usuarios.Load();
            ListaUsuarios = _contexto.Usuario.Local.ToBindingList();

            return ListaUsuarios;
        }

        public bool Autorizar(string usuario, string contrasena)
        {
            var usuarios = _contexto.Usuarios.ToList();

            foreach (var usuarioDB in usuarios)
            {
                if (usuario == usuarioDB.Nombre && contrasena == usuarioDB.Contrasena)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class Usuarios
    {
        public string Contrasena { get; internal set; }
        public string Nombre { get; internal set; }
    }
}


