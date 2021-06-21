using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Blood_PressureLog
{
    public partial class Patient : Form
    {
        string conString = @"Data Source=DESKTOP-7U9OT19\SQLEXPRESS;Initial Catalog=BloodPressureLog;Integrated Security=True";

        public string Username { get; set; }
        public string Password { get; set; }

        public Patient()
        {
            InitializeComponent();
        }

        //load Patient form
        private void Patient_Load(object sender, EventArgs e)
        {
            //InitializeDataGridView();
            disp_data();

            //To get match data with username and password
            SqlConnection con = new SqlConnection(conString);
            string selectSql = ("SELECT * FROM Patient WHERE Username = '" + Username + "' AND Password = '" + Password + "'");
            SqlCommand cmd = new SqlCommand(selectSql, con);
            try
            {
                con.Open();

                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        string PatientId = (read["PatientId"].ToString());
                        SqlConnection conStu = new SqlConnection(conString);

                        string selectSqlStu = ("SELECT * FROM Patient WHERE PatientId = '" + PatientId + "'");
                        SqlCommand cmdStu = new SqlCommand(selectSqlStu, conStu);
                        //try
                        //{
                        conStu.Open();

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
                                txtAge.Text = (readPatient["Age"].ToString());
                                txtMail.Text = (readPatient["Email"].ToString());
                                if (rbtFemale.Text == (readPatient["Gender"].ToString()))
                                {
                                    rbtFemale.Checked = true;
                                }
                                else
                                {
                                    rbtMale.Checked = true;
                                }
                                if (rbtABPlus.Text == (readPatient["Blood_Group"].ToString()))
                                {
                                    rbtABPlus.Checked = true;
                                }
                                else if (rbtABMin.Text == (readPatient["Blood_Group"].ToString()))
                                {
                                    rbtABMin.Checked = true;
                                }
                                else if (rbtABPlus.Text == (readPatient["Blood_Group"].ToString()))
                                {
                                    rbtABPlus.Checked = true;
                                }
                                else if (rbtAMin.Text == (readPatient["Blood_Group"].ToString()))
                                {
                                    rbtAMin.Checked = true;
                                }
                                else if (rbtAPlus.Text == (readPatient["Blood_Group"].ToString()))
                                {
                                    rbtAPlus.Checked = true;
                                }
                                else if (rbtBMin.Text == (readPatient["Blood_Group"].ToString()))
                                {
                                    rbtBMin.Checked = true;
                                }
                                else if (rbtBPlus.Text == (readPatient["Blood_Group"].ToString()))
                                {
                                    rbtBPlus.Checked = true;
                                }
                                else if (rbtABMin.Text == (readPatient["Blood_Group"].ToString()))
                                {
                                    rbtABMin.Checked = true;
                                }
                                else if (rbtOPlus.Text == (readPatient["Blood_Group"].ToString()))
                                {
                                    rbtOPlus.Checked = true;
                                }
                                else
                                {
                                    rbtOMin.Checked = true;
                                }
                                txtPhone.Text = (readPatient["Mobile"].ToString());
                                txtHeight.Text = (readPatient["Height"].ToString());
                                txtWeight.Text = (readPatient["Weight"].ToString());
                                txtGardian.Text = (readPatient["Gardian"].ToString());
                                txtGNic.Text = (readPatient["GNic"].ToString());
                                txtGMobile.Text = (readPatient["GMobile"].ToString());
                                string Address = (readPatient["Address"].ToString());
                                string[] values = Address.Split(',');
                                txtAddressL1.Text = values[0];
                                txtAddressL2.Text = values[1];
                                txtAddressL3.Text = values[2];
                            }
                        }
                        //}
                        //finally
                        //{
                        //    con.Close();
                        //}
                    }
                }
            }
            finally
            {
                con.Close();
            }
        }

        //Display data
        public void disp_data()
        {
            SqlConnection con = new SqlConnection(conString);
            string selectSql = ("SELECT * FROM Patient WHERE Username = '" + Username + "' AND Password = '" + Password + "'");
            SqlCommand cmd = new SqlCommand(selectSql, con);
            try
            {
                con.Open();

                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        string PatientId = (read["PatientId"].ToString());

                        SqlConnection connection = new SqlConnection(conString);
                        try
                        {
                            connection.Open();
                            SqlCommand cmd1 = connection.CreateCommand();
                            cmd1.CommandType = CommandType.Text;
                            cmd1.CommandText = "SELECT * FROM BPLog WHERE PatientId = '" + PatientId + "'";
                            cmd1.ExecuteNonQuery();
                            DataTable dt = new DataTable();
                            SqlDataAdapter da = new SqlDataAdapter(cmd1);
                            da.Fill(dt);
                            dGVPatient.DataSource = dt;
                            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                            dGVPatient.Columns.Add(btn);
                            btn.HeaderText = "Edit";
                            btn.Text = "Edit";
                            btn.Name = "Edit";
                            btn.UseColumnTextForButtonValue = true;
                            connection.Close();
                            dGVPatient.ClearSelection();
                        }
                        catch (Exception ex)
                        {
                            WriteException(ex);
                        }
                    }
                }
            }
            finally
            {
                con.Close();
            }


            dGVPatient.RowTemplate.Height = 40;
            dGVPatient.Columns[9].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dGVPatient.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dGVPatient.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVPatient.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dGVPatient.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dGVPatient.Columns[0].Visible = false;
            dGVPatient.Columns[3].HeaderText = "R1_Systolic";
            dGVPatient.Columns[4].HeaderText = "R1_Diastolic";
            dGVPatient.Columns[5].HeaderText = "R2_Systolic";
            dGVPatient.Columns[6].HeaderText = "R2_Diastolic";
            dGVPatient.Columns[3].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dGVPatient.Columns[4].HeaderCell.Style.Font = new Font("Arial", 11, FontStyle.Bold);
            dGVPatient.Columns[5].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            dGVPatient.Columns[6].HeaderCell.Style.Font = new Font("Arial", 11, FontStyle.Bold);
        }

        //To get Pation panel
        private void btnPatientProfile_Click(object sender, EventArgs e)
        {
            dGVPatient.Visible = false;
            pnlPatient.Visible = true;
        }

        //show calendar when txtDOb
        private void txtDOB_Enter(object sender, EventArgs e)
        {
            Calendar.Visible = true;
            Calendar.Enabled = true;
        }
        //Hide calandarwhen leave txtDOB
        private void txtDOB_Leave(object sender, EventArgs e)
        {
            if (!Calendar.Focused)
                Calendar.Visible = false;
        }
        //After day selected calandar will closed
        private void Calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            var Calendar = sender as MonthCalendar;
            txtDOB.Text = Calendar.SelectionStart.ToShortDateString();
            Calendar.Visible = false;

            DateTime today = DateTime.Today;
            DateTime dob = Convert.ToDateTime(txtDOB.Text);
            int age = today.Year - dob.Year;
            txtAge.Text = age.ToString();
        }
        //After leave calandar - clandar will hide
        private void Calendar_Leave(object sender, EventArgs e)
        {
            var Calendar = sender as MonthCalendar;
            Calendar.Visible = false;
        }
        //Close calander after date selected
        private void Calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            txtDOB.Text = Calendar.SelectionRange.Start.ToShortDateString();
        }

        //To show dta grid view of BP
        private void btnBP_Click(object sender, EventArgs e)
        {
            pnlPatient.Visible = false;
            dGVPatient.Visible = true;
        }

        //When any error occurs Show warnings and save details on Error.txt
        public void WriteException(Exception ex)
        {
            //this.Invalidate();
            string filePath = @"C:\Users\DELL\Desktop\Error.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("-----------------------------------------------------------------------------");
                writer.WriteLine("Date : " + DateTime.Now.ToString());
                writer.WriteLine();

                while (ex != null)
                {
                    writer.WriteLine(ex.GetType().FullName);
                    writer.WriteLine("Message : " + ex.Message);
                    writer.WriteLine("StackTrace : " + ex.StackTrace);
                    ex = ex.InnerException;
                }
            }
            //pnlEdit.Visible = false;
            //this.Close();
            this.Refresh();
            disp_data();

            string message = "Sorry You entered some wrong details on the fields Please try again later ";
            string title = "Wrong Deal";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
        }

        //Logout from patient form
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Login = new Login();
            Login.Show();
        }

        //Send data EditRequest form
        private void dGVPatient_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                using (var EditRequest = new EditRequest())
                {
                    DataGridViewRow row = dGVPatient.Rows[e.RowIndex];
                    EditRequest.Pid = row.Cells[0].Value.ToString();
                    EditRequest.Pdate = row.Cells[1].Value.ToString();
                    EditRequest.Ptime = row.Cells[2].Value.ToString();
                    EditRequest.Page = txtAge.Text;
                    EditRequest.ShowDialog();
                }
            }
        }

        //When Click Button All texboxes turn to enabled
        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            btnSave.Visible = true;
            txtFirstName.Enabled = true;
            txtMail.Enabled = true;
            txtNic.Enabled = true;
            txtLastName.Enabled = true;
            txtHeight.Enabled = true;
            txtWeight.Enabled = true;
            txtAddressL1.Enabled = true;
            txtAddressL2.Enabled = true;
            txtAddressL3.Enabled = true;
            rbtAPlus.Enabled = true;
            rbtAMin.Enabled = true;
            rbtABMin.Enabled = true;
            rbtBPlus.Enabled = true;
            rbtBMin.Enabled = true;
            rbtABPlus.Enabled = true;
            rbtOMin.Enabled = true;
            rbtOPlus.Enabled = true;
            rbtMale.Enabled = true;
            rbtFemale.Enabled = true;
            txtPhone.Enabled = true;
            txtDOB.Enabled = true;
        }

        //Close edit Patient panel
        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlPatient.Visible = false;
            dGVPatient.Visible = true;
        }

        //Save updated patient detail
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand("UpdatePatient", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Update");
                cmd.Parameters.AddWithValue("@PatientId", txtPatientId.Text);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@Nic", txtNic.Text);
                cmd.Parameters.AddWithValue("@Email", txtMail.Text);
                cmd.Parameters.AddWithValue("@DOB", txtDOB.Text);
                string add = txtAddressL1.Text.TrimStart() + " ," + txtAddressL2.Text.TrimStart() + " ," + txtAddressL3.Text.TrimStart();
                cmd.Parameters.AddWithValue("@Address", add);
                string value = "";
                bool isChecked = rbtMale.Checked;
                if (isChecked == true)
                {
                    value = rbtMale.Text;
                    cmd.Parameters.AddWithValue("@Gender", value);
                }
                else
                {
                    value = rbtFemale.Text;
                    cmd.Parameters.AddWithValue("@Gender", value);
                }
                string group = "";
                //bool gChecked = ;
                if (rbtOPlus.Checked == true)
                {
                    group = rbtOPlus.Text;
                    cmd.Parameters.AddWithValue("@Blood_Group", group);
                }
                else if (rbtOMin.Checked == true)
                {
                    group = rbtOMin.Text;
                    cmd.Parameters.AddWithValue("@Blood_Group", group);
                }
                else
                {
                    group = rbtABPlus.Text;
                    cmd.Parameters.AddWithValue("@Blood_Group", group);
                }
                cmd.Parameters.AddWithValue("@Mobile", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                cmd.Parameters.AddWithValue("@Height", txtHeight.Text);
                cmd.Parameters.AddWithValue("@Weight", txtWeight.Text);
                cmd.Parameters.AddWithValue("@Gardian", txtGardian.Text);
                cmd.Parameters.AddWithValue("@GNic", txtGNic.Text);
                cmd.Parameters.AddWithValue("@GMobile", txtGMobile.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                btnEdit.Enabled = false;
            }

            finally
            {
                btnEdit.Enabled = true;
                btnSave.Visible = false;
                txtFirstName.Enabled = false;
                txtMail.Enabled = false;
                txtNic.Enabled = false;
                txtLastName.Enabled = false;
                txtHeight.Enabled = false;
                txtWeight.Enabled = false;
                txtAddressL1.Enabled = false;
                txtAddressL2.Enabled = false;
                txtAddressL3.Enabled = false;
                rbtAPlus.Enabled = false;
                rbtAMin.Enabled = false;
                rbtABMin.Enabled = false;
                rbtBPlus.Enabled = false;
                rbtBMin.Enabled = false;
                rbtABPlus.Enabled = false;
                rbtOMin.Enabled = false;
                rbtOPlus.Enabled = false;
                rbtMale.Enabled = false;
                rbtFemale.Enabled = false;

                string title = "Updated your details";
                string message = "Patient personal details are edited and saved :)";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            }
        }

        //Load Report
        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (var BPLog= new BPLog())
            {
                BPLog.PatientID = txtPatientId.Text;
                BPLog.ShowDialog();
            }
        }

        //Load Patient alert
        private void btnAlert_Click(object sender, EventArgs e)
        {
            using (var PatientAlert = new PatientAlert())
            {
                PatientAlert.PatientID = txtPatientId.Text;
                PatientAlert.ShowDialog();
            }
        }

        //to open PatientAppointment form
        private void btnAppointment_Click(object sender, EventArgs e)
        {
            using (var PatientAppointment = new PatientAppointment())
            {
                PatientAppointment.PatientID = txtPatientId.Text;
                PatientAppointment.ShowDialog();
            }
        }

        //Calculate BMI
        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtHeight_TextChanged(object sender, EventArgs e)
        {
            double bmi = Double.Parse(txtWeight.Text) / ((Double.Parse(txtHeight.Text)/100) * (Double.Parse(txtHeight.Text)/100));
            txtBMI.Text = bmi.ToString("0.00");
        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {
            double bmi = Double.Parse(txtWeight.Text) / ((Double.Parse(txtHeight.Text) / 100) * (Double.Parse(txtHeight.Text) / 100));
            txtBMI.Text = bmi.ToString("0.00");
        }
    }
}