using System;
using System.Windows.Forms;

namespace KureiBlindTest
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmHome homeForm = new frmHome();
            NavigationService navigationService = new NavigationService(homeForm);
            homeForm.SetNavigationService(navigationService);

            Application.Run(homeForm);
        }
    }
}
