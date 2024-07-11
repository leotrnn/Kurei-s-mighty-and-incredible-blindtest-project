using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KureiBlindTest
{
    public partial class frmHome : Form
    {
        Styles styles = new Styles();

        public frmHome()
        {
            InitializeComponent();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            List<Control> lstControls = new List<Control>
            {
                pbxLogo, lblTitle, btnPlay, btnQuit
            };

            foreach (Control c in lstControls)
            {
                //styles.CenterControl(c, this.ClientSize.Width);
            }

            ////styles.CustomizeButton(btnPlay);
            ////styles.CustomizeButton(btnQuit);
            ////styles.LoadCustomFont(lblTitle, 32f, //styles.ColorFont);

            //this.BackColor = //styles.ColorBack;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btnPlay_Click(object sender, EventArgs e)
        {
          
        }


      
    }
}
