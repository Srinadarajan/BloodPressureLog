namespace Blood_PressureLog
{
    partial class PatientDetail
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.BPchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbPatientId = new System.Windows.Forms.ComboBox();
            this.StartCalendar = new System.Windows.Forms.MonthCalendar();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.StopCalendar = new System.Windows.Forms.MonthCalendar();
            this.txtStopDate = new System.Windows.Forms.TextBox();
            this.btnSearchChart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReport1 = new Blood_PressureLog.CrystalReport();
            this.label4 = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnX = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BPchart)).BeginInit();
            this.SuspendLayout();
            // 
            // BPchart
            // 
            chartArea1.AxisX.LabelStyle.Interval = 0D;
            chartArea1.Name = "ChartAreaBP";
            this.BPchart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.BPchart.Legends.Add(legend1);
            this.BPchart.Location = new System.Drawing.Point(813, -5);
            this.BPchart.Name = "BPchart";
            series1.ChartArea = "ChartAreaBP";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Systolic";
            series2.ChartArea = "ChartAreaBP";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Diastolic";
            this.BPchart.Series.Add(series1);
            this.BPchart.Series.Add(series2);
            this.BPchart.Size = new System.Drawing.Size(1027, 818);
            this.BPchart.TabIndex = 4;
            this.BPchart.Text = "chart1";
            // 
            // cmbPatientId
            // 
            this.cmbPatientId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPatientId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbPatientId.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.cmbPatientId.FormattingEnabled = true;
            this.cmbPatientId.Location = new System.Drawing.Point(152, 48);
            this.cmbPatientId.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPatientId.Name = "cmbPatientId";
            this.cmbPatientId.Size = new System.Drawing.Size(262, 33);
            this.cmbPatientId.TabIndex = 83;
            this.cmbPatientId.Text = "P0002";
            // 
            // StartCalendar
            // 
            this.StartCalendar.Location = new System.Drawing.Point(152, 128);
            this.StartCalendar.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.StartCalendar.Name = "StartCalendar";
            this.StartCalendar.TabIndex = 90;
            this.StartCalendar.Visible = false;
            this.StartCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.StartCalendar_DateSelected);
            this.StartCalendar.Leave += new System.EventHandler(this.StartCalendar_Leave);
            // 
            // txtStartDate
            // 
            this.txtStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.txtStartDate.Location = new System.Drawing.Point(152, 128);
            this.txtStartDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.ReadOnly = true;
            this.txtStartDate.Size = new System.Drawing.Size(233, 31);
            this.txtStartDate.TabIndex = 89;
            this.txtStartDate.Text = "2021-06-08";
            this.txtStartDate.Enter += new System.EventHandler(this.txtStartDate_Enter);
            this.txtStartDate.Leave += new System.EventHandler(this.txtStartDate_Leave);
            // 
            // StopCalendar
            // 
            this.StopCalendar.Location = new System.Drawing.Point(152, 204);
            this.StopCalendar.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.StopCalendar.Name = "StopCalendar";
            this.StopCalendar.TabIndex = 92;
            this.StopCalendar.Visible = false;
            this.StopCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.StopCalendar_DateSelected);
            this.StopCalendar.Leave += new System.EventHandler(this.StopCalendar_Leave);
            // 
            // txtStopDate
            // 
            this.txtStopDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.txtStopDate.Location = new System.Drawing.Point(152, 204);
            this.txtStopDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtStopDate.Name = "txtStopDate";
            this.txtStopDate.ReadOnly = true;
            this.txtStopDate.Size = new System.Drawing.Size(233, 31);
            this.txtStopDate.TabIndex = 91;
            this.txtStopDate.Text = "2021-12-08";
            this.txtStopDate.Enter += new System.EventHandler(this.txtStopDate_Enter);
            this.txtStopDate.Leave += new System.EventHandler(this.txtStopDate_Leave);
            // 
            // btnSearchChart
            // 
            this.btnSearchChart.BackColor = System.Drawing.Color.Green;
            this.btnSearchChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSearchChart.ForeColor = System.Drawing.Color.White;
            this.btnSearchChart.Location = new System.Drawing.Point(100, 282);
            this.btnSearchChart.Name = "btnSearchChart";
            this.btnSearchChart.Size = new System.Drawing.Size(96, 53);
            this.btnSearchChart.TabIndex = 93;
            this.btnSearchChart.Text = "OK";
            this.btnSearchChart.UseVisualStyleBackColor = false;
            this.btnSearchChart.Click += new System.EventHandler(this.btnSearchChart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(13, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 26);
            this.label1.TabIndex = 94;
            this.label1.Text = "Patient Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(13, 130);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 26);
            this.label2.TabIndex = 95;
            this.label2.Text = "From";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(13, 209);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 26);
            this.label3.TabIndex = 96;
            this.label3.Text = "To";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(419, 12);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.CrystalReport1;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1430, 830);
            this.crystalReportViewer1.TabIndex = 97;
            this.crystalReportViewer1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(1, -5);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 26);
            this.label4.TabIndex = 98;
            this.label4.Text = "BP Deatils Record";
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.Green;
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.Location = new System.Drawing.Point(134, 491);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(119, 53);
            this.btnReport.TabIndex = 99;
            this.btnReport.Text = "Show";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(229)))), ((int)(((byte)(170)))));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.textBox1.Location = new System.Drawing.Point(19, 405);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(364, 79);
            this.textBox1.TabIndex = 100;
            this.textBox1.Text = "Click here to see the   report of Patients BP details";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnX
            // 
            this.btnX.BackColor = System.Drawing.Color.Green;
            this.btnX.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnX.ForeColor = System.Drawing.Color.White;
            this.btnX.Location = new System.Drawing.Point(1802, 803);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(38, 39);
            this.btnX.TabIndex = 101;
            this.btnX.Text = "X";
            this.btnX.UseVisualStyleBackColor = false;
            this.btnX.Visible = false;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // PatientDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1843, 844);
            this.Controls.Add(this.btnX);
            this.Controls.Add(this.StopCalendar);
            this.Controls.Add(this.StartCalendar);
            this.Controls.Add(this.btnSearchChart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.BPchart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStopDate);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.cmbPatientId);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PatientDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PatientDetail";
            this.Load += new System.EventHandler(this.PatientDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BPchart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BloodPressureLogDataSet bloodPressureLogDataSet;
        private BloodPressureLogDataSetTableAdapters.BPLogTableAdapter bPLogTableAdapter;
        private System.Windows.Forms.DataVisualization.Charting.Chart BPchart;
        private System.Windows.Forms.ComboBox cmbPatientId;
        private System.Windows.Forms.MonthCalendar StartCalendar;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.MonthCalendar StopCalendar;
        private System.Windows.Forms.TextBox txtStopDate;
        private System.Windows.Forms.Button btnSearchChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CrystalReport CrystalReport1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnX;
    }
}