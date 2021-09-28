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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            Login();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            var FrmLogin = new FrmLogin();
            FrmLogin.ShowDialog();
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FrmVentas = new FrmVentas(); 
            FrmVentas.MdiParent = this;
            FrmVentas.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FrmArticulos = new FrmArticulos();
            FrmArticulos.MdiParent = this;
            FrmArticulos.Show();
        }

        private void facturaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FrmPagos = new FrmPagos();
            FrmPagos.MdiParent = this;
            FrmPagos.Show();
        }

        private void clienteExistenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FrmClientes = new FrmClientes();
            FrmClientes.MdiParent = this;
            FrmClientes.Show();
        }
    }
}
