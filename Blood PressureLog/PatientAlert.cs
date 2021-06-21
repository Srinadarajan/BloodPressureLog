using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Blood_PressureLog
{
    public partial class PatientAlert : Form
    {
        public string PatientID { get; set; }

        string conString = @"Data Source=DESKTOP-7U9OT19\SQLEXPRESS;Initial Catalog=BloodPressureLog;Integrated Security=True";

        public PatientAlert()
        {
            InitializeComponent();
        }

        //Alerts High BP and Low BP loads
        private void PatientAlert_Load(object sender, EventArgs e)
        {
            //Load High BP records
            SqlConnection connection = new SqlConnection(conString);
            try
            {
                connection.Open();
                SqlCommand cmd1 = connection.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                //cmd1.CommandText = "SELECT * FROM BPLogAppoint WHERE PatientId = '" + PatientID + "'  AND Status LIKE '%High'";
                cmd1.CommandText = "SELECT * FROM BPLog WHERE PatientId = '" + PatientID + "'  AND Status LIKE '%High'";
                cmd1.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                da.Fill(dt);
                dgvAppoinment.DataSource = dt;
                connection.Close();
                dgvAppoinment.ClearSelection();

                dgvAppoinment.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                dgvAppoinment.Columns[3].Visible = false;
                dgvAppoinment.Columns[4].Visible = false;
                dgvAppoinment.Columns[5].Visible = false;
                dgvAppoinment.Columns[6].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("No any Alerts");
            }
            //Load Low BP records
            try
            {
                connection.Open();
                SqlCommand cmd1 = connection.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                //cmd1.CommandText = "SELECT * FROM BPLogAppoint WHERE PatientId = '" + PatientID + "'  AND Status LIKE '%Low'";
                cmd1.CommandText = "SELECT * FROM BPLogAppoint WHERE PatientId = '" + PatientID + "'  AND Status LIKE '%Low'";
                cmd1.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                da.Fill(dt);
                AppointDgv.DataSource = dt;
                connection.Close();
                AppointDgv.ClearSelection();

                AppointDgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                AppointDgv.Columns[3].Visible = false;
                AppointDgv.Columns[4].Visible = false;
                AppointDgv.Columns[5].Visible = false;
                AppointDgv.Columns[6].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("No any Alerts");
            }

        }
    }
}
