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
using System.Timers;
using System.Media;

namespace Blood_PressureLog
{
    public partial class AppointmentUS : UserControl
    {
        string conString = @"Data Source=DESKTOP-7U9OT19\SQLEXPRESS;Initial Catalog=BloodPressureLog;Integrated Security=True";

        public AppointmentUS()
        {
            InitializeComponent();
        }

        //Lod Low and High BP records
        private void AppointmentUS_Load(object sender, EventArgs e)
        {
            //Load High Bp records
            SqlConnection connection = new SqlConnection(conString);
            try
            {
                connection.Open();
                SqlCommand cmd1 = connection.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "SELECT * FROM BPLogAppoint WHERE Status LIKE '%High%'";
                cmd1.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                da.Fill(dt);
                dgvAppoinment.DataSource = dt;

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dgvAppoinment.Columns.Add(btn);
                btn.HeaderText = "Appointment";
                btn.Text = "Schedule";
                btn.Name = "Appointment";
                btn.UseColumnTextForButtonValue = true;

                DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
                dgvAppoinment.Columns.Add(btn1);
                btn1.HeaderText = "Delete";
                btn1.Text = "Delete";
                btn1.Name = "Delete";
                btn1.UseColumnTextForButtonValue = true;
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
                cmd1.CommandText = "SELECT * FROM BPLogAppoint WHERE Status LIKE '%Low%'";
                cmd1.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                da.Fill(dt);
                AppointDgv.DataSource = dt;

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                AppointDgv.Columns.Add(btn);
                btn.HeaderText = "Appointment";
                btn.Text = "Schedule";
                btn.Name = "Appointment";
                btn.UseColumnTextForButtonValue = true;

                DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
                AppointDgv.Columns.Add(btn1);
                btn1.HeaderText = "Delete";
                btn1.Text = "Delete";
                btn1.Name = "Delete";
                btn1.UseColumnTextForButtonValue = true;
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

        //schedule or cancelled Appointment for High BP
        private void dgvAppoinment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //When click Appointment button
            if (dgvAppoinment.Columns[e.ColumnIndex].Name == "Appointment")
            {
                pnlSchedule.Visible = true;
                string PatientId = dgvAppoinment.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                SqlConnection con = new SqlConnection(conString);
                string selectSqlStu = ("SELECT * FROM Patient WHERE PatientId = '" + PatientId + "'");
                SqlCommand cmdStu = new SqlCommand(selectSqlStu, con);
                try
                {
                    con.Open();
                    using (SqlDataReader readPatient = cmdStu.ExecuteReader())
                    {
                        while (readPatient.Read())
                        {
                            txtPatientId.Text = (readPatient["PatientId"].ToString());
                            txtFirstName.Text = (readPatient["FirstName"].ToString());
                            txtLastName.Text = (readPatient["LastName"].ToString());
                            txtNic.Text = (readPatient["Nic"].ToString());
                            DateTime x = (DateTime)readPatient["DOB"];
                            txtDOB.Text = x.ToString("yyyy - MM - dd");
                            lblAge.Text = (readPatient["Age"].ToString());
                            txtMail.Text = (readPatient["Email"].ToString());
                            txtPhone.Text = (readPatient["Mobile"].ToString());
                        }
                    }
                }
                finally
                {
                    //After add appointment delete this record in this datagridview
                    try
                    {
                        SqlConnection conn = new SqlConnection(conString);
                        SqlCommand commd = new SqlCommand("DeleteAppointment", conn);
                        commd.CommandType = CommandType.StoredProcedure;
                        commd.Parameters.AddWithValue("@Action", "DeleteAppointment");
                        commd.Parameters.AddWithValue("@PatientId", dgvAppoinment.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                        DateTime y = DateTime.Parse(dgvAppoinment.Rows[e.RowIndex].Cells[3].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Date", y.ToShortDateString());
                        commd.Parameters.AddWithValue("@Time", dgvAppoinment.Rows[e.RowIndex].Cells[4].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Reading1_Systolic", dgvAppoinment.Rows[e.RowIndex].Cells[5].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Reading2_Systolic", dgvAppoinment.Rows[e.RowIndex].Cells[6].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Reading1_Diastolic", dgvAppoinment.Rows[e.RowIndex].Cells[7].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Reading2_Diastolic", dgvAppoinment.Rows[e.RowIndex].Cells[8].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Systolic", dgvAppoinment.Rows[e.RowIndex].Cells[9].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Diastolic", dgvAppoinment.Rows[e.RowIndex].Cells[10].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Status", dgvAppoinment.Rows[e.RowIndex].Cells[11].FormattedValue.ToString());
                        conn.Open();
                        commd.ExecuteNonQuery();
                        conn.Close();
                        dgvAppoinment.Refresh();
                    }

                    finally
                    {
                        //after add appointment this record will delete
                    }
                }
                con.Close();
            }
            //When click Delete button
            if (dgvAppoinment.Columns[e.ColumnIndex].Name == "Delete")
            {
                string message = "Do you want to delete this record?";
                string title = "Refuse Request ";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection conn = new SqlConnection(conString);
                        SqlCommand commd = new SqlCommand("DeleteAppointment", conn);
                        commd.CommandType = CommandType.StoredProcedure;
                        commd.Parameters.AddWithValue("@Action", "DeleteAppointment");
                        commd.Parameters.AddWithValue("@PatientId", dgvAppoinment.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Date", dgvAppoinment.Rows[e.RowIndex].Cells[3].FormattedValue.ToString());
                        DateTime y = DateTime.Parse(dgvAppoinment.Rows[e.RowIndex].Cells[3].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Date", y.ToShortDateString());
                        commd.Parameters.AddWithValue("@Time", dgvAppoinment.Rows[e.RowIndex].Cells[4].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Reading1_Systolic", dgvAppoinment.Rows[e.RowIndex].Cells[5].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Reading2_Systolic", dgvAppoinment.Rows[e.RowIndex].Cells[6].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Reading1_Diastolic", dgvAppoinment.Rows[e.RowIndex].Cells[7].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Reading2_Diastolic", dgvAppoinment.Rows[e.RowIndex].Cells[8].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Systolic", dgvAppoinment.Rows[e.RowIndex].Cells[9].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Diastolic", dgvAppoinment.Rows[e.RowIndex].Cells[10].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Status", dgvAppoinment.Rows[e.RowIndex].Cells[11].FormattedValue.ToString());
                        conn.Open();
                        commd.ExecuteNonQuery();
                        conn.Close();
                        dgvAppoinment.Refresh();
                    }

                    finally
                    {
                        string title1 = "Deleted";
                        string message1 = "Selected record is Permanently Deleted :)";
                        MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                        DialogResult result1 = MessageBox.Show(message1, title1, buttons1, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        //Appointment and cancelled for Low BP
        private void AppointDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //When click Appointment button
            //pnlSchedule.Visible = true;
            if (AppointDgv.Columns[e.ColumnIndex].Name == "Appointment")
            {
                pnlSchedule.Visible = true;
                string PatientId = AppointDgv.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                SqlConnection con = new SqlConnection(conString);
                string selectSqlStu = ("SELECT * FROM Patient WHERE PatientId = '" + PatientId + "'");
                SqlCommand cmdStu = new SqlCommand(selectSqlStu, con);
                try
                {
                    con.Open();
                    using (SqlDataReader readPatient = cmdStu.ExecuteReader())
                    {
                        while (readPatient.Read())
                        {
                            txtPatientId.Text = (readPatient["PatientId"].ToString());
                            txtFirstName.Text = (readPatient["FirstName"].ToString());
                            txtLastName.Text = (readPatient["LastName"].ToString());
                            txtNic.Text = (readPatient["Nic"].ToString());
                            DateTime x = (DateTime)readPatient["DOB"];
                            txtDOB.Text = x.ToString("yyyy - MM - dd");
                            lblAge.Text = (readPatient["Age"].ToString());
                            txtMail.Text = (readPatient["Email"].ToString());
                            txtPhone.Text = (readPatient["Mobile"].ToString());
                        }
                    }
                }
                finally
                {
                    //After add the appointment delet the record
                    try
                    {
                        SqlConnection conn = new SqlConnection(conString);
                        SqlCommand commd = new SqlCommand("DeleteAppointment", conn);
                        commd.CommandType = CommandType.StoredProcedure;
                        commd.Parameters.AddWithValue("@Action", "DeleteAppointment");
                        commd.Parameters.AddWithValue("@PatientId", AppointDgv.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Date", AppointDgv.Rows[e.RowIndex].Cells[3].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Time", AppointDgv.Rows[e.RowIndex].Cells[4].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Reading1_Systolic", AppointDgv.Rows[e.RowIndex].Cells[5].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Reading2_Systolic", AppointDgv.Rows[e.RowIndex].Cells[6].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Reading1_Diastolic", AppointDgv.Rows[e.RowIndex].Cells[7].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Reading2_Diastolic", AppointDgv.Rows[e.RowIndex].Cells[8].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Systolic", AppointDgv.Rows[e.RowIndex].Cells[9].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Diastolic", AppointDgv.Rows[e.RowIndex].Cells[10].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Status", AppointDgv.Rows[e.RowIndex].Cells[11].FormattedValue.ToString());
                        conn.Open();
                        commd.ExecuteNonQuery();
                        conn.Close();
                        AppointDgv.Refresh();
                    }

                    finally
                    {
                        string title1 = "Deleted";
                        string message1 = "After add the appointment record is deleted :)";
                        MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                        DialogResult result1 = MessageBox.Show(message1, title1, buttons1, MessageBoxIcon.Stop);
                    }
                    con.Close();
                }
            }

            //When click Delete button
            if (AppointDgv.Columns[e.ColumnIndex].Name == "Delete")
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
                        SqlCommand commd = new SqlCommand("DeleteAppointment", conn);
                        commd.CommandType = CommandType.StoredProcedure;
                        commd.Parameters.AddWithValue("@Action", "DeleteAppointment");
                        commd.Parameters.AddWithValue("@PatientId", AppointDgv.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                        DateTime y = DateTime.Parse(AppointDgv.Rows[e.RowIndex].Cells[3].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Date", y.ToShortDateString());
                        commd.Parameters.AddWithValue("@Time", AppointDgv.Rows[e.RowIndex].Cells[4].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Reading1_Systolic", AppointDgv.Rows[e.RowIndex].Cells[5].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Reading2_Systolic", AppointDgv.Rows[e.RowIndex].Cells[6].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Reading1_Diastolic", AppointDgv.Rows[e.RowIndex].Cells[7].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Reading2_Diastolic", AppointDgv.Rows[e.RowIndex].Cells[8].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Systolic", AppointDgv.Rows[e.RowIndex].Cells[9].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Diastolic", AppointDgv.Rows[e.RowIndex].Cells[10].FormattedValue.ToString());
                        commd.Parameters.AddWithValue("@Status", AppointDgv.Rows[e.RowIndex].Cells[11].FormattedValue.ToString());
                        conn.Open();
                        commd.ExecuteNonQuery();
                        conn.Close();
                        AppointDgv.Refresh();
                    }

                    finally
                    {
                        string title1 = "Deleted";
                        string message1 = "Selected record is Permanently Deleted :)";
                        MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                        DialogResult result1 = MessageBox.Show(message1, title1, buttons1, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        //DateSelected in Calendar
        private void AppCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            var AppCalendar = sender as MonthCalendar;
            txtAppDate.Text = AppCalendar.SelectionStart.ToShortDateString();
            AppCalendar.Visible = false;
        }

        //Get date in Edit textbox
        private void AppCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            txtAppDate.Text = AppCalendar.SelectionRange.Start.ToShortDateString();
        }

        //Calendar hide after select data
        private void AppCalendar_Leave(object sender, EventArgs e)
        {
            var AppCalendar = sender as MonthCalendar;
            AppCalendar.Visible = false;
        }

        //Calendar Visible
        private void txtAppDate_Enter(object sender, EventArgs e)
        {
            AppCalendar.Visible = true;
        }

        //Calendar hide after select data
        private void txtAppDate_Leave(object sender, EventArgs e)
        {
            if (!AppCalendar.Focused)
                AppCalendar.Visible = false;
        }

        //for get time in 24hour format
        public void Time()
        {
            int hour = Int32.Parse(cmbTimeH.Text);
            if (hour == 00)
            {
                lbltime.Text = " 12 : " + cmbTimeM.Text;
                lblampm.Text = " midnight ";
            }
            else if (hour > 12)
            {
                int time24 = hour - 12;
                lbltime.Text = time24.ToString() + " : " + cmbTimeM.Text;
                lblampm.Text = " pm ";
            }
            else
            {
                lbltime.Text = cmbTimeH.Text + " : " + cmbTimeM.Text;
                lblampm.Text = " am ";
            }

        }

        //TIme typing method
        private void cmbTimeH_SelectedIndexChanged(object sender, EventArgs e)
        {
            Time();
        }

        //Show appointment panel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlSchedule.Visible = false;
        }
        //Clear field of send appointment
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAppDate.Text = "";
            txtNote.Text = "";
        }

        //Get an appointment record
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand("AddAppointment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "AddAppointment");
                cmd.Parameters.AddWithValue("@PatientId", txtPatientId.Text);
                cmd.Parameters.AddWithValue("@Date", DateTime.Parse(txtAppDate.Text));
                string HMTime = cmbTimeH.Text + ":" + cmbTimeM.Text + ":" + "00";
                DateTime STime = DateTime.Parse(HMTime);
                cmd.Parameters.AddWithValue("@Time", STime);
                cmd.Parameters.AddWithValue("@Description", txtNote.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            finally
            {
                string title = "Add Appointment ";
                string message = "Successfully added a Appointment  :)";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
                pnlSchedule.Visible = false;
            }
        }
    }
}


//TextBox box = sender as TextBox;
////string pattern = "\\d{1,2} :\\d{2}\\s*(AM|PM)";
//if (box != null)
//{
//    if (!Regex.IsMatch(box.Text, pattern, RegexOptions.CultureInvariant))
//    {
//        MessageBox.Show("Not a valid time format (HH:MM)");
//        //e.Cancel = true;
//        box.Select(0, box.Text.Length);
//    }
//}
