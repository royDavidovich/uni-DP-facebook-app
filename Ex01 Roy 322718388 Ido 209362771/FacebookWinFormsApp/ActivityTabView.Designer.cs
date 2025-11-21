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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.labelActivity.Text = "Activity";
            this.labelActivity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartActivity1
            // 
            chartArea1.Name = "ChartArea1";
            this.chartActivity1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartActivity1.Legends.Add(legend1);
            this.chartActivity1.Location = new System.Drawing.Point(253, 105);
            this.chartActivity1.Name = "chartActivity1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartActivity1.Series.Add(series1);
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
