using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EliteKnightsAccount
{
    public static class Program
    {
        private static string nameProfile;
        private static bool isRun = true;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
