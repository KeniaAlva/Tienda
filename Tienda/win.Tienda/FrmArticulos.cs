using BLTienda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace win.Tienda
{
    public partial class FrmArticulos : Form
    {
        /*Agregamos la variable de productos*/
        ProductosBL _productos;

        public FrmArticulos()
        {
            InitializeComponent();

            /*Inicializamos la variable de productos en nuestro constructor*/
            _productos = new ProductosBL();
            listaProductosBindingSource.DataSource = _productos.ObtenerProductos();//Enlaza y retorna a ProductosBL
        }

        private void FrmArticulos_Load(object sender, EventArgs e)
        {

        }

        private void listaProductosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            /* Tercer Avance Yorlany Alva*/
            /* Creando la funcion funcion guardar */

            listaProductosBindingSource.EndEdit();
            var producto = (Producto)listaProductosBindingSource.Current;

            var resultado = _productos.GuardarProducto(producto);

            if (resultado == true)
            {
                listaProductosBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error guardando el producto");
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            /* Agregaremos un metodo Yorlany Alva*/
            _productos.AgregarProducto();
            listaProductosBindingSource.MoveLast();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            /*  Como es un entero debemos  convertirlo*/
            var id = Convert.ToInt32(iDTextBox.Text);
            var resultado = _productos.EliminarProducto(id);
            {
                if (resultado == true)
                {
                    listaProductosBindingSource.ResetBindings(false);
                }

                else
                {
                    MessageBox.Show("Ocurrio un error al eliminar el producto ");
                }


            }
        }
    }

}