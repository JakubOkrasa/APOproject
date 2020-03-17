namespace APOproject
{
    partial class WaitingForm
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
            this.lblProcessing = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblProcessing
            // 
            this.lblProcessing.AutoSize = true;
            this.lblProcessing.Location = new System.Drawing.Point(9, 18);
            this.lblProcessing.Name = "lblProcessing";
            this.lblProcessing.Size = new System.Drawing.Size(68, 13);
            this.lblProcessing.TabIndex = 0;
            this.lblProcessing.Text = "Processing...";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 47);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(164, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 1;
            // 
            // WaitingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 96);
            this.ControlBox = false;
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblProcessing);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WaitingForm";
            this.ShowInTaskbar = false;
            this.Text = "Processing...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProcessing;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}