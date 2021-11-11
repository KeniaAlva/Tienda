using System.ComponentModel;
using System.Data.Entity;
using static BLTienda.CategoriasBL;

namespace BLTienda
{
    public class ProductosBL
    {
        Contexto _contexto;//Declaramos variable contexto

        /*Creacion de Lista Binding (arreglo) para los productos*/
       public BindingList<Producto> ListaProductos { get; set; }


        public ProductosBL()
        {
            _contexto = new Contexto();//Instanciamos el contexto en el constructor

            /*Instanciamos la lista*/
            ListaProductos = new BindingList<Producto>();

            /****Se han eliminado los datos de prueba****/
             
        /*Obtencion de Productos*/
        }
        public BindingList<Producto> ObtenerProductos()
        {
            _contexto.Productos.Load();//Cargando datos a la tabla
            ListaProductos = _contexto.Productos.Local.ToBindingList();//Llenar la lista

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

            _contexto.SaveChanges(); //Agregando la clase contexto de nuestra base de datos y guardar cambios

            resultado.Exitoso = true;
            return resultado;
        }

        //Agregamos producto BL en una clase
        public void AgregarProducto()
        {
            var nuevoProducto = new Producto();
            ListaProductos.Add(nuevoProducto);
        }   

        /*Creamos la clase para eliminar un producto YA*/
        public bool EliminarProducto(int id)
        {
            foreach (var producto in ListaProductos) //Foreach es una funcion que recorre listas de objetos
            {
                if (producto.ID == id)
                {
                    ListaProductos.Remove(producto);
                    _contexto.SaveChanges();//Se guardan los cambios para la base de datos contexto
                    return true;
                }
            }

            return false;
        }

        /* Creamos un metodo de tipo privado de resultado que se encargara de validar un producto*/
        private Resultado Validar(Producto producto)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (string.IsNullOrEmpty(producto.Descripcion) == true)
            {
             resultado.Mensaje = "Ingrese una descripcion";
             resultado.Exitoso = false;
            }

            if (producto.Existencia < 0)
            {
             resultado.Mensaje = "La existencia debe ser mayor a cero";
            resultado.Exitoso = false;
            }
            
           if (producto.Precio < 0)
            {
             resultado.Mensaje = "El precio debe ser mayor a cero";
             resultado.Exitoso = false;
            }

        return resultado;

        }
    }

    /*Propiedades de los productos*/
    public class Producto
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }
        public int CategoriaId { get; set; }//Campo foráneo
        public Categoria Categoria { get; set;}//relacionando datos de tabla categorias a productosbl
        public int TipoId { get; set; }
        public Tipo Tipo { get; set; }
        public bool Activo { get; set; }
        public byte[] Foto { get; set; } /*Parte 6: Agregando una foto a las propiedades de los productos*/

        public Producto()
        {
            Activo = true;
        }
    }

    /*Creamos una clase nueva que tendra un resultado exitoso o un mensaje YA*/
    public class Resultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }
   }

    