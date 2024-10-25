﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KureiBlindTest
{
    public partial class frmHome : Form
    {
        private NavigationService navigationService;
        Styles styles = new Styles();

        public frmHome()
        {
            InitializeComponent();
        }

        public void SetNavigationService(NavigationService navService)
        {
            navigationService = navService;
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            navigationService.ResetToHome(); // Reset the navigation stack
            FrmChoiceCategory categoryForm = new FrmChoiceCategory(navigationService);
            navigationService.NavigateTo(categoryForm);
        }
    }
}
