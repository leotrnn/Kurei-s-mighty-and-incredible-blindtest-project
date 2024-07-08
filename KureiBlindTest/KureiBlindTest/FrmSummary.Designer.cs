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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSummaryCategory = new System.Windows.Forms.Label();
            this.lblSummaryDifficulty = new System.Windows.Forms.Label();
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
            this.lblSummaryCategory.Location = new System.Drawing.Point(12, 160);
            this.lblSummaryCategory.Name = "lblSummaryCategory";
            this.lblSummaryCategory.Size = new System.Drawing.Size(590, 80);
            this.lblSummaryCategory.TabIndex = 4;
            this.lblSummaryCategory.Text = "Summary";
            this.lblSummaryCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSummaryDifficulty
            // 
            this.lblSummaryDifficulty.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblSummaryDifficulty.Location = new System.Drawing.Point(12, 280);
            this.lblSummaryDifficulty.Name = "lblSummaryDifficulty";
            this.lblSummaryDifficulty.Size = new System.Drawing.Size(590, 80);
            this.lblSummaryDifficulty.TabIndex = 5;
            this.lblSummaryDifficulty.Text = "Summary";
            this.lblSummaryDifficulty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(614, 640);
            this.Controls.Add(this.lblSummaryDifficulty);
            this.Controls.Add(this.lblSummaryCategory);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmSummary";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSummaryCategory;
        private System.Windows.Forms.Label lblSummaryDifficulty;
    }
}