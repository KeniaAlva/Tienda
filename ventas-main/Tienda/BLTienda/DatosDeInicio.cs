using BL.Tienda;
using System.Data.Entity;
using static BLTienda.CategoriasBL;

namespace BLTienda
{
    class DatosDeInicio : CreateDatabaseIfNotExists<Contexto>
    {

        protected override void Seed(Contexto contexto) //Método semilla (seed) inicia los datos para la base de datos
        {
            /*Colocamos los datos de inicio de usuario y contraseña*/
            var usuarioAdmin = new Usuario();
            usuarioAdmin.Nombre = "Admin1";
            usuarioAdmin.Contrasena = "123";

            contexto.Usuarios.Add(usuarioAdmin);

            /*Descripcion de las categorías*/
            var categoria1 = new Categoria();
            categoria1.Descripcion = "Damas";
            contexto.Categorias.Add(categoria1);

            var categoria2 = new Categoria();
            categoria2.Descripcion = "Caballeros";
            contexto.Categorias.Add(categoria2);

            var categoria3 = new Categoria();
            categoria3.Descripcion = "Niños";
            contexto.Categorias.Add(categoria3);


            /*Descripcion para los tipos de ropa*/
            var tipo1 = new Tipo();
            tipo1.Descripcion = "Camisas";
            contexto.Tipos.Add(tipo1);

            var tipo2 = new Tipo();
            tipo2.Descripcion = "Blusas";
            contexto.Tipos.Add(tipo2);

            var tipo3 = new Tipo();
            tipo3.Descripcion = "Pantalones";
            contexto.Tipos.Add(tipo3);

            var tipo4 = new Tipo();
            tipo4.Descripcion = "Shorts";
            contexto.Tipos.Add(tipo4);

            var tipo5 = new Tipo();
            tipo5.Descripcion = "Calcetines";
            contexto.Tipos.Add(tipo5);

            var tipo6 = new Tipo();
            tipo6.Descripcion = "Zapatos";
            contexto.Tipos.Add(tipo6);

            base.Seed(contexto); //Enviar los datos de inicio junto con el anexo del contexto a la base de datos
        }
    }
}