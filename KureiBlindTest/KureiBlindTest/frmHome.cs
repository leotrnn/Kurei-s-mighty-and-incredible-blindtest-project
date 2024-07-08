using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;

namespace KureiBlindTest
{
    public partial class frmHome : Form
    {
        private Color colorBack = Color.FromArgb(11, 1, 12);
        private Color colorFont = Color.FromArgb(191, 199, 174);
        private Color colorThird = Color.FromArgb(90, 6, 94);

        public frmHome()
        {
            InitializeComponent();
            this.LoadStyle();
        }

        private void LoadStyle()
        {
            this.BackColor = colorBack;
            this.CustomControls();
        }

        private void CustomControls()
        {
            List<Control> lstObjetcsToCenter = new List<Control>
            {
                pbxLogo, lblTitle, btnPlay, btnQuit
            };

            int positionX;

            foreach (Control obj in lstObjetcsToCenter)
            {
                positionX = (this.ClientSize.Width - obj.Width) / 2;
                obj.Location = new Point(positionX, obj.Location.Y);

                switch (obj)
                {
                    case Label label:
                        this.LoadCustomFont(label, 32f, colorFont);
                        break;

                    case Button button:
                        button.BackColor = colorFont;
                        button.FlatStyle = FlatStyle.Flat;
                        button.FlatAppearance.BorderSize = 0;
                        this.LoadCustomFont(button, 22f, colorBack);
                        break;
                }
            }
        }

        private void LoadCustomFont(Control objectToCustom, float sizeFont, Color colorFont)
        {
            try
            {
                string cheminPolice = Path.Combine(Application.StartupPath, "fonts", "Outfit-Bold.ttf");
                PrivateFontCollection pfc = new PrivateFontCollection();
                pfc.AddFontFile(cheminPolice);

                Font policeCustom = new Font(pfc.Families[0], sizeFont, FontStyle.Regular);

                objectToCustom.Font = policeCustom;
                objectToCustom.ForeColor = colorFont;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement de la police personnalisée : " + ex.Message);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
