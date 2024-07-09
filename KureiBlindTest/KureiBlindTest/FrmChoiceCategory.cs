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
            this.FormClosing += FrmChoiceCategory_FormClosing;
        }

        private void FrmChoiceCategory_Load(object sender, EventArgs e)
        {
            styles.LoadCustomFont(lblTitle, 32f, styles.ColorFont);
            styles.CenterControl(lblTitle, this.ClientSize.Width);
            styles.CustomizeChoice(btnArtists);
            styles.CustomizeChoice(btnGenres);

            this.BackColor = styles.ColorBack;
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
