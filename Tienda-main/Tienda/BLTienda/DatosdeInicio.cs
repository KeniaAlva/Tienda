using BLTienda;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL.Tienda
{
    class DatosdeInicio : CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            var usuarioAdmin1 = new Usuario();
            usuarioAdmin1.Nombre = "admin";
            usuarioAdmin1.Contrasena = "123";

            contexto.Usuarios.Add(usuarioAdmin1);

            var usuarioAdmin2 = new Usuario();
            usuarioAdmin2.Nombre = "user";
            usuarioAdmin2.Contrasena = "456";

            contexto.Usuarios.Add(usuarioAdmin2);

            var categoria1 = new Categoria();
            categoria1.Descripcion = "Ropa de Dama";
            contexto.Categorias.Add(categoria1);

            var categoria2 = new Categoria();
            categoria2.Descripcion = "Ropa de Caballero";
            contexto.Categorias.Add(categoria2);

            var categoria3 = new Categoria();
            categoria3.Descripcion = "Ropa de Deportiva";
            contexto.Categorias.Add(categoria3);

            var categoria4 = new Categoria();
            categoria4.Descripcion = "Ropa de Niños";
            contexto.Categorias.Add(categoria4);

            var tipo1 = new Tipo();
            tipo1.Descripcion = "Camisas";
            contexto.Tipos.Add(tipo1);

            var tipo2 = new Tipo();
            tipo2.Descripcion = "Pantalones";
            contexto.Tipos.Add(tipo2);

            var tipo3 = new Tipo();
            tipo3.Descripcion = "Accesorios";
            contexto.Tipos.Add(tipo3);

            base.Seed(contexto);
        }
    }
}
