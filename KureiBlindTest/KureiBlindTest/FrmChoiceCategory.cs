using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KureiBlindTest
{
    public partial class FrmChoiceCategory : Form
    {
        Styles styles = new Styles();
        private bool isUserClosing = false;


        public FrmChoiceCategory()
        {
            InitializeComponent();

            List<Control> lstControls = new List<Control>
            {
                lblTitle
            };

            List<Control> lstChoices = new List<Control>
            {
                btnArtists, btnGenres
            };

            styles.LoadChoices(lstChoices, this.ClientSize.Width);
            styles.LoadStyle(lstControls, this.ClientSize.Width);
            this.BackColor = styles.ColorBack;

            this.FormClosing += FrmChoiceCategory_FormClosing;
        }

        private void pbxGoBack_Click(object sender, EventArgs e)
        {
            isUserClosing = true;

            this.Close();

            frmHome frmHome = new frmHome();
            frmHome.ShowDialog();
        }

        private void FrmChoiceCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isUserClosing && e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void btnGenres_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            int borderWidth = 2;
            Color borderColor = styles.ColorFont;

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.DrawLine(pen, 0, btn.Height - borderWidth, btn.Width, btn.Height - borderWidth);
            }
        }

        private void btnGenres_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Category = "Genres";

            this.Hide();

            FrmChoiceDifficulty frmChoice = new FrmChoiceDifficulty();

            frmChoice.ShowDialog();
        }

        private void btnArtists_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Category = "Artists";

            this.Hide();

            FrmChoiceDifficulty frmChoice = new FrmChoiceDifficulty();

            frmChoice.ShowDialog();

        }
    }
}
