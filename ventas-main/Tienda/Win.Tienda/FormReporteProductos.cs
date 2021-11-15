using BL.Tienda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.Tienda
{
    public partial class FormReporteProductos : Form
    {
        public FormReporteProductos()
        {
            InitializeComponent();

            //*Creacion de variables*//
            var _productoBl = new ProductosBL();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = _productoBl.ObtenerProductos(); //* Con eso llenamos el bindingsorce*//

            var reporte = new ReporteProductos();  //*Creamos un reporte*//
            reporte.SetDataSource(bindingSource);

            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport(); //*Este refresh genera el reporte al final*//



        }

      
    }
}
