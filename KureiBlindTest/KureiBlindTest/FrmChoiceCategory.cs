using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KureiBlindTest
{
    public partial class FrmChoiceCategory : Form
    {
        Styles styles = new Styles();
        private NavigationService navigationService;

        public FrmChoiceCategory(NavigationService navService)
        {
            InitializeComponent();
            navigationService = navService;
        }

        private void FrmChoiceCategory_Load(object sender, EventArgs e)
        {            
        }      

        private void btnGenres_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            int borderWidth = 2;
            Color borderColor = Color.Red;//styles.ColorFont;

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.DrawLine(pen, 0, btn.Height - borderWidth, btn.Width, btn.Height - borderWidth);
            }
        }

        private void pbxGoBack_Click(object sender, EventArgs e)
        {
            navigationService.ResetToHome(); // Reset the navigation stack
            navigationService.NavigateBack();
        }

        private void btnGenres_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Category = "Genres";
            FrmChoiceDifficulty difficultyForm = new FrmChoiceDifficulty(navigationService);
            navigationService.NavigateTo(difficultyForm);
        }

        private void btnArtists_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Category = "Artists";
            FrmChoiceDifficulty difficultyForm = new FrmChoiceDifficulty(navigationService);
            navigationService.NavigateTo(difficultyForm);
        }




    }
}
