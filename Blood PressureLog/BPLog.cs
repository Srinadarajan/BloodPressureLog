using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace Blood_PressureLog
{
    public partial class BPLog : Form
    {
        public string PatientID { get; set; }

        public BPLog()
        {
            InitializeComponent();
        }

        //Load Patiend record
        private void BPLog_Load(object sender, EventArgs e)
        {
            SqlConnection cnn;
            string connectionString = null;
            string sql = null;

            connectionString = @"Data Source=DESKTOP-7U9OT19\SQLEXPRESS;Initial Catalog=BloodPressureLog;Integrated Security=True";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            sql = "SELECT* FROM BPLog WHERE PatientId = '" + PatientID + "'";
            SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
            DataSetPatient ds = new DataSetPatient();
            dscmd.Fill(ds, "PatientId");
            cnn.Close();

            CrystalReportPatient objRpt = new CrystalReportPatient();
            objRpt.SetDataSource(ds.Tables[1]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }
    }
}
