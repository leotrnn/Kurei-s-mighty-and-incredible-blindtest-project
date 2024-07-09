using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KureiBlindTest
{
    internal class Styles
    {
        // Champs
        private Color colorBack = Color.FromArgb(11, 1, 12);
        private Color colorBackOver = Color.FromArgb(21, 11, 22);
        private Color colorFont = Color.FromArgb(191, 199, 174);
        private Color colorThird = Color.FromArgb(90, 6, 94);
        private Color colorFourth = Color.FromArgb(140, 147, 127);

        // Propriétés
        public Color ColorBack { get => colorBack; set => colorBack = value; }
        public Color ColorFont { get => colorFont; set => colorFont = value; }
        public Color ColorThird { get => colorThird; set => colorThird = value; }

        // Constructeur
        public Styles()
        {

        }

        // Méthodes

        public void CenterControl(Control control, int frmWidth)
        {
            int positionX = (frmWidth - control.Width) / 2;
            control.Location = new Point(positionX, control.Location.Y);
        }

        public void CustomizeChoice(Button btn)
        {
            this.LoadCustomFont(btn, 20f, colorFont);
            btn.BackColor = colorBack;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn.FlatAppearance.MouseOverBackColor = colorBackOver;
        }

        public void CustomizeButton(Button btn)
        {
            btn.BackColor = colorFont;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            this.LoadCustomFont(btn, 22f, colorBack);
        }

        public void LoadCustomFont(Control objectToCustom, float sizeFont, Color colorFont)
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
    }
}
