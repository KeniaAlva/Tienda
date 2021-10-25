using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLTienda
{
    public class ProductosBL
    {
        Contexto _contexto; //Declaramos variable contexto

        /*Creacion de Lista Binding (arreglo) para los productos*/
        public BindingList<Producto> ListaProductos { get; set; }

        public ProductosBL()
        {
            _contexto = new Contexto(); //Instanciamos el contexto en el constructor

            /*Instanciamos la lista*/
            ListaProductos = new BindingList<Producto>();

            /****Se han eliminado los datos de prueba****/

        }


        public BindingList<Producto> ObtenerProductos()
        {

            /*Declaracion de la clase contexto*/
            _contexto.Productos.Load();//Cargando datos a la tabla
            ListaProductos = _contexto.Productos.Local.ToBindingList(); //Llenar la lista

            return ListaProductos;
        }
        /*Creacion de una clase para guardar los productos, el cual se recibira un producto con parametro YA*/

        public Resultado GuardarProducto(Producto producto)
        {
            var resultado = Validar(producto);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }


            _contexto.SaveChanges();//Agregando la clase contexto de nuestra base de datos y guardar cambios

            resultado.Exitoso = true;
            return resultado;
        }

        /*Agregar producto lo agregamos a producto bl  en una clase Yorlany Alva*/

        public void AgregarProducto()
        {
            var nuevoProducto = new Producto();
            ListaProductos.Add(nuevoProducto);
        }

        /*Creamos una clase para eliminar producto Ya*/

        public bool EliminarProducto(int id)
        {

            foreach (var producto in ListaProductos)//Foreach es una funcion que recorre listas de objetos
            {
                if (producto.ID == id)
                {
                    ListaProductos.Remove(producto);
                    _contexto.SaveChanges();   // Se guardan los cambios para la base de datos contexto
                    return true;

                }
            }


            return false;
        }
        /* Creamos un metodo de tipo private resultado que se encargara de validar un producto*/
          private Resultado Validar(Producto producto)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if(string.IsNullOrEmpty(producto.Descripcion) == true)
            {
                resultado.Mensaje = "Ingrese una descripcion ";
                resultado.Exitoso = false;
            }
            if (producto.Existencia < 0 )
            {
                resultado.Mensaje = "La existencia debe ser mayor de cero ";
                resultado.Exitoso = false;
            }
            if (producto.Precio < 0)
            {
                resultado.Mensaje = "El precio debe ser mayor de cero ";
                resultado.Exitoso = false;
            }
            return resultado;
        }
    }
        /*Propiedades de los productos*/
    }
    public class Producto
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }
        public bool Activo { get; set; }
      }

/* Creamos una nueva clase que lo que tendra es un resultado YA*/
   public class Resultado
{
    public bool Exitoso { get; set; }
    public string Mensaje { get; set; }
}
    