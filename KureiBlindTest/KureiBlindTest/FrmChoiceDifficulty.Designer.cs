namespace KureiBlindTest
{
    partial class FrmChoiceDifficulty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChoiceDifficulty));
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnEasy = new System.Windows.Forms.Button();
            this.btnMedium = new System.Windows.Forms.Button();
            this.btnHard = new System.Windows.Forms.Button();
            this.pbxHard = new System.Windows.Forms.PictureBox();
            this.pbxMedium = new System.Windows.Forms.PictureBox();
            this.pbxEasy = new System.Windows.Forms.PictureBox();
            this.pbxGoBack = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMedium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEasy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGoBack)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblTitle.Location = new System.Drawing.Point(12, 38);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(590, 80);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Choose the difficulty";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEasy
            // 
            this.btnEasy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEasy.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold);
            this.btnEasy.ForeColor = System.Drawing.Color.Black;
            this.btnEasy.Location = new System.Drawing.Point(15, 140);
            this.btnEasy.Name = "btnEasy";
            this.btnEasy.Size = new System.Drawing.Size(543, 65);
            this.btnEasy.TabIndex = 6;
            this.btnEasy.Text = "Easy";
            this.btnEasy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEasy.UseVisualStyleBackColor = false;
            this.btnEasy.Click += new System.EventHandler(this.btnEasy_Click);
            this.btnEasy.Paint += new System.Windows.Forms.PaintEventHandler(this.btnEasy_Paint);
            // 
            // btnMedium
            // 
            this.btnMedium.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnMedium.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold);
            this.btnMedium.Location = new System.Drawing.Point(15, 211);
            this.btnMedium.Name = "btnMedium";
            this.btnMedium.Size = new System.Drawing.Size(543, 65);
            this.btnMedium.TabIndex = 7;
            this.btnMedium.Text = "Medium";
            this.btnMedium.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMedium.UseVisualStyleBackColor = false;
            this.btnMedium.Click += new System.EventHandler(this.btnMedium_Click);
            this.btnMedium.Paint += new System.Windows.Forms.PaintEventHandler(this.btnEasy_Paint);
            // 
            // btnHard
            // 
            this.btnHard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnHard.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold);
            this.btnHard.Location = new System.Drawing.Point(15, 282);
            this.btnHard.Name = "btnHard";
            this.btnHard.Size = new System.Drawing.Size(543, 65);
            this.btnHard.TabIndex = 10;
            this.btnHard.Text = "Hard";
            this.btnHard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHard.UseVisualStyleBackColor = false;
            this.btnHard.Click += new System.EventHandler(this.btnHard_Click);
            this.btnHard.Paint += new System.Windows.Forms.PaintEventHandler(this.btnEasy_Paint);
            // 
            // pbxHard
            // 
            this.pbxHard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pbxHard.Image = global::KureiBlindTest.Properties.Resources.rightArrow;
            this.pbxHard.Location = new System.Drawing.Point(513, 298);
            this.pbxHard.Name = "pbxHard";
            this.pbxHard.Size = new System.Drawing.Size(35, 35);
            this.pbxHard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxHard.TabIndex = 11;
            this.pbxHard.TabStop = false;
            this.pbxHard.Click += new System.EventHandler(this.btnHard_Click);
            // 
            // pbxMedium
            // 
            this.pbxMedium.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pbxMedium.Image = global::KureiBlindTest.Properties.Resources.rightArrow;
            this.pbxMedium.Location = new System.Drawing.Point(513, 228);
            this.pbxMedium.Name = "pbxMedium";
            this.pbxMedium.Size = new System.Drawing.Size(35, 35);
            this.pbxMedium.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxMedium.TabIndex = 9;
            this.pbxMedium.TabStop = false;
            this.pbxMedium.Click += new System.EventHandler(this.btnMedium_Click);
            // 
            // pbxEasy
            // 
            this.pbxEasy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pbxEasy.Image = global::KureiBlindTest.Properties.Resources.rightArrow;
            this.pbxEasy.Location = new System.Drawing.Point(513, 154);
            this.pbxEasy.Name = "pbxEasy";
            this.pbxEasy.Size = new System.Drawing.Size(35, 35);
            this.pbxEasy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxEasy.TabIndex = 8;
            this.pbxEasy.TabStop = false;
            this.pbxEasy.Click += new System.EventHandler(this.btnEasy_Click);
            // 
            // pbxGoBack
            // 
            this.pbxGoBack.Image = global::KureiBlindTest.Properties.Resources.leftArrow;
            this.pbxGoBack.Location = new System.Drawing.Point(15, 569);
            this.pbxGoBack.Name = "pbxGoBack";
            this.pbxGoBack.Size = new System.Drawing.Size(60, 60);
            this.pbxGoBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxGoBack.TabIndex = 3;
            this.pbxGoBack.TabStop = false;
            this.pbxGoBack.Click += new System.EventHandler(this.pbxGoBack_Click);
            // 
            // FrmChoiceDifficulty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(614, 640);
            this.Controls.Add(this.pbxHard);
            this.Controls.Add(this.btnHard);
            this.Controls.Add(this.pbxMedium);
            this.Controls.Add(this.pbxEasy);
            this.Controls.Add(this.btnMedium);
            this.Controls.Add(this.btnEasy);
            this.Controls.Add(this.pbxGoBack);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmChoiceDifficulty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kurei\'s Blind test - Category choice";
            this.Load += new System.EventHandler(this.FrmChoiceDifficulty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxHard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMedium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEasy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGoBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbxGoBack;
        private System.Windows.Forms.Button btnEasy;
        private System.Windows.Forms.Button btnMedium;
        private System.Windows.Forms.PictureBox pbxEasy;
        private System.Windows.Forms.PictureBox pbxMedium;
        private System.Windows.Forms.PictureBox pbxHard;
        private System.Windows.Forms.Button btnHard;
    }
}