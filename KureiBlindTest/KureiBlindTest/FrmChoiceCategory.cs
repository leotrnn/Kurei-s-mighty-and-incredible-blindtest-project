using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KureiBlindTest
{
    public partial class FrmChoiceCategory : Form
    {
        Styles styles = new Styles();

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

      

        private void FrmChoiceCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && Program.FormStack.Count == 1)
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

        private void pbxGoBack_Click(object sender, EventArgs e)
        {
            Console.WriteLine(Program.FormStack.Count);
            if (Program.FormStack.Count > 1)
            {
                Form currentForm = Program.FormStack.Pop();
                currentForm.Hide(); // Cache le formulaire courant avant de le supprimer de la pile

                Form previousForm = Program.FormStack.Peek();
                previousForm.Show(); // Affiche le formulaire précédent
            }
            else
            {
                Application.Exit();
            }
        }



        private void btnGenres_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Category = "Genres";

            this.Hide();

            FrmChoiceDifficulty frmChoice = new FrmChoiceDifficulty();
            Program.FormStack.Push(frmChoice);
            frmChoice.StartPosition = FormStartPosition.CenterParent; // Centrer par rapport au parent
            frmChoice.FormClosed += (s, args) => this.Show();
            frmChoice.ShowDialog(this); // Utiliser ShowDialog avec le parent défini
        }

        private void btnArtists_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Category = "Artists";

            this.Hide();

            FrmChoiceDifficulty frmChoice = new FrmChoiceDifficulty();
            Program.FormStack.Push(frmChoice);
            frmChoice.StartPosition = FormStartPosition.CenterParent; // Centrer par rapport au parent
            frmChoice.FormClosed += (s, args) => this.Show();
            frmChoice.ShowDialog(this); // Utiliser ShowDialog avec le parent défini
        }



    }
}
