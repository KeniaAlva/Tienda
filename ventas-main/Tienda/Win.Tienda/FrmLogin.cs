using BLTienda;
using System;
using System.Windows.Forms;

namespace win.Tienda
{
    public partial class FrmLogin : Form
    {
        SeguridadBL _seguridad;

        public FrmLogin()
        {
            InitializeComponent();
            _seguridad = new SeguridadBL();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario;
            string contrasena;

            usuario = textBox1.Text;
            contrasena = textBox2.Text;

            button1.Enabled = false;
            button1.Text = "Verificando. . .";
            Application.DoEvents();


            var resultado = _seguridad.Autorizar(usuario, contrasena);

            if (resultado == true)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña incorrecta");
            }
        }
    }
}
