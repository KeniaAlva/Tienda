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
            Producto1. Precio = 65;
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
   }
    