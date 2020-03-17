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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.blackWhiteHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnSaveHistogram = new System.Windows.Forms.Button();
            this.rbBlackWhiteHist = new System.Windows.Forms.RadioButton();
            this.rbRGBhist = new System.Windows.Forms.RadioButton();
            this.gbHistogramTypes = new System.Windows.Forms.GroupBox();
            this.redHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.blueHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.greenHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.saveBwHistDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnStretchHistogram = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.blackWhiteHistogram)).BeginInit();
            this.gbHistogramTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.redHistogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueHistogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenHistogram)).BeginInit();
            this.SuspendLayout();
            // 
            // blackWhiteHistogram
            // 
            chartArea1.Name = "ChartArea1";
            this.blackWhiteHistogram.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.blackWhiteHistogram.Legends.Add(legend1);
            this.blackWhiteHistogram.Location = new System.Drawing.Point(12, 31);
            this.blackWhiteHistogram.Name = "blackWhiteHistogram";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Brightness";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.blackWhiteHistogram.Series.Add(series1);
            this.blackWhiteHistogram.Size = new System.Drawing.Size(576, 166);
            this.blackWhiteHistogram.TabIndex = 0;
            this.blackWhiteHistogram.Text = "Histogram";
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
            this.rbBlackWhiteHist.Size = new System.Drawing.Size(163, 17);
            this.rbBlackWhiteHist.TabIndex = 2;
            this.rbBlackWhiteHist.TabStop = true;
            this.rbBlackWhiteHist.Text = "Histogram poziomów szarości";
            this.rbBlackWhiteHist.UseVisualStyleBackColor = true;
            this.rbBlackWhiteHist.CheckedChanged += new System.EventHandler(this.rbBlackWhiteHist_CheckedChanged);
            // 
            // rbRGBhist
            // 
            this.rbRGBhist.AutoSize = true;
            this.rbRGBhist.Location = new System.Drawing.Point(0, 57);
            this.rbRGBhist.Name = "rbRGBhist";
            this.rbRGBhist.Size = new System.Drawing.Size(174, 17);
            this.rbRGBhist.TabIndex = 3;
            this.rbRGBhist.Text = "Histogram dla kanałów R, G i B";
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
            this.gbHistogramTypes.Text = "gbHistogramTypes";
            // 
            // redHistogram
            // 
            chartArea2.Name = "ChartArea1";
            this.redHistogram.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.redHistogram.Legends.Add(legend2);
            this.redHistogram.Location = new System.Drawing.Point(12, 31);
            this.redHistogram.Name = "redHistogram";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "Red";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.redHistogram.Series.Add(series2);
            this.redHistogram.Size = new System.Drawing.Size(576, 166);
            this.redHistogram.TabIndex = 5;
            this.redHistogram.Text = "redHistogram";
            // 
            // blueHistogram
            // 
            chartArea3.Name = "ChartArea1";
            this.blueHistogram.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.blueHistogram.Legends.Add(legend3);
            this.blueHistogram.Location = new System.Drawing.Point(12, 402);
            this.blueHistogram.Name = "blueHistogram";
            series3.ChartArea = "ChartArea1";
            series3.IsVisibleInLegend = false;
            series3.Legend = "Legend1";
            series3.Name = "Blue";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.blueHistogram.Series.Add(series3);
            this.blueHistogram.Size = new System.Drawing.Size(576, 166);
            this.blueHistogram.TabIndex = 6;
            this.blueHistogram.Text = "blueHistogram";
            // 
            // greenHistogram
            // 
            chartArea4.Name = "ChartArea1";
            this.greenHistogram.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.greenHistogram.Legends.Add(legend4);
            this.greenHistogram.Location = new System.Drawing.Point(12, 218);
            this.greenHistogram.Name = "greenHistogram";
            series4.ChartArea = "ChartArea1";
            series4.Color = System.Drawing.Color.LimeGreen;
            series4.IsVisibleInLegend = false;
            series4.Legend = "Legend1";
            series4.Name = "Green";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.greenHistogram.Series.Add(series4);
            this.greenHistogram.Size = new System.Drawing.Size(576, 166);
            this.greenHistogram.TabIndex = 7;
            this.greenHistogram.Text = "greenHistogram";
            // 
            // btnStretchHistogram
            // 
            this.btnStretchHistogram.Location = new System.Drawing.Point(607, 209);
            this.btnStretchHistogram.Name = "btnStretchHistogram";
            this.btnStretchHistogram.Size = new System.Drawing.Size(141, 23);
            this.btnStretchHistogram.TabIndex = 8;
            this.btnStretchHistogram.Text = "Rozciąganie histogramu";
            this.btnStretchHistogram.UseVisualStyleBackColor = true;
            this.btnStretchHistogram.Click += new System.EventHandler(this.btnStretchHistogram_Click);
            // 
            // HistogramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 607);
            this.Controls.Add(this.btnStretchHistogram);
            this.Controls.Add(this.greenHistogram);
            this.Controls.Add(this.blueHistogram);
            this.Controls.Add(this.redHistogram);
            this.Controls.Add(this.gbHistogramTypes);
            this.Controls.Add(this.btnSaveHistogram);
            this.Controls.Add(this.blackWhiteHistogram);
            this.Name = "HistogramForm";
            this.Text = "Histogram";
            ((System.ComponentModel.ISupportInitialize)(this.blackWhiteHistogram)).EndInit();
            this.gbHistogramTypes.ResumeLayout(false);
            this.gbHistogramTypes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.redHistogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueHistogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenHistogram)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart blackWhiteHistogram;
        private System.Windows.Forms.Button btnSaveHistogram;
        private System.Windows.Forms.RadioButton rbBlackWhiteHist;
        private System.Windows.Forms.RadioButton rbRGBhist;
        private System.Windows.Forms.GroupBox gbHistogramTypes;
        private System.Windows.Forms.DataVisualization.Charting.Chart redHistogram;
        private System.Windows.Forms.DataVisualization.Charting.Chart blueHistogram;
        private System.Windows.Forms.DataVisualization.Charting.Chart greenHistogram;
        private System.Windows.Forms.SaveFileDialog saveBwHistDialog;
        private System.Windows.Forms.Button btnStretchHistogram;
    }
}