using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Blood_PressureLog
{
    public partial class CarerApproval : Form
    {
        string conString = @"Data Source=DESKTOP-7U9OT19\SQLEXPRESS;Initial Catalog=BloodPressureLog;Integrated Security=True";

        public CarerApproval()
        {
            InitializeComponent();
        }

        //Load CarerApproval forms
        private void CarerApproval_Load(object sender, EventArgs e)
        {
            disp_data();
        }

        //Display data
        public void disp_data()
        {
            //Load data in grid view with Buttons
            SqlConnection connection = new SqlConnection(conString);
            try
            {
                connection.Open();
                SqlCommand cmd1 = connection.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "SELECT * FROM RequestEdit";
                cmd1.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                da.Fill(dt);
                dgvRequest.DataSource = dt;
                DataGridViewButtonColumn btnAccept = new DataGridViewButtonColumn();
                dgvRequest.Columns.Add(btnAccept);
                btnAccept.HeaderText = "Approve";
                btnAccept.Text = "Approve";
                btnAccept.Name = "Approve";
                btnAccept.UseColumnTextForButtonValue = true;
                DataGridViewButtonColumn btnRefuse = new DataGridViewButtonColumn();
                dgvRequest.Columns.Add(btnRefuse);
                btnRefuse.HeaderText = "Refuse";
                btnRefuse.Text = "Refuse";
                btnRefuse.Name = "Refuse";
                btnRefuse.UseColumnTextForButtonValue = true;
                connection.Close();
                dgvRequest.ClearSelection();
            }
            catch (Exception ex)
            {

            }
            dgvRequest.RowTemplate.MinimumHeight = 35;
            this.dgvRequest.Columns[12].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvRequest.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvRequest.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvRequest.Columns[0].Visible = false;
            dgvRequest.Columns[1].Visible = false;
            dgvRequest.Columns[5].HeaderText = "R1_Systolic";
            dgvRequest.Columns[6].HeaderText = "R1_Diastolic";
            dgvRequest.Columns[7].HeaderText = "R2_Systolic";
            dgvRequest.Columns[8].HeaderText = "R2_Diastolic";
        }

        //Approve or Refuse the request of edit from user
        private void dgvRequest_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                try
                {
                    SqlConnection con = new SqlConnection(conString);
                    SqlCommand cmd = new SqlCommand("UpdateBpLog", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Update");
                    cmd.Parameters.AddWithValue("@PatientId", dgvRequest.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                    cmd.Parameters.AddWithValue("@Date", dgvRequest.Rows[e.RowIndex].Cells[3].FormattedValue.ToString());
                    cmd.Parameters.AddWithValue("@Time", dgvRequest.Rows[e.RowIndex].Cells[4].FormattedValue.ToString());
                    cmd.Parameters.AddWithValue("@Reading1_Systolic", dgvRequest.Rows[e.RowIndex].Cells[5].FormattedValue.ToString());
                    cmd.Parameters.AddWithValue("@Reading2_Systolic", dgvRequest.Rows[e.RowIndex].Cells[6].FormattedValue.ToString());
                    cmd.Parameters.AddWithValue("@Reading1_Diastolic", dgvRequest.Rows[e.RowIndex].Cells[7].FormattedValue.ToString());
                    cmd.Parameters.AddWithValue("@Reading2_Diastolic", dgvRequest.Rows[e.RowIndex].Cells[8].FormattedValue.ToString());
                    cmd.Parameters.AddWithValue("@Systolic", dgvRequest.Rows[e.RowIndex].Cells[9].FormattedValue.ToString());
                    cmd.Parameters.AddWithValue("@Diastolic", dgvRequest.Rows[e.RowIndex].Cells[10].FormattedValue.ToString());
                    cmd.Parameters.AddWithValue("@Status", dgvRequest.Rows[e.RowIndex].Cells[11].FormattedValue.ToString());
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                finally
                {
                    string title = "Approved Request";
                    string message = "Patient Blood pressure details are Edited and Saved :)";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
                    // Approved Request
                    try
                    {
                        SqlConnection conn = new SqlConnection(conString);
                        SqlCommand commd = new SqlCommand("DeleteRequest", conn);
                        commd.CommandType = CommandType.StoredProcedure;
                        commd.Parameters.AddWithValue("@Action", "DeleteRequest");
                        commd.Parameters.AddWithValue("@ReuestId", dgvRequest.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Request_ID", dgvRequest.Rows[e.RowIndex].Cells[1].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@PatientId", dgvRequest.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Date", dgvRequest.Rows[e.RowIndex].Cells[3].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Time", dgvRequest.Rows[e.RowIndex].Cells[4].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Reading1_Systolic", dgvRequest.Rows[e.RowIndex].Cells[5].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Reading2_Systolic", dgvRequest.Rows[e.RowIndex].Cells[6].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Reading1_Diastolic", dgvRequest.Rows[e.RowIndex].Cells[7].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Reading2_Diastolic", dgvRequest.Rows[e.RowIndex].Cells[8].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Systolic", dgvRequest.Rows[e.RowIndex].Cells[9].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Diastolic", dgvRequest.Rows[e.RowIndex].Cells[10].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Status", dgvRequest.Rows[e.RowIndex].Cells[11].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Note", dgvRequest.Rows[e.RowIndex].Cells[12].FormattedValue.ToString());
                        conn.Open();
                        commd.ExecuteNonQuery();
                        conn.Close();
                        disp_data();
                    }

                    finally
                    {
                        string title1 = "Deleted From Request Record";
                        string message1 = "Selected request is Updated :)";
                        MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                        DialogResult result1 = MessageBox.Show(message1, title1, buttons1, MessageBoxIcon.Information);
                    }
                }
            }

            //decline the Patients Requestif (e.ColumnIndex == 14)
            {
                string message = "Do you want to decline the Patients Request ?";
                string title = "Refuse Request ";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection conn = new SqlConnection(conString);
                        SqlCommand commd = new SqlCommand("DeleteRequest", conn);
                        commd.CommandType = CommandType.StoredProcedure;
                        commd.Parameters.AddWithValue("@Action", "DeleteRequest");
                        commd.Parameters.AddWithValue("@ReuestId", dgvRequest.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Request_ID", dgvRequest.Rows[e.RowIndex].Cells[1].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@PatientId", dgvRequest.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Date", dgvRequest.Rows[e.RowIndex].Cells[3].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Time", dgvRequest.Rows[e.RowIndex].Cells[4].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Reading1_Systolic", dgvRequest.Rows[e.RowIndex].Cells[5].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Reading2_Systolic", dgvRequest.Rows[e.RowIndex].Cells[6].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Reading1_Diastolic", dgvRequest.Rows[e.RowIndex].Cells[7].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Reading2_Diastolic", dgvRequest.Rows[e.RowIndex].Cells[8].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Systolic", dgvRequest.Rows[e.RowIndex].Cells[9].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Diastolic", dgvRequest.Rows[e.RowIndex].Cells[10].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Status", dgvRequest.Rows[e.RowIndex].Cells[11].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Note", dgvRequest.Rows[e.RowIndex].Cells[12].FormattedValue.ToString());
                        conn.Open();
                        commd.ExecuteNonQuery();
                        conn.Close();
                        disp_data();
                    }

                    finally
                    {
                        string title1 = "Deleted";
                        string message1 = "Selected request is Permanently Deleted :)";
                        MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                        DialogResult result1 = MessageBox.Show(message1, title1, buttons1, MessageBoxIcon.Stop);
                    }
                }
            }
        }

    }
}
