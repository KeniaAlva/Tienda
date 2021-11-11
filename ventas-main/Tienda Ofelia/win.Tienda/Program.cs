using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace win.Tienda
{
    static class Program
    {
        private static MemoryStream ms;

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMenu());
        }

        public static byte[] imageToByteArray(Image ImageIn)/*Parte6: Funcion para guardar la imagen del formulario articulos*/
        {
            var  ms = new MemoryStream();
            ImageIn.Save(ms, ImageIn.RawFormat);//Opcion para guardar la imagen en MemoryStream

            return ms.ToArray();//El memory stream se convierte en arreflo
        }
    }
}
