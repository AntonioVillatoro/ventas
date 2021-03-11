using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.Lacteo
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
            Application.Run(new FormMenu());
        } 
        
        public static byte [] imageToByArray (Image imagein)
        {
            var ms = new MemoryStream();
            imagein.Save(ms, imagein.RawFormat);
            return ms.ToArray();
        } 
    }

}
