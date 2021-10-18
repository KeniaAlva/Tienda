using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLTienda
{
    public class ProductosBL
    {
        /*Creacion de Lista Binding (arreglo) para los productos*/
        public BindingList<Producto> ListaProductos { get; set; }

        public ProductosBL()
        {
            /*Instanciamos la lista*/
            ListaProductos = new BindingList<Producto>();

            /*Instanciamos productos en la lista y colocamos todos 
             los datos del producto en sus propiedades.*/

            //Producto1
            var Producto1 = new Producto();
            Producto1.ID = 1;
            Producto1.Descripcion = "Camisetas";
            Producto1.Precio = 65;
            Producto1.Existencia = 100;
            Producto1.Activo = true;

            ListaProductos.Add(Producto1);

            //Producto2
            var Producto2 = new Producto();
            Producto2.ID = 2;
            Producto2.Descripcion = "Vestidos";
            Producto2.Precio = 1500;
            Producto2.Existencia = 15;
            Producto2.Activo = true;

            ListaProductos.Add(Producto2);

            //Producto3
            var Producto3 = new Producto();
            Producto3.ID = 3;
            Producto3.Descripcion = "Jeans";
            Producto3.Precio = 600;
            Producto3.Existencia = 50;
            Producto3.Activo = true;

            ListaProductos.Add(Producto3);

            //Producto4 
            var Producto4 = new Producto();
            Producto4.ID = 4;
            Producto4.Descripcion = "Calcetines";
            Producto4.Precio = 95;
            Producto4.Existencia = 20;
            Producto4.Activo = true;

            ListaProductos.Add(Producto4);

            /*Obtencion de Productos*/
        }
        public BindingList<Producto> ObtenerProductos()
        {
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

            if (producto.ID == 0)
            {
                /*Funcion max se encarga de buscar  todos los productos y calcula el maximo id que encuentra*/
                producto.ID = ListaProductos.Max(item => item.ID) + 1;
            }
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

            foreach (var producto in ListaProductos)
            {
                if (producto.ID == id)
                {
                    ListaProductos.Remove(producto);
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
    