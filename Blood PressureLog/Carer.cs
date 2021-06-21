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

namespace Blood_PressureLog
{
    public partial class Carer : Form
    {
        string conString = @"Data Source=DESKTOP-7U9OT19\SQLEXPRESS;Initial Catalog=BloodPressureLog;Integrated Security=True";

        //Send username and password to another form
        public string Username { get; set; }
        public string Password { get; set; }

        //Initialize Carer form
        public Carer()
        {
            InitializeComponent();
            pnlBPdataGrid.Visible = false;
            EditBPdataGrid.Visible = false;
            LoadToCombo();
        }

        //Load form 
        private void Carer_Load(object sender, EventArgs e)
        {
            this.bPLogTableAdapter.Fill(this.bloodPressureLogDataSet.BPLog);

            //Load Patiens ID in cmbPatientId when Type
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
            //Load Patiens ID in cmbPatientId
            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT PatientId FROM Patient", cnn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    cmbPatientId.ValueMember = "PatientId";
                    cmbPatientId.DisplayMember = "PatientId";
                    cmbPatientId.DataSource = dt;
                }
            }
        }

        //Initialize data grid view
        private void InitializeDataGrideView()
        {
            EditBPdataGrid.Dock = DockStyle.Fill;
            EditBPdataGrid.BackgroundColor = Color.White;
            EditBPdataGrid.BorderStyle = BorderStyle.Fixed3D;
            EditBPdataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FloralWhite;
            EditBPdataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Arail", 10, FontStyle.Bold);
            EditBPdataGrid.EnableHeadersVisualStyles = false;
            EditBPdataGrid.Columns[0].HeaderCell.Style.ForeColor = Color.Green;
            EditBPdataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            EditBPdataGrid.DefaultCellStyle.Font = new Font("Arail", 10, FontStyle.Regular);
            EditBPdataGrid.Columns[9].DefaultCellStyle.Font = new Font("Arail", 12F, FontStyle.Bold);
            EditBPdataGrid.Columns[9].DefaultCellStyle.ForeColor = Color.Red;
            EditBPdataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.EditBPdataGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.EditBPdataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.EditBPdataGrid.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //for (int i = 0; i < EditBPdataGrid.Rows.Count; i++)
            //{
            //    String state = EditBPdataGrid.Rows[i].Cells[9].ToString();
            //    if (state == "High")
            //    {
            //        EditBPdataGrid.Rows[i].Cells[9].Style.BackColor = Color.Pink;
            //     }
            //    else
            //    {
            //        EditBPdataGrid.Rows[i].Cells[9].Style.BackColor = Color.White;
            //     }
            //}
        }

        //Button click for show datagridview of BP records
        private void btnBP_Click(object sender, EventArgs e)
        {
            InitializeDataGrideView();
            pnlBPdataGrid.Visible = true;
            EditBPdataGrid.Visible = true;
            pnlPBPEnter.Visible = false;
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM BPLog", conString);
            DataSet ds = new DataSet();
            da.Fill(ds, "BPLog");
            EditBPdataGrid.DataSource = ds.Tables["BPLog"].DefaultView;
}

        //Create a edit button in datagridview of BP records
        private void BPdataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (EditBPdataGrid.Columns[e.ColumnIndex].Name == "Edit")
            {
                EditBPdataGrid.BeginEdit(true);
                EditBPdataGrid.Visible = false;
                pnlBPedit.Visible = true;
            }
        }

        //Button click for show New BP record add panel
        private void btnAddBP_Click(object sender, EventArgs e)
        {
            pnlPBPEnter.Visible = true;
            pnlBPdataGrid.Visible = false;
            EditBPdataGrid.Visible = false;
        }

        //When add BP select patien ID - fill all related data
        private void cmbPatientId_TextChanged(object sender, EventArgs e)
        {
            LoadToCombo();
        }

        //Load IDs to combobox
        private void LoadToCombo() {
            SqlConnection con = new SqlConnection(conString);
            string selectSql = ("SELECT * FROM Patient WHERE PatientId = '" + cmbPatientId.Text + "'");
            SqlCommand cmd = new SqlCommand(selectSql, con);
            try
            {
                con.Open();

                using (SqlDataReader readPatient = cmd.ExecuteReader())
                {
                    while (readPatient.Read())
                    {
                        txtFirstName.Text = (readPatient["FirstName"].ToString() + "  " + readPatient["LastName"].ToString());
                        txtNic.Text = (readPatient["Nic"].ToString());
                        lblAge.Text = (readPatient["Age"].ToString());
                    }
                }
            }

            finally
            {
                con.Close();
            }
        }

        //Get new BP details and save
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand("AddBP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "AddBP");
                cmd.Parameters.AddWithValue("@PatientId", cmbPatientId.Text);
                cmd.Parameters.AddWithValue("@Date", DateTime.Parse(txtBpDate.Text));
                string HMTime = cmbTimeH.Text + ":" + cmbTimeM.Text + ":" + "00";
                DateTime STime = DateTime.Parse(HMTime);
                cmd.Parameters.AddWithValue("@Time", HMTime);
                cmd.Parameters.AddWithValue("@Reading1_Systolic", Decimal.Parse(txtSystolic1.Text));
                cmd.Parameters.AddWithValue("@Reading2_Systolic", Decimal.Parse(txtSystolic2.Text));
                cmd.Parameters.AddWithValue("@Reading1_Diastolic", Decimal.Parse(txtDiastolic1.Text));
                cmd.Parameters.AddWithValue("@Reading2_Diastolic", Decimal.Parse(txtDiastolic2.Text));
                cmd.Parameters.AddWithValue("@Systolic", Decimal.Parse(txtSystolic.Text));
                cmd.Parameters.AddWithValue("@Diastolic", Decimal.Parse(txtDiastolic.Text));
                cmd.Parameters.AddWithValue("@Status", txtBPStatus.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            finally
            {
                string title = "Add Bp record ";
                string message = "Successfully added a BP new record of a patient :)";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
                EditBPdataGrid.Visible = true;
                pnlPBPEnter.Visible = false;
                pnlBPdataGrid.Visible = true;
                cmbPatientId.Text = "";
                txtBpDate.Text = "";
                txtSystolic1.Text = "0";
                txtSystolic2.Text = "0";
                txtDiastolic1.Text = "0";
                txtDiastolic2.Text = "0";
            }
        }

        //When click edit button in data grid view  load pnlBPedit with data
        private void EditBPdataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                EditBPdataGrid.Visible = false;
                pnlBPdataGrid.Visible = false;
                pnlBPedit.Visible = true;
                DataGridViewRow row = EditBPdataGrid.Rows[e.RowIndex];
                string Patientid = row.Cells[0].Value.ToString();

                SqlConnection con = new SqlConnection(conString);
                string selectSql = ("SELECT * FROM BPLog WHERE PatientId = '" + Patientid + "'");
                SqlCommand cmd = new SqlCommand(selectSql, con);
                try
                {
                    con.Open();

                    using (SqlDataReader readPatient = cmd.ExecuteReader())
                    {
                        while (readPatient.Read())
                        {
                            txtPId.Text = (readPatient["PatientId"].ToString());
                            txtEditDate.Text = (readPatient["Date"].ToString());
                            txtEdit_Systolic1.Text = (readPatient["Reading1_Systolic"].ToString());
                            txtEdit_Systolic2.Text = (readPatient["Reading2_Systolic"].ToString());
                            txtEdit_Diastolic1.Text = (readPatient["Reading1_Diastolic"].ToString());
                            txtEdit_Diastolic2.Text = (readPatient["Reading2_Diastolic"].ToString());
                            lblSystolic.Text = (readPatient["Systolic"].ToString());
                            lblDiastolic.Text = (readPatient["Diastolic"].ToString());
                            lblEdit_BPStatus.Text = (readPatient["Status"].ToString());
                            string HTime = EditBPdataGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
                            string[] timeHM = HTime.Split(':');
                            cmbHour.Text = timeHM[0];
                            cmbMin.Text = timeHM[1];
                        }
                    }
                    string selectSqlAge = ("SELECT * FROM Patient WHERE PatientId = '" + Patientid + "'");
                    SqlCommand cmdAge = new SqlCommand(selectSqlAge, con);
                    using (SqlDataReader readAge = cmdAge.ExecuteReader())
                    {
                        while (readAge.Read())
                        {
                            txtAge.Text = (readAge["Age"].ToString());
                        }
                    }
                }

                finally
                {
                    con.Close();
                }
            }
        }

        //When click edit button fields enable and Save button show
        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnEditBPSave.Visible = true;
            btnEditBPcancel.Visible = true;
            btnEdit.Enabled = false;
            txtEditDate.Enabled = true;
            BPeditCalendar.Enabled = true;
            txtEdit_Systolic1.Enabled = true;
            txtEdit_Systolic2.Enabled = true;
            txtEdit_Diastolic1.Enabled = true;
            txtEdit_Diastolic2.Enabled = true;
        }

        //After edit BP details save
        private void btnEditBPSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand("UpdateBpLog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Update");
                cmd.Parameters.AddWithValue("@PatientId", txtPId.Text);
                cmd.Parameters.AddWithValue("@Date", txtEditDate.Text);
                string HTime = cmbHour.Text + ":" + cmbMin.Text + ":" + "00";
                DateTime STime = DateTime.Parse(HTime);
                cmd.Parameters.AddWithValue("@Time", HTime);
                cmd.Parameters.AddWithValue("@Reading1_Systolic", txtEdit_Systolic1.Text);
                cmd.Parameters.AddWithValue("@Reading2_Systolic", txtEdit_Systolic2.Text);
                cmd.Parameters.AddWithValue("@Reading1_Diastolic", txtEdit_Diastolic1.Text);
                cmd.Parameters.AddWithValue("@Reading2_Diastolic", txtEdit_Diastolic2.Text);
                cmd.Parameters.AddWithValue("@Systolic", lblSystolic.Text);
                cmd.Parameters.AddWithValue("@Diastolic", lblDiastolic.Text);
                cmd.Parameters.AddWithValue("@Status", lblEdit_BPStatus.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            finally
            {
                btnEdit.Enabled = true;
                btnCancel.Visible = false;
                EditBPdataGrid.Visible = true;
                txtEditDate.Enabled = false;
                txtEditDate.Enabled = false;
                txtEdit_Systolic1.Enabled = false;
                txtEdit_Systolic2.Enabled = false;
                txtEdit_Diastolic1.Enabled = false;
                txtEdit_Diastolic2.Enabled = false;
                btnEditBPSave.Visible = false;
                string title = "Updated your details";
                string message = "Patient Blood pressure details are edited and saved :)";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            }
        }

        //Delate a BP record
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string message = "Do you want to delete this BP Record permanently?";
            string title = "Delete BP Decord ";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                try
                {
                    SqlConnection conn = new SqlConnection(conString);
                    SqlCommand commd = new SqlCommand("DeleteBPrecord", conn);
                    commd.CommandType = CommandType.StoredProcedure;
                    commd.Parameters.AddWithValue("@Action", "DeleteBPrecord");
                    commd.Parameters.AddWithValue("@PatientId", txtPId.Text);
                    commd.Parameters.AddWithValue("@Date", DateTime.Parse(txtEditDate.Text));
                    string HMTime = cmbHour.Text + ":" + cmbMin.Text + ":" + "00";
                    DateTime STime = DateTime.Parse(HMTime);
                    commd.Parameters.AddWithValue("@Time", HMTime);
                    //string h = cmbHour.Text;
                    //string m = cmbMin.Text;
                    //string time = h + ":" + m + ":" + "00";
                    //commd.Parameters.AddWithValue("@Time", time);
                    commd.Parameters.AddWithValue("@Reading1_Systolic", Decimal.Parse(txtEdit_Systolic1.Text));
                    commd.Parameters.AddWithValue("@Reading2_Systolic", Decimal.Parse(txtEdit_Systolic2.Text));
                    commd.Parameters.AddWithValue("@Reading1_Diastolic", Decimal.Parse(txtEdit_Diastolic1.Text));
                    commd.Parameters.AddWithValue("@Reading2_Diastolic", Decimal.Parse(txtEdit_Diastolic2.Text));
                    commd.Parameters.AddWithValue("@Systolic", Decimal.Parse(lblSystolic.Text));
                    commd.Parameters.AddWithValue("@Diastolic", Decimal.Parse(lblDiastolic.Text));
                    commd.Parameters.AddWithValue("@Status", lblEdit_BPStatus.Text);
                    conn.Open();
                    commd.ExecuteNonQuery();
                    conn.Close();
                }

                finally
                {
                    string title1 = "Deleted";
                    string message1 = "Selected BP record is Permanently Deleted :)";
                    MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, buttons1, MessageBoxIcon.Stop);
                }
                pnlBPedit.Visible = false;
                pnlBPdataGrid.Visible = true;
            }
            else
            {
                this.Close();
            }

        }

        //Cancel the edit details
        private void btnEditBPcancel_Click(object sender, EventArgs e)
        {
            pnlBPedit.Visible = false;
            pnlBPdataGrid.Visible = true;
            EditBPdataGrid.Visible = true;
            pnlPBPEnter.Visible = false;
            btnEdit.Enabled = true;
        }

        //Get time in datagrid view to cmbHour and cmbMin
        private void EditBPdataGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string StartTime = EditBPdataGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
            string[] valuesST = StartTime.Split(':');
            cmbHour.Text = valuesST[0];
            cmbMin.Text = valuesST[1];
        }

        //DateSelected in Calendar
        private void BpCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            var BpCalendar = sender as MonthCalendar;
            txtBpDate.Text = BpCalendar.SelectionStart.ToShortDateString();
            BpCalendar.Visible = false;
        }

        //Calendar hide after select data
        private void BpCalendar_Leave(object sender, EventArgs e)
        {
            var BpCalendar = sender as MonthCalendar;
            BpCalendar.Visible = false;
        }

        //Calendar Visible
        private void txtBpDate_Enter(object sender, EventArgs e)
        {
            BpCalendar.Visible = true;
        }

        //Calendar hide after select data
        private void txtBpDate_Leave(object sender, EventArgs e)
        {
            if (!BpCalendar.Focused)
                BpCalendar.Visible = false;
        }

        //Clear enterd data
        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbPatientId.Text = "";
            cmbTimeH.Text = "";
            cmbTimeM.Text = "";
            txtBpDate.Text = "";
            txtSystolic1.Text = "";
            txtSystolic2.Text = "";
            txtDiastolic1.Text = "";
            txtDiastolic2.Text = "";
            txtSystolic.Text = "";
            txtDiastolic.Text = "";
            txtBPStatus.Text = "";
        }

        //Hide edit panel of BP record and show data grid view
        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlPBPEnter.Visible = false;
            pnlBPdataGrid.Visible = true;
        }

        //Calendar Visible for edit
        private void txtEditDate_Enter(object sender, EventArgs e)
        {
            BPeditCalendar.Visible = true;
        }

        //Calendar hide after select data
        private void txtEditDate_Leave(object sender, EventArgs e)
        {
            if (!BPeditCalendar.Focused)
                BPeditCalendar.Visible = false;
        }

        //DateSelected in Calendar for edit
        private void BPeditCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            var BPeditCalendar = sender as MonthCalendar;
            txtEditDate.Text = BPeditCalendar.SelectionStart.ToShortDateString();
            BPeditCalendar.Visible = false;
        }

        //Calandar hide after edit date selected
        private void BPeditCalendar_Leave(object sender, EventArgs e)
        {
            var BPeditCalendar = sender as MonthCalendar;
            BPeditCalendar.Visible = false;
        }

        //Get date in Edit textbox
        private void BPeditCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            txtEditDate.Text = BPeditCalendar.SelectionRange.Start.ToShortDateString();
        }

        //Get date in Edit textbox
        private void BpCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            txtBpDate.Text = BpCalendar.SelectionRange.Start.ToShortDateString();
        }

        //When type Systolic and diastolic polies in the text boxes Final BP and status change
        private void txtEdit_Systolic1_TextChanged(object sender, EventArgs e)
        {
            BPCalculate();
            BPStatus();
            Status();
        }

        private void txtEdit_Diastolic1_TextChanged(object sender, EventArgs e)
        {
            BPCalculate();
            BPStatus();
            Status();
        }

        private void txtEdit_Systolic2_TextChanged(object sender, EventArgs e)
        {
            BPCalculate();
            BPStatus();
            Status();
        }

        private void txtEdit_Diastolic2_TextChanged(object sender, EventArgs e)
        {
            BPCalculate();
            BPStatus();
            Status();
        }

        private void txtSystolic1_TextChanged(object sender, EventArgs e)
        {
            BPrecordCalculate();
            BPrecordStatus();
            BPaddStatus();
        }

        private void txtDiastolic1_TextChanged(object sender, EventArgs e)
        {
            BPrecordCalculate();
            BPrecordStatus();
            BPaddStatus();
        }

        private void txtSystolic2_TextChanged(object sender, EventArgs e)
        {
            BPrecordCalculate();
            BPrecordStatus();
            BPaddStatus();
        }

        private void txtDiastolic2_TextChanged(object sender, EventArgs e)
        {
            BPrecordCalculate();
            BPrecordStatus();
            BPaddStatus();
        }

        private void cmbTimeH_SelectedIndexChanged(object sender, EventArgs e)
        {
            Time();
        }

        private void cmbTimeM_SelectedIndexChanged(object sender, EventArgs e)
        {
            Time();
        }

        //Show Patients form
        private void btnPatients_Click(object sender, EventArgs e)
        {
            var Patient = new PatientDetail();
            Patient.Show();
        }

        //Show emergency form
        private void btnEmergency_Click(object sender, EventArgs e)
        {
            var Appointments = new CarerApproval();
            Appointments.Show();
        }

        //Show Appointments form
        private void btnAppointment_Click(object sender, EventArgs e)
        {
            var Appointments = new Appointments();
            Appointments.Show();
        }

        //Logout from the Carer form.
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Login = new Login();
            Login.Closed += (s, args) => this.Close();
            Login.Show();
        }

        //For caluclate the final BP
        public void BPrecordCalculate()
        {
            double Systolic1 = Double.Parse(txtSystolic1.Text);
            double Diastolic1 = Double.Parse(txtDiastolic1.Text);
            double Systolic2 = Double.Parse(txtSystolic2.Text);
            double Diastolic2 = Double.Parse(txtDiastolic2.Text);
            double Systolic = 0;
            double Diastolic = 0;
            if (Systolic2 != 0)
            {
                Systolic = (Systolic1 + Systolic2) / 2;
            }
            else
            {
                Systolic = Systolic1;
            }
            if (Diastolic2 != 0)
            {
                Diastolic = (Diastolic1 + Diastolic2) / 2;
            }
            else
            {
                Diastolic = Diastolic1;
            }
            txtSystolic.Text = Systolic.ToString();
            txtDiastolic.Text = Diastolic.ToString();
        }

        //For caluclate the BP Status
        public void BPrecordStatus()
        {
            int age = Int32.Parse(lblAge.Text);
            double Systolic = Double.Parse(txtSystolic.Text);
            double Diastolic = Double.Parse(txtDiastolic.Text);
            if (age <= 1 && age >= 10)
            {
                //BP Status();
                if (Systolic < 75)
                {
                    txtSystolicStatus.Text = "Low";
                }
                else if (Systolic >= 75 && Systolic <= 110)
                {
                    txtSystolicStatus.Text = "Normal";
                }
                else
                {
                    txtSystolicStatus.Text = "High";
                }


                if (Diastolic < 50)
                {
                    txtDiastolicStatus.Text = "Low";
                }
                else if (Diastolic >= 50 && Diastolic <= 75)
                {
                    txtDiastolicStatus.Text = "Normal";
                }
                else
                {
                    txtDiastolicStatus.Text = "High";
                }
            }

            else if (age < 10 && age >= 20)
            {
                //Status();
                if (Systolic < 108)
                {
                    txtSystolicStatus.Text = "Low";
                }
                else if (Systolic >= 108 && Systolic <= 120)
                {
                    txtSystolicStatus.Text = "Normal";
                }
                else
                {
                    txtSystolicStatus.Text = "High";
                }


                if (Diastolic < 75)
                {
                    txtDiastolicStatus.Text = "Low";
                }
                else if (Diastolic >= 75 && Diastolic <= 80)
                {
                    txtDiastolicStatus.Text = "Normal";
                }
                else
                {
                    txtDiastolicStatus.Text = "High";
                }
            }
            else
            {
                //Status();
                if (Systolic < 75)
                {
                    txtSystolicStatus.Text = "Low";
                }
                else if (Systolic >= 75 && Systolic <= 110)
                {
                    txtSystolicStatus.Text = "Normal";
                }
                else
                {
                    txtSystolicStatus.Text = "High";
                }


                if (Diastolic < 50)
                {
                    txtDiastolicStatus.Text = "Low";
                }
                else if (Diastolic >= 50 && Diastolic <= 75)
                {
                    txtDiastolicStatus.Text = "Normal";
                }
                else
                {
                    txtDiastolicStatus.Text = "High";
                }
            }
        }

        //For caluclate the final BP Status
        public void BPaddStatus()
        {

            if (txtSystolicStatus.Text == "Normal" && txtDiastolicStatus.Text == "Normal")
            {
                txtBPStatus.Text = "Normal";
            }
            else if (txtSystolicStatus.Text == "Low" && txtDiastolicStatus.Text == "Low")
            {
                txtBPStatus.Text = "Low";
            }
            else if (txtSystolicStatus.Text == "High" && txtDiastolicStatus.Text == "High")
            {
                txtBPStatus.Text = "High";
            }
            else if (txtSystolicStatus.Text == "High" && txtDiastolicStatus.Text == "Normal")
            {
                txtBPStatus.Text = "Systolic - High";
            }
            else if (txtSystolicStatus.Text == "Normal" && txtDiastolicStatus.Text == "High")
            {
                txtBPStatus.Text = "Diastolic - High";
            }
            else if (txtSystolicStatus.Text == "Low" && txtDiastolicStatus.Text == "Normal")
            {
                txtBPStatus.Text = "Systolic - Low";
            }
            else // if (txtSystolicStatus.Text == "Normal" && txtDiastolicStatus.Text == "Low")
            {
                txtBPStatus.Text = "Diastolic - Low";
            }
        }

        //For caluclate the final BP after edit
        public void BPCalculate()
        {
            double Systolic1 = Double.Parse(txtEdit_Systolic1.Text);
            double Diastolic1 = Double.Parse(txtEdit_Diastolic1.Text);
            double Systolic2 = Double.Parse(txtEdit_Systolic2.Text);
            double Diastolic2 = Double.Parse(txtEdit_Diastolic2.Text);
            double Systolic = 0;
            double Diastolic = 0;
            if (Systolic2 != 0)
            {
                Systolic = (Systolic1 + Systolic2) / 2;
            }
            else
            {
                Systolic = Systolic1;
            }
            if (Diastolic2 != 0)
            {
                Diastolic = (Diastolic1 + Diastolic2) / 2;
            }
            else
            {
                Diastolic = Diastolic1;
            }
            lblSystolic.Text = Systolic.ToString();
            lblDiastolic.Text = Diastolic.ToString();
        }

        //For caluclate the BP Status after edit
        public void BPStatus()
        {
            int age = Int32.Parse(txtAge.Text);
            double Systolic = Double.Parse(lblSystolic.Text);
            double Diastolic = Double.Parse(lblDiastolic.Text);
            if (age <= 1 && age >= 10)
            {
                //BP Status();
                if (Systolic < 75)
                {
                    lblSystolicStatus.Text = "Low";
                }
                else if (Systolic >= 75 && Systolic <= 110)
                {
                    lblSystolicStatus.Text = "Normal";
                }
                else
                {
                    lblSystolicStatus.Text = "High";
                }


                if (Diastolic < 50)
                {
                    lblDiastolicStatus.Text = "Low";
                }
                else if (Diastolic >= 50 && Diastolic <= 75)
                {
                    lblDiastolicStatus.Text = "Normal";
                }
                else
                {
                    lblDiastolicStatus.Text = "High";
                }
            }

            else if (age < 10 && age >= 20)
            {
                //Status();
                if (Systolic < 108)
                {
                    lblSystolicStatus.Text = "Low";
                }
                else if (Systolic >= 108 && Systolic <= 120)
                {
                    lblSystolicStatus.Text = "Normal";
                }
                else
                {
                    lblSystolicStatus.Text = "High";
                }


                if (Diastolic < 75)
                {
                    lblDiastolicStatus.Text = "Low";
                }
                else if (Diastolic >= 75 && Diastolic <= 80)
                {
                    lblDiastolicStatus.Text = "Normal";
                }
                else
                {
                    lblDiastolicStatus.Text = "High";
                }
            }
            else
            {
                //Status();
                if (Systolic < 75)
                {
                    lblSystolicStatus.Text = "Low";
                }
                else if (Systolic >= 75 && Systolic <= 110)
                {
                    lblSystolicStatus.Text = "Normal";
                }
                else
                {
                    lblSystolicStatus.Text = "High";
                }


                if (Diastolic < 50)
                {
                    lblDiastolicStatus.Text = "Low";
                }
                else if (Diastolic >= 50 && Diastolic <= 75)
                {
                    lblDiastolicStatus.Text = "Normal";
                }
                else
                {
                    lblDiastolicStatus.Text = "High";
                }
            }
        }

        //For caluclate the final BP Status after edit
        public void Status()
        {

            if (lblSystolicStatus.Text == "Normal" && lblDiastolicStatus.Text == "Normal")
            {
                lblEdit_BPStatus.Text = "Normal";
            }
            else if (lblSystolicStatus.Text == "Low" && lblDiastolicStatus.Text == "Low")
            {
                lblEdit_BPStatus.Text = "Low";
            }
            else if (lblSystolicStatus.Text == "High" && lblDiastolicStatus.Text == "High")
            {
                lblEdit_BPStatus.Text = "High";
            }
            else if (lblSystolicStatus.Text == "High" && lblDiastolicStatus.Text == "Normal")
            {
                lblEdit_BPStatus.Text = "Systolic - High";
            }
            else if (lblSystolicStatus.Text == "Normal" && lblDiastolicStatus.Text == "High")
            {
                lblEdit_BPStatus.Text = "Diastolic - High";
            }
            else if (lblSystolicStatus.Text == "Low" && lblDiastolicStatus.Text == "Normal")
            {
                lblEdit_BPStatus.Text = "Systolic - Low";
            }
            else // if (lblSystolicStatus.Text == "Normal" && lblDiastolicStatus.Text == "Low")
            {
                lblEdit_BPStatus.Text = "Diastolic - Low";
            }
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
        //Only accept numbers
        private void txtSystolic1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        //Only accept numbers
        private void txtDiastolic1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        //Only accept numbers
        private void txtSystolic2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        //Only accept numbers
        private void txtDiastolic2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}