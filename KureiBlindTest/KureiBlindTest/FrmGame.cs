using System;
using System.Windows.Forms;

namespace KureiBlindTest
{
    public partial class FrmGame : Form
    {
        Styles styles = new Styles();
        private int _nround;
        public int Nround { get => _nround; set => _nround = value; }

        public FrmGame()
        {
            Nround = 1;
            InitializeComponent();
            this.FormClosing += FrmGame_FormClosing;
            this.StartPosition = FormStartPosition.CenterParent; // Centrer par rapport au parent
        }

        public void UpdateUI()
        {
            lblTitle.Text = $"Round N°{Nround}";
        }

        private void FrmGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }


        private void FrmGame_Load(object sender, EventArgs e)
        {
            UpdateUI();
            this.BackColor = styles.ColorBack;
            styles.CenterControl(lblTitle, this.ClientSize.Width);
            styles.CenterControl(pbxLogo, this.ClientSize.Width);
            styles.LoadCustomFont(lblTitle, 32f, styles.ColorFont);
        }

        
    }
}
