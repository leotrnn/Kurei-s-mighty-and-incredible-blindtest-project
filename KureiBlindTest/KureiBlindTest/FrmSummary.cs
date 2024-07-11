using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KureiBlindTest
{
    public partial class FrmSummary : Form
    {
        Styles styles = new Styles();
        private NavigationService navigationService;

        public FrmSummary(NavigationService navService)
        {
            InitializeComponent();
            navigationService = navService; 
        }

        private void FrmSummary_Load(object sender, EventArgs e)
        {
         

            lblSummaryCategory.Text = "Category : " + Properties.Settings.Default.Category;
            lblSummaryDifficulty.Text = "Difficulty : " + Properties.Settings.Default.Difficulty;
        }

       

        private void pbxGoBack_Click(object sender, EventArgs e)
        {
            navigationService.NavigateBack();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            FrmGame gameForm = new FrmGame(navigationService);
            navigationService.NavigateTo(gameForm);
        }







    }
}
