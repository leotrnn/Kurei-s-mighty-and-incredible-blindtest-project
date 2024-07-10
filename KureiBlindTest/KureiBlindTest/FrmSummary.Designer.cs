namespace KureiBlindTest
{
    partial class FrmSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSummary));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSummaryCategory = new System.Windows.Forms.Label();
            this.lblSummaryDifficulty = new System.Windows.Forms.Label();
            this.pbxGoBack = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGoBack)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTitle.Location = new System.Drawing.Point(12, 38);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(590, 80);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Summary";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSummaryCategory
            // 
            this.lblSummaryCategory.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblSummaryCategory.Location = new System.Drawing.Point(12, 155);
            this.lblSummaryCategory.Name = "lblSummaryCategory";
            this.lblSummaryCategory.Size = new System.Drawing.Size(590, 80);
            this.lblSummaryCategory.TabIndex = 4;
            this.lblSummaryCategory.Text = "Summary";
            this.lblSummaryCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSummaryDifficulty
            // 
            this.lblSummaryDifficulty.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblSummaryDifficulty.Location = new System.Drawing.Point(12, 235);
            this.lblSummaryDifficulty.Name = "lblSummaryDifficulty";
            this.lblSummaryDifficulty.Size = new System.Drawing.Size(590, 80);
            this.lblSummaryDifficulty.TabIndex = 5;
            this.lblSummaryDifficulty.Text = "Summary";
            this.lblSummaryDifficulty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbxGoBack
            // 
            this.pbxGoBack.Image = ((System.Drawing.Image)(resources.GetObject("pbxGoBack.Image")));
            this.pbxGoBack.Location = new System.Drawing.Point(15, 568);
            this.pbxGoBack.Name = "pbxGoBack";
            this.pbxGoBack.Size = new System.Drawing.Size(60, 60);
            this.pbxGoBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxGoBack.TabIndex = 6;
            this.pbxGoBack.TabStop = false;
            this.pbxGoBack.Click += new System.EventHandler(this.pbxGoBack_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(104, 372);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(390, 65);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // FrmSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(614, 640);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pbxGoBack);
            this.Controls.Add(this.lblSummaryDifficulty);
            this.Controls.Add(this.lblSummaryCategory);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmSummary";
            this.Load += new System.EventHandler(this.FrmSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxGoBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSummaryCategory;
        private System.Windows.Forms.Label lblSummaryDifficulty;
        private System.Windows.Forms.PictureBox pbxGoBack;
        private System.Windows.Forms.Button btnStart;
    }
}