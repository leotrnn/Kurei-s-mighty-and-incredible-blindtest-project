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
        public void LoadStyle(List<Control> lstControls, int frmWidth)
        {
            this.CustomControls(lstControls, frmWidth);
        }

        public void LoadChoices(List<Control> lstControls, int frmWidth)
        {
            this.CustomChoices(lstControls, frmWidth);
        }

        private void CustomChoices(List<Control> lstControls, int frmWidth)
        {
            int positionX;

            foreach (Control obj in lstControls)
            {
                positionX = (frmWidth - obj.Width) / 2;
                obj.Location = new Point(positionX, obj.Location.Y);

                switch (obj)
                {
                    case Button button:
                        this.LoadCustomFont(button, 20f, colorFont);
                        button.BackColor = colorBack;
                        button.FlatStyle = FlatStyle.Flat;
                        button.FlatAppearance.BorderSize = 0;
                        button.FlatAppearance.MouseDownBackColor = Color.Transparent;
                        button.FlatAppearance.MouseOverBackColor = colorBackOver;
                        break;
                }
            }
        }

        private void CustomControls(List<Control> lstControls, int frmWidth)
        {
            int positionX;

            foreach (Control obj in lstControls)
            {
                positionX = (frmWidth - obj.Width) / 2;
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
    }
}
