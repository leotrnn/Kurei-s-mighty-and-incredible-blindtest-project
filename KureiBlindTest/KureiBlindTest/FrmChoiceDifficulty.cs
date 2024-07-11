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
        }

        private void FrmChoiceDifficulty_Load(object sender, EventArgs e)
        {
            //styles.LoadCustomFont(lblTitle, 32f, //styles.ColorFont);
            //styles.CenterControl(lblTitle, this.ClientSize.Width);
            //styles.CustomizeChoice(btnEasy);
            //styles.CustomizeChoice(btnMedium);
            //styles.CustomizeChoice(btnHard);


           // this.BackColor = //styles.ColorBack;
            btnEasy.ForeColor = Color.Green;
            btnMedium.ForeColor = Color.Yellow;
            btnHard.ForeColor = Color.Red;
        }

     

       

        private void btnEasy_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            int borderWidth = 2;
            Color borderColor = Color.Red; //styles.ColorFont;

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.DrawLine(pen, 0, btn.Height - borderWidth, btn.Width, btn.Height - borderWidth);
            }
        }

        private void pbxGoBack_Click(object sender, EventArgs e)
        {
        

        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Difficulty = "Easy";

        
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Difficulty = "Medium";

        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Difficulty = "Hard";

          
        }






    }
}
