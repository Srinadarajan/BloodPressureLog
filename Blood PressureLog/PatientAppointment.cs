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
    public partial class PatientAppointment : Form
    {
        public string PatientID { get; set; }
        
        string conString = @"Data Source=DESKTOP-7U9OT19\SQLEXPRESS;Initial Catalog=BloodPressureLog;Integrated Security=True";

        public PatientAppointment()
        {
            InitializeComponent();
        }

        //Load Patients appointments
        private void PatientAppointment_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(conString);
            try
            {
                connection.Open();
                SqlCommand cmd1 = connection.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "SELECT * FROM Appointments WHERE PatientId = '" + PatientID + "'";
                cmd1.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                da.Fill(dt);
                dgvAppoinment.DataSource = dt;
                connection.Close();
                dgvAppoinment.ClearSelection();

                dgvAppoinment.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                dgvAppoinment.Columns[0].Visible = false;
                dgvAppoinment.Columns[1].Visible = false;
                dgvAppoinment.Columns[2].Visible = false;
             }
            catch (Exception)
            {
                MessageBox.Show("No any Appointments");
            }
        }
    }
}
