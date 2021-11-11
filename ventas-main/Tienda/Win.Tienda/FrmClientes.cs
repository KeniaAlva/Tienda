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

    public partial class FormClientes : Form
    {
        ClientesBL _clientesBL;
        private object idTextBox;
        private string cliente;

        public FormClientes()
        {
            InitializeComponent();

            _clientesBL = new ClientesBL();
            ListaClientesBindingSource.DataSource = _clientesBL.ObtenerClientes();
        }


        private void bindingNavigatorAddNewItem_Click_1(object sender, EventArgs e)
        {
            ListaClientesBindingSource.EndEdit();
            var cliente = (Cliente)ListaClientesBindingSource.Current;

            var resultado = _clientesBL.GuardarCliente(cliente);

            if (resultado.Exitoso == true)
            {
                ListaClientesBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
                MessageBox.Show("Cliente guardado");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }

        private void bindingNavigatorDeleteItem_Click_1(object sender, EventArgs e)
        {
            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("Desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            _clientesBL.CancelarCambios();
            DeshabilitarHabilitarBotones(true);
        }

         private void DeshabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripButton1.Visible = !valor;
        }

        private void Eliminar(int id)
        {
            var resultado = _clientesBL.EliminarCliente(id);

            if (resultado == true)
            {
                ListaClientesBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al eliminar el Cliente");
            }
        }

        private void listaClientesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            var cliente = (ClientesBL)ListaClientesBindingSource.Current;
            var resultado = _clientesBL.GuardarCliente(cliente);

            if (resultado = true)
            {
                ListaClientesBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrió un error guardando el cliente.");
            }
        }
    }
}
