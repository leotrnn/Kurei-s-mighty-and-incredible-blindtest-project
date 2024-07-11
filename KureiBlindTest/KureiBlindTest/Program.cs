using KureiBlindTest;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal pour l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmHome()); // Remplacez "MainForm()" par le nom de votre formulaire principal
        }
    }
}
