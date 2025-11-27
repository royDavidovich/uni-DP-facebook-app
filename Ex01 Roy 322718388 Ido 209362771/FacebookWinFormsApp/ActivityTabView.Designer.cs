namespace BasicFacebookFeatures
{
    partial class chartActivity
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.comboBoxTime = new System.Windows.Forms.ComboBox();
            this.labelActivity = new System.Windows.Forms.Label();
            this.chartActivity1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartActivity1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxTime
            // 
            this.comboBoxTime.FormattingEnabled = true;
            this.comboBoxTime.Items.AddRange(new object[] {
            "Last month",
            "Last year",
            "Since account creation"});
            this.comboBoxTime.Location = new System.Drawing.Point(27, 195);
            this.comboBoxTime.Name = "comboBoxTime";
            this.comboBoxTime.Size = new System.Drawing.Size(155, 24);
            this.comboBoxTime.TabIndex = 0;
            this.comboBoxTime.SelectedIndexChanged += new System.EventHandler(this.comboBoxTime_SelectedIndexChanged);
            // 
            // labelActivity
            // 
            this.labelActivity.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelActivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelActivity.Location = new System.Drawing.Point(0, 0);
            this.labelActivity.Name = "labelActivity";
            this.labelActivity.Size = new System.Drawing.Size(836, 79);
            this.labelActivity.TabIndex = 1;
            this.labelActivity.Text = "Activity (posts)";
            this.labelActivity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartActivity1
            // 
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.MajorTickMark.Enabled = false;
            chartArea2.AxisX2.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorTickMark.Enabled = false;
            chartArea2.AxisY2.MajorGrid.Enabled = false;
            chartArea2.BorderColor = System.Drawing.Color.Transparent;
            chartArea2.BorderWidth = 0;
            chartArea2.Name = "ChartArea1";
            chartArea2.ShadowColor = System.Drawing.Color.Transparent;
            this.chartActivity1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartActivity1.Legends.Add(legend2);
            this.chartActivity1.Location = new System.Drawing.Point(253, 105);
            this.chartActivity1.Name = "chartActivity1";
            series2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.MarkerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            series2.MarkerColor = System.Drawing.Color.White;
            series2.MarkerSize = 7;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "Series1";
            this.chartActivity1.Series.Add(series2);
            this.chartActivity1.Size = new System.Drawing.Size(532, 293);
            this.chartActivity1.TabIndex = 2;
            this.chartActivity1.Text = "chart1";
            // 
            // chartActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartActivity1);
            this.Controls.Add(this.labelActivity);
            this.Controls.Add(this.comboBoxTime);
            this.Name = "chartActivity";
            this.Size = new System.Drawing.Size(836, 498);
            this.Resize += new System.EventHandler(this.chartActivity_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.chartActivity1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTime;
        private System.Windows.Forms.Label labelActivity;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartActivity1;
    }
}
