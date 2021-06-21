using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CrystalDecisions.CrystalReports.Engine;

namespace Blood_PressureLog
{
    public partial class PatientDetail : Form
    {

       string conString = @"Data Source=DESKTOP-7U9OT19\SQLEXPRESS;Initial Catalog=BloodPressureLog;Integrated Security=True";

        public PatientDetail()
        {
            InitializeComponent();
        }

        //Load form
        private void PatientDetail_Load(object sender, EventArgs e)
        {
            //Load Patiens ID in cmbPatientId
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("SELECT PatientId FROM Patient", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    MyCollection.Add(reader.GetString(0));
                }
                cmbPatientId.AutoCompleteCustomSource = MyCollection;
                connection.Close();
            }
        }

        //Calendar hide after select data
        private void StartCalendar_Leave(object sender, EventArgs e)
        {
            var StartCalendar = sender as MonthCalendar;
            StartCalendar.Visible = false;
        }

        //DateSelected in Calendar
        private void StartCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            var StartCalendar = sender as MonthCalendar;
            txtStartDate.Text = StartCalendar.SelectionStart.ToShortDateString();
            StartCalendar.Visible = false;
        }

        //Calendar Visible
        private void txtStartDate_Enter(object sender, EventArgs e)
        {
            StartCalendar.Visible = true;
        }

        //Calendar hide after select data
        private void txtStartDate_Leave(object sender, EventArgs e)
        {
            if (!StartCalendar.Focused)
                StartCalendar.Visible = false;
        }

        //DateSelected in Calendar
        private void StopCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            var StopCalendar = sender as MonthCalendar;
            txtStopDate.Text = StopCalendar.SelectionStart.ToShortDateString();
            StopCalendar.Visible = false;
        }

        //Calendar hide after select data
        private void StopCalendar_Leave(object sender, EventArgs e)
        {
            var StopCalendar = sender as MonthCalendar;
            StopCalendar.Visible = false;
        }

        //Calendar Visible
        private void txtStopDate_Enter(object sender, EventArgs e)
        {
            StopCalendar.Visible = true;
        }

        //Calendar hide after select data
        private void txtStopDate_Leave(object sender, EventArgs e)
        {
            if (!StopCalendar.Focused)
                StopCalendar.Visible = false;
        }

        //For getting chart
        private void btnSearchChart_Click(object sender, EventArgs e)
        {
            DateTime StartDate = DateTime.Parse(txtStartDate.Text);
            DateTime StopDate = DateTime.Parse(txtStopDate.Text);

            SqlConnection con = new SqlConnection(conString);
            SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM BPLog WHERE PatientId = '" + cmbPatientId.Text + "'AND Date >= '" + StartDate + "' AND  Date <='" + StopDate + "'", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            BPchart.DataSource = dt;
            BPchart.ChartAreas["ChartAreaBP"].AxisX.Title = "Date";
            BPchart.ChartAreas["ChartAreaBP"].AxisY.Title = "mm/Hg";
            BPchart.Series["Systolic"].XValueMember = "Date";
            BPchart.Series["Systolic"].YValueMembers = "Systolic";
            BPchart.Series["Diastolic"].XValueMember = "Date";
            BPchart.Series["Diastolic"].YValueMembers = "Diastolic";
            BPchart.Series["Systolic"].ChartType = SeriesChartType.Line;
            BPchart.Series["Diastolic"].ChartType = SeriesChartType.Spline;
            this.BPchart.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd";
            BPchart.Series[0].XValueType = ChartValueType.Date;

            crystalReportViewer1.Visible = false;
            BPchart.Visible = true;
        }

        //Show report
        private void btnReport_Click(object sender, EventArgs e)
        {
            DateTime StartDate = DateTime.Parse(txtStartDate.Text);
            DateTime StopDate = DateTime.Parse(txtStopDate.Text); 
            
            SqlConnection cnn;
            string connectionString = null;
            string sql = null;

            connectionString = @"Data Source=DESKTOP-7U9OT19\SQLEXPRESS;Initial Catalog=BloodPressureLog;Integrated Security=True";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            sql = "SELECT * FROM BPLog WHERE PatientId = '" + cmbPatientId.Text + "'AND Date >= '" + StartDate + "' AND  Date <='" + StopDate + "'";
            SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
            DataSetPatient ds = new DataSetPatient();
            dscmd.Fill(ds, "PatientId");
            cnn.Close();

            CrystalReport objRpt = new CrystalReport();
            objRpt.SetDataSource(ds.Tables[1]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();

            crystalReportViewer1.Visible = true;
            BPchart.Visible = false;
            btnReport.Visible = false;
            btnX.Visible = true;
            textBox1.Visible = false;
        }
        //Close report view
        private void btnX_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.Visible = false;
            textBox1.Visible = true;
            btnReport.Visible = true;
        }
    }
}
