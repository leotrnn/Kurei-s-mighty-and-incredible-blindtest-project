using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KureiBlindTest
{
    public partial class FrmSummary : Form
    {
        Styles styles = new Styles();
        private bool isUserClosing = false;
        public FrmSummary()
        {
            InitializeComponent();
            this.FormClosing += FrmChoiceCategory_FormClosing;
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

        private void FrmChoiceCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isUserClosing && e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void pbxGoBack_Click(object sender, EventArgs e)
        {
            isUserClosing = true;

            this.Close();

            FrmChoiceDifficulty frmChoiceDifficulty = new FrmChoiceDifficulty();
            frmChoiceDifficulty.ShowDialog();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            isUserClosing = true;

            this.Close();

            frmHome frmHome = new frmHome();
            frmHome.ShowDialog();
        }

     
    }
}
