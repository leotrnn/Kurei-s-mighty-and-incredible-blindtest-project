using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KureiBlindTest
{
    public partial class FrmSummary : Form
    {
        Styles styles = new Styles();

        public FrmSummary()
        {
            InitializeComponent();
        }

        private void FrmSummary_Load(object sender, EventArgs e)
        {
           // styles.CustomizeButton(btnStart);
           // styles.LoadCustomFont(lblTitle, 32f, styles.ColorFont);
            //styles.LoadCustomFont(lblSummaryDifficulty, 20f, styles.ColorFont);
            //styles.LoadCustomFont(lblSummaryCategory, 20f, styles.ColorFont);

            //this.BackColor = styles.ColorBack;

            lblSummaryCategory.Text = "Category : " + Properties.Settings.Default.Category;
            lblSummaryDifficulty.Text = "Difficulty : " + Properties.Settings.Default.Difficulty;
        }

       

        private void pbxGoBack_Click(object sender, EventArgs e)
        {
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
         
        }







    }
}
