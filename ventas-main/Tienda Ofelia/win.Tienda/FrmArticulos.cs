using BLTienda;
using System;
using System.Drawing;
using System.IO;
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

        /*Tercer avance Yorlani Alva*/
        //Creando la función guardar
        private void listaProductosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaProductosBindingSource.EndEdit();//Funcion para editar el nombre del nuevo producto
            var producto = (Producto)listaProductosBindingSource.Current;

            //Parte6 para guardar la foto en los registros
            if (fotoPictureBox.Image != null)
            {
                producto.Foto = Program.imageToByteArray(fotoPictureBox.Image);//Instanciando clase Program y convirtiendo la imagen a un arreglo de tipo byte
            }
            else
            {
                producto.Foto = null;
            }


            var resultado = _productos.GuardarProducto(producto);

            if (resultado.Exitoso == true)
            {
                listaProductosBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
                MessageBox.Show("Registro guardado correctamente :)");//Mensaje cuando guardas registro de  producto
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }

        //Agregamos un método
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _productos.AgregarProducto();
            listaProductosBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);
        }

        //Configuracion de los botones del formulario articulos
        private void DeshabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripButtonCancelar.Visible = !valor;

        }

        //conversión de entero
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            //estructura de confirmacion de sí o no para eliminar un registro
            if (iDTextBox.Text != "")
            {
                var resultado = MessageBox.Show("¿Desea eliminar este registo?", "Eliminar", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(iDTextBox.Text);
                    Eliminar(id);
                }
            }
        }

        private void Eliminar(int id)
        {
            var resultado = _productos.EliminarProducto(id);

            if (resultado == true)
            {
                listaProductosBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al eliminar el producto");
            }

        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotones(true);
            Eliminar(0);
        }

        private void button1_Click(object sender, EventArgs e)/*Configuracion del boton "Agregar Foto"*/
        {
            var producto = (Producto)listaProductosBindingSource.Current;//Parte 6

            if (producto != null)
            {
                openFileDialog1.ShowDialog();
                var archivo = openFileDialog1.FileName;

                if (archivo != "")
                {
                    var fileInfo = new FileInfo(archivo);//FileInfo permite obtener la informacion del archivo (archivo) es la ruta
                    var fileStream = fileInfo.OpenRead();//FileSteam es ver y leer un archivo por partes

                    fotoPictureBox.Image = Image.FromStream(fileStream);//asignando el archivo a la caja de imagen del formulario
                }
                else
                {
                    MessageBox.Show("Antes de agregar una imagen necesita crear un nuevo producto.");
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)/*Configuracion para el botón "Remover foto"*/
        {
            fotoPictureBox.Image = null; //La imagen en la caja del formulario se anula
        }
    }
}
