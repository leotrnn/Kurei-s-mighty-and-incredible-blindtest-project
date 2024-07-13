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
        private NavigationService navigationService;

        public FrmChoiceDifficulty(NavigationService navService)
        {
            InitializeComponent();
            navigationService = navService;
        }

        private void FrmChoiceDifficulty_Load(object sender, EventArgs e)
        {
          
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
            navigationService.NavigateBack();
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Difficulty = "Easy";
            FrmSummary summaryForm = new FrmSummary(navigationService);
            navigationService.NavigateTo(summaryForm);

        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Difficulty = "Medium";
            FrmSummary summaryForm = new FrmSummary(navigationService);
            navigationService.NavigateTo(summaryForm);
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Difficulty = "Hard";
            FrmSummary summaryForm = new FrmSummary(navigationService);
            navigationService.NavigateTo(summaryForm);

        }






    }
}
