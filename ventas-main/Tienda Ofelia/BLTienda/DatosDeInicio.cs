using System;
using System.Data.Entity;
using static BLTienda.CategoriasBL;

namespace BLTienda
{
    internal class DatosDeInicio : CreateDatabaseIfNotExists<Contexto>
    {
        private Contexto context;

        protected override void Seed(Contexto contexto)
        {
            /*PARTE 6: Descripcion para las tallas de las camisas*/ 
            var usuarioAdmin = new Usuario();
            usuarioAdmin.Nombre = "admin";
            usuarioAdmin.Contrasena = "123";

            contexto.Usuarios.Add(usuarioAdmin);

            var categoria1 = new Categoria();
            categoria1.Descripcion = "Talla S";
            contexto.Categorias.Add(categoria1);

            var categoria2 = new Categoria();
            categoria2.Descripcion = "Talla M";
            contexto.Categorias.Add(categoria2);

            var categoria3 = new Categoria();
            categoria3.Descripcion = "Talla L";
            contexto.Categorias.Add(categoria3);

            var categoria4 = new Categoria();
            categoria4.Descripcion = "Talla XL";
            contexto.Categorias.Add(categoria4);

            var categoria5 = new Categoria();
            categoria5.Descripcion = "Talla XXL";
            contexto.Categorias.Add(categoria5);


            /*Descripcion para los tipos de color de las camisas*/
            var tipo1 = new Tipo();
            tipo1.Descripcion = "Color blanco";
            contexto.Tipos.Add(tipo1);

            var tipo2 = new Tipo();
            tipo2.Descripcion = "Color gris";
            contexto.Tipos.Add(tipo2);

            var tipo3 = new Tipo();
            tipo3.Descripcion = "Color negro";
            contexto.Tipos.Add(tipo3);

            var tipo4 = new Tipo();
            tipo4.Descripcion = "Color amarillo";
            contexto.Tipos.Add(tipo4);

            var tipo5 = new Tipo();
            tipo5.Descripcion = "Color azul";
            contexto.Tipos.Add(tipo5);

            var tipo6 = new Tipo();
            tipo6.Descripcion = "Color verde";
            contexto.Tipos.Add(tipo6);

            base.Seed(context);
        }
    }
}