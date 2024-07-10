using System;
using System.Windows.Forms;

namespace KureiBlindTest
{
    public partial class FrmSummary : Form
    {
        Styles styles = new Styles();

        public FrmSummary()
        {
            InitializeComponent();
            this.FormClosing += FrmSummary_FormClosing;
        }

        private void FrmSummary_Load(object sender, EventArgs e)
        {
            styles.CustomizeButton(btnStart);
            styles.LoadCustomFont(lblTitle, 32f, styles.ColorFont);
            styles.LoadCustomFont(lblSummaryDifficulty, 20f, styles.ColorFont);
            styles.LoadCustomFont(lblSummaryCategory, 20f, styles.ColorFont);

            this.BackColor = styles.ColorBack;

            lblSummaryCategory.Text = "Category : " + Properties.Settings.Default.Category;
            lblSummaryDifficulty.Text = "Difficulty : " + Properties.Settings.Default.Difficulty;
        }

        private void FrmSummary_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && Program.FormStack.Count == 1)
            {
                Application.Exit();
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.Hide();

            FrmGame frmGame = new FrmGame();
            frmGame.StartPosition = FormStartPosition.CenterParent; // Centrer par rapport au parent
            frmGame.FormClosed += (s, args) => Application.Exit();
            frmGame.ShowDialog(this); // Utiliser ShowDialog avec le parent défini
        }

    }
}
