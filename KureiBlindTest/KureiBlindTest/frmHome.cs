using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;

namespace KureiBlindTest
{
    public partial class frmHome : Form
    {
        Styles styles = new Styles();

        public frmHome()
        {
            InitializeComponent();
            
            List<Control> lstControls = new List<Control>
            {
                pbxLogo, lblTitle, btnPlay, btnQuit
            };

            foreach(Control c in lstControls)
            {
                styles.CenterControl(c, this.ClientSize.Width);
            }

            styles.CustomizeButton(btnPlay);
            styles.CustomizeButton(btnQuit);
            styles.LoadCustomFont(lblTitle, 32f, styles.ColorFont);

            this.BackColor = styles.ColorBack;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            this.Hide();

            FrmChoiceCategory frmChoice = new FrmChoiceCategory();

            frmChoice.ShowDialog();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

    }
}
