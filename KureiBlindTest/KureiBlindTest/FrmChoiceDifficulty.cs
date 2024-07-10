using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KureiBlindTest
{
    public partial class FrmChoiceDifficulty : Form
    {
        Styles styles = new Styles();

        public FrmChoiceDifficulty()
        {
            InitializeComponent();
            this.FormClosing += FrmChoiceCategory_FormClosing;
        }

        private void FrmChoiceDifficulty_Load(object sender, EventArgs e)
        {
            styles.LoadCustomFont(lblTitle, 32f, styles.ColorFont);
            styles.CenterControl(lblTitle, this.ClientSize.Width);
            styles.CustomizeChoice(btnEasy);
            styles.CustomizeChoice(btnMedium);
            styles.CustomizeChoice(btnHard);


            this.BackColor = styles.ColorBack;
            btnEasy.ForeColor = Color.Green;
            btnMedium.ForeColor = Color.Yellow;
            btnHard.ForeColor = Color.Red;
        }

     

        private void FrmChoiceCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && Program.FormStack.Count == 1)
            {
                Application.Exit();
            }
        }

        private void btnEasy_Paint(object sender, PaintEventArgs e)
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

        private void btnEasy_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Difficulty = "Easy";

            this.Hide();

            FrmSummary frmSummary = new FrmSummary();
            Program.FormStack.Push(frmSummary);
            frmSummary.StartPosition = FormStartPosition.CenterParent; // Centrer par rapport au parent
            frmSummary.FormClosed += (s, args) => this.Show();
            frmSummary.ShowDialog(this); // Utiliser ShowDialog avec le parent défini
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Difficulty = "Medium";

            this.Hide();

            FrmSummary frmSummary = new FrmSummary();
            Program.FormStack.Push(frmSummary);
            frmSummary.StartPosition = FormStartPosition.CenterParent; // Centrer par rapport au parent
            frmSummary.FormClosed += (s, args) => this.Show();
            frmSummary.ShowDialog(this); // Utiliser ShowDialog avec le parent défini
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Difficulty = "Hard";

            this.Hide();

            FrmSummary frmSummary = new FrmSummary();
            Program.FormStack.Push(frmSummary);
            frmSummary.StartPosition = FormStartPosition.CenterParent; // Centrer par rapport au parent
            frmSummary.FormClosed += (s, args) => this.Show();
            frmSummary.ShowDialog(this); // Utiliser ShowDialog avec le parent défini
        }



    }
}
