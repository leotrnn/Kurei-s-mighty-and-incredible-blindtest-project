using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KureiBlindTest
{
    static class Program
    {
        public static Stack<Form> FormStack = new Stack<Form>();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form homeForm = new frmHome();
            FormStack.Push(homeForm);
            Application.Run(homeForm);
        }
    }
}
