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

            List<Control> lstControls = new List<Control>
            {
                lblTitle, lblSummaryCategory, lblSummaryDifficulty
            };
            styles.LoadStyle(lstControls, this.ClientSize.Width);
            this.BackColor = styles.ColorBack;

            lblSummaryCategory.Text = "Category : " + Properties.Settings.Default.Category;
            lblSummaryDifficulty.Text = "Difficulty : " + Properties.Settings.Default.Difficulty;

            this.FormClosing += FrmChoiceCategory_FormClosing;
        }

        private void FrmChoiceCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isUserClosing && e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}
