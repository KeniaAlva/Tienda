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

        public static byte[] imageToByteArray(Image ImageIn)
        {
            var ms = new MemoryStream();
            ImageIn.Save(ms, ImageIn.RawFormat);

            return ms.ToArray();
        }
    }
}
