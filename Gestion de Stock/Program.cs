using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_de_Stock
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            const String appName = "Gestion de Stock Huilerie Sfax";
            bool createdNew = false;

            using (Mutex mtex = new Mutex(true, appName, out createdNew))

                if (createdNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FrmLogin());

                }
                else
                {

                    return;
                }
        }
    }
}
