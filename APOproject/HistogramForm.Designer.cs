﻿namespace APOproject
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
            this.blackWhiteHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.blackWhiteHistogram)).BeginInit();
            this.SuspendLayout();
            // 
            // blackWhiteHistogram
            // 
            chartArea1.Name = "ChartArea1";
            this.blackWhiteHistogram.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.blackWhiteHistogram.Legends.Add(legend1);
            this.blackWhiteHistogram.Location = new System.Drawing.Point(12, 12);
            this.blackWhiteHistogram.Name = "blackWhiteHistogram";
            series1.ChartArea = "ChartArea1";
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.blackWhiteHistogram.Series.Add(series1);
            this.blackWhiteHistogram.Size = new System.Drawing.Size(242, 146);
            this.blackWhiteHistogram.TabIndex = 0;
            this.blackWhiteHistogram.Text = "Histogram";
            // 
            // HistogramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 240);
            this.Controls.Add(this.blackWhiteHistogram);
            this.Name = "HistogramForm";
            this.Text = "HistogramForm";
            ((System.ComponentModel.ISupportInitialize)(this.blackWhiteHistogram)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart blackWhiteHistogram;
    }
}