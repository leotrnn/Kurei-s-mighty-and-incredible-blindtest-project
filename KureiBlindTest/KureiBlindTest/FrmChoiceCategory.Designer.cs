namespace KureiBlindTest
{
    partial class FrmChoiceCategory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChoiceCategory));
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnGenres = new System.Windows.Forms.Button();
            this.btnArtists = new System.Windows.Forms.Button();
            this.pbxArtistsArrow = new System.Windows.Forms.PictureBox();
            this.pbxGenresArrow = new System.Windows.Forms.PictureBox();
            this.pbxGoBack = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArtistsArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGenresArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGoBack)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTitle.Location = new System.Drawing.Point(12, 38);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(590, 80);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Choose a category";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGenres
            // 
            this.btnGenres.Location = new System.Drawing.Point(15, 140);
            this.btnGenres.Name = "btnGenres";
            this.btnGenres.Size = new System.Drawing.Size(543, 65);
            this.btnGenres.TabIndex = 6;
            this.btnGenres.Text = "Genres";
            this.btnGenres.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenres.UseVisualStyleBackColor = true;
            this.btnGenres.Click += new System.EventHandler(this.btnGenres_Click);
            this.btnGenres.Paint += new System.Windows.Forms.PaintEventHandler(this.btnGenres_Paint);
            // 
            // btnArtists
            // 
            this.btnArtists.Location = new System.Drawing.Point(15, 211);
            this.btnArtists.Name = "btnArtists";
            this.btnArtists.Size = new System.Drawing.Size(543, 65);
            this.btnArtists.TabIndex = 7;
            this.btnArtists.Text = "Artists";
            this.btnArtists.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArtists.UseVisualStyleBackColor = true;
            this.btnArtists.Click += new System.EventHandler(this.btnArtists_Click);
            this.btnArtists.Paint += new System.Windows.Forms.PaintEventHandler(this.btnGenres_Paint);
            // 
            // pbxArtistsArrow
            // 
            this.pbxArtistsArrow.BackColor = System.Drawing.Color.Transparent;
            this.pbxArtistsArrow.Image = ((System.Drawing.Image)(resources.GetObject("pbxArtistsArrow.Image")));
            this.pbxArtistsArrow.Location = new System.Drawing.Point(551, 227);
            this.pbxArtistsArrow.Name = "pbxArtistsArrow";
            this.pbxArtistsArrow.Size = new System.Drawing.Size(35, 35);
            this.pbxArtistsArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxArtistsArrow.TabIndex = 9;
            this.pbxArtistsArrow.TabStop = false;
            this.pbxArtistsArrow.Click += new System.EventHandler(this.btnArtists_Click);
            // 
            // pbxGenresArrow
            // 
            this.pbxGenresArrow.BackColor = System.Drawing.Color.Transparent;
            this.pbxGenresArrow.Image = global::KureiBlindTest.Properties.Resources.rightArrow;
            this.pbxGenresArrow.Location = new System.Drawing.Point(551, 154);
            this.pbxGenresArrow.Name = "pbxGenresArrow";
            this.pbxGenresArrow.Size = new System.Drawing.Size(35, 35);
            this.pbxGenresArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxGenresArrow.TabIndex = 8;
            this.pbxGenresArrow.TabStop = false;
            this.pbxGenresArrow.Click += new System.EventHandler(this.btnGenres_Click);
            // 
            // pbxGoBack
            // 
            this.pbxGoBack.Image = ((System.Drawing.Image)(resources.GetObject("pbxGoBack.Image")));
            this.pbxGoBack.Location = new System.Drawing.Point(15, 569);
            this.pbxGoBack.Name = "pbxGoBack";
            this.pbxGoBack.Size = new System.Drawing.Size(60, 60);
            this.pbxGoBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxGoBack.TabIndex = 3;
            this.pbxGoBack.TabStop = false;
            this.pbxGoBack.Click += new System.EventHandler(this.pbxGoBack_Click);
            // 
            // FrmChoiceCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(614, 640);
            this.Controls.Add(this.pbxArtistsArrow);
            this.Controls.Add(this.pbxGenresArrow);
            this.Controls.Add(this.btnArtists);
            this.Controls.Add(this.btnGenres);
            this.Controls.Add(this.pbxGoBack);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmChoiceCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kurei\'s Blind test - Category choice";
            this.Load += new System.EventHandler(this.FrmChoiceCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxArtistsArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGenresArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGoBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbxGoBack;
        private System.Windows.Forms.Button btnGenres;
        private System.Windows.Forms.Button btnArtists;
        private System.Windows.Forms.PictureBox pbxGenresArrow;
        private System.Windows.Forms.PictureBox pbxArtistsArrow;
    }
}