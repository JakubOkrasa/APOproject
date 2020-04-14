namespace APOproject
{
    partial class HistogramForm
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
            this.btnSaveHistogram = new System.Windows.Forms.Button();
            this.rbBlackWhiteHist = new System.Windows.Forms.RadioButton();
            this.rbRGBhist = new System.Windows.Forms.RadioButton();
            this.gbHistogramTypes = new System.Windows.Forms.GroupBox();
            this.saveBwHistDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnStretchHistogram = new System.Windows.Forms.Button();
            this.btnEqHistogram = new System.Windows.Forms.Button();
            this.pctMonoHist = new System.Windows.Forms.PictureBox();
            this.pctGreenHist = new System.Windows.Forms.PictureBox();
            this.pctBlueHist = new System.Windows.Forms.PictureBox();
            this.pctRedHist = new System.Windows.Forms.PictureBox();
            this.gBstretch = new System.Windows.Forms.GroupBox();
            this.upDownStretch = new System.Windows.Forms.NumericUpDown();
            this.tbStretch = new System.Windows.Forms.TrackBar();
            this.gbHistogramTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctMonoHist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctGreenHist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBlueHist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctRedHist)).BeginInit();
            this.gBstretch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownStretch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbStretch)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveHistogram
            // 
            this.btnSaveHistogram.Location = new System.Drawing.Point(607, 137);
            this.btnSaveHistogram.Name = "btnSaveHistogram";
            this.btnSaveHistogram.Size = new System.Drawing.Size(141, 23);
            this.btnSaveHistogram.TabIndex = 1;
            this.btnSaveHistogram.Text = "Save histogram";
            this.btnSaveHistogram.UseVisualStyleBackColor = true;
            this.btnSaveHistogram.Click += new System.EventHandler(this.btnSaveHistogram_Click);
            // 
            // rbBlackWhiteHist
            // 
            this.rbBlackWhiteHist.AutoSize = true;
            this.rbBlackWhiteHist.Checked = true;
            this.rbBlackWhiteHist.Location = new System.Drawing.Point(0, 34);
            this.rbBlackWhiteHist.Name = "rbBlackWhiteHist";
            this.rbBlackWhiteHist.Size = new System.Drawing.Size(125, 17);
            this.rbBlackWhiteHist.TabIndex = 2;
            this.rbBlackWhiteHist.TabStop = true;
            this.rbBlackWhiteHist.Text = "Grey levels histogram";
            this.rbBlackWhiteHist.UseVisualStyleBackColor = true;
            this.rbBlackWhiteHist.CheckedChanged += new System.EventHandler(this.rbBlackWhiteHist_CheckedChanged);
            // 
            // rbRGBhist
            // 
            this.rbRGBhist.AutoSize = true;
            this.rbRGBhist.Location = new System.Drawing.Point(0, 57);
            this.rbRGBhist.Name = "rbRGBhist";
            this.rbRGBhist.Size = new System.Drawing.Size(101, 17);
            this.rbRGBhist.TabIndex = 3;
            this.rbRGBhist.Text = "RGB histograms";
            this.rbRGBhist.UseVisualStyleBackColor = true;
            this.rbRGBhist.CheckedChanged += new System.EventHandler(this.rbRGBhist_CheckedChanged);
            // 
            // gbHistogramTypes
            // 
            this.gbHistogramTypes.Controls.Add(this.rbRGBhist);
            this.gbHistogramTypes.Controls.Add(this.rbBlackWhiteHist);
            this.gbHistogramTypes.Location = new System.Drawing.Point(607, 31);
            this.gbHistogramTypes.Name = "gbHistogramTypes";
            this.gbHistogramTypes.Size = new System.Drawing.Size(200, 100);
            this.gbHistogramTypes.TabIndex = 4;
            this.gbHistogramTypes.TabStop = false;
            // 
            // btnStretchHistogram
            // 
            this.btnStretchHistogram.Location = new System.Drawing.Point(25, 19);
            this.btnStretchHistogram.Name = "btnStretchHistogram";
            this.btnStretchHistogram.Size = new System.Drawing.Size(141, 23);
            this.btnStretchHistogram.TabIndex = 8;
            this.btnStretchHistogram.Text = "Stretch histogram";
            this.btnStretchHistogram.UseVisualStyleBackColor = true;
            this.btnStretchHistogram.Click += new System.EventHandler(this.btnStretchHistogram_Click);
            // 
            // btnEqHistogram
            // 
            this.btnEqHistogram.Location = new System.Drawing.Point(607, 325);
            this.btnEqHistogram.Name = "btnEqHistogram";
            this.btnEqHistogram.Size = new System.Drawing.Size(141, 23);
            this.btnEqHistogram.TabIndex = 9;
            this.btnEqHistogram.Text = "flatten histogram";
            this.btnEqHistogram.UseVisualStyleBackColor = true;
            this.btnEqHistogram.Click += new System.EventHandler(this.btnEqHistogram_Click);
            // 
            // pctMonoHist
            // 
            this.pctMonoHist.Location = new System.Drawing.Point(37, 31);
            this.pctMonoHist.Name = "pctMonoHist";
            this.pctMonoHist.Size = new System.Drawing.Size(479, 161);
            this.pctMonoHist.TabIndex = 10;
            this.pctMonoHist.TabStop = false;
            // 
            // pctGreenHist
            // 
            this.pctGreenHist.Location = new System.Drawing.Point(37, 228);
            this.pctGreenHist.Name = "pctGreenHist";
            this.pctGreenHist.Size = new System.Drawing.Size(479, 161);
            this.pctGreenHist.TabIndex = 11;
            this.pctGreenHist.TabStop = false;
            // 
            // pctBlueHist
            // 
            this.pctBlueHist.Location = new System.Drawing.Point(37, 418);
            this.pctBlueHist.Name = "pctBlueHist";
            this.pctBlueHist.Size = new System.Drawing.Size(479, 161);
            this.pctBlueHist.TabIndex = 12;
            this.pctBlueHist.TabStop = false;
            // 
            // pctRedHist
            // 
            this.pctRedHist.Location = new System.Drawing.Point(37, 31);
            this.pctRedHist.Name = "pctRedHist";
            this.pctRedHist.Size = new System.Drawing.Size(479, 161);
            this.pctRedHist.TabIndex = 13;
            this.pctRedHist.TabStop = false;
            // 
            // gBstretch
            // 
            this.gBstretch.Controls.Add(this.upDownStretch);
            this.gBstretch.Controls.Add(this.tbStretch);
            this.gBstretch.Controls.Add(this.btnStretchHistogram);
            this.gBstretch.Location = new System.Drawing.Point(582, 179);
            this.gBstretch.Name = "gBstretch";
            this.gBstretch.Size = new System.Drawing.Size(192, 100);
            this.gBstretch.TabIndex = 14;
            this.gBstretch.TabStop = false;
            this.gBstretch.Text = "Histogram stretching";
            // 
            // upDownStretch
            // 
            this.upDownStretch.Location = new System.Drawing.Point(149, 55);
            this.upDownStretch.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.upDownStretch.Name = "upDownStretch";
            this.upDownStretch.Size = new System.Drawing.Size(43, 20);
            this.upDownStretch.TabIndex = 10;
            this.upDownStretch.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.upDownStretch.ValueChanged += new System.EventHandler(this.upDownStretch_ValueChanged);
            // 
            // tbStretch
            // 
            this.tbStretch.Location = new System.Drawing.Point(25, 55);
            this.tbStretch.Maximum = 255;
            this.tbStretch.Name = "tbStretch";
            this.tbStretch.Size = new System.Drawing.Size(111, 45);
            this.tbStretch.TabIndex = 9;
            this.tbStretch.Value = 255;
            this.tbStretch.Scroll += new System.EventHandler(this.tbStretch_Scroll);
            // 
            // HistogramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 607);
            this.Controls.Add(this.gBstretch);
            this.Controls.Add(this.pctRedHist);
            this.Controls.Add(this.pctBlueHist);
            this.Controls.Add(this.pctGreenHist);
            this.Controls.Add(this.pctMonoHist);
            this.Controls.Add(this.btnEqHistogram);
            this.Controls.Add(this.gbHistogramTypes);
            this.Controls.Add(this.btnSaveHistogram);
            this.Name = "HistogramForm";
            this.Text = "Histogram";
            this.Shown += new System.EventHandler(this.HistogramForm_Shown);
            this.gbHistogramTypes.ResumeLayout(false);
            this.gbHistogramTypes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctMonoHist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctGreenHist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBlueHist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctRedHist)).EndInit();
            this.gBstretch.ResumeLayout(false);
            this.gBstretch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownStretch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbStretch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSaveHistogram;
        private System.Windows.Forms.RadioButton rbBlackWhiteHist;
        private System.Windows.Forms.RadioButton rbRGBhist;
        private System.Windows.Forms.GroupBox gbHistogramTypes;
        private System.Windows.Forms.SaveFileDialog saveBwHistDialog;
        private System.Windows.Forms.Button btnStretchHistogram;
        private System.Windows.Forms.Button btnEqHistogram;
        private System.Windows.Forms.PictureBox pctMonoHist;
        private System.Windows.Forms.PictureBox pctGreenHist;
        private System.Windows.Forms.PictureBox pctBlueHist;
        private System.Windows.Forms.PictureBox pctRedHist;
        private System.Windows.Forms.GroupBox gBstretch;
        private System.Windows.Forms.NumericUpDown upDownStretch;
        private System.Windows.Forms.TrackBar tbStretch;
    }
}