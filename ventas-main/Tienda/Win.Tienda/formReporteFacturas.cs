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
    public partial class formReporteFacturas : Form
    {
        public formReporteFacturas()
        {
            InitializeComponent();
            //*Creacion de variables*//
            var _facturasBl = new FacturaBL();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = _facturasBl.ObtenerFacturas(); //* Con eso llenamos el bindingsorce*//

            var reporte = new ReporteFacturas();  //*Creamos un reporte*//
            reporte.SetDataSource(bindingSource);

            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport(); //*Este refresh genera el reporte al final*//

        }
    }
}
