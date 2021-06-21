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
    public partial class EditRequest : Form
    {
        //Get data from Patient form datagrid view
        public string Pid { get; set; }
        public string Pdate { get; set; }
        public string Ptime { get; set; }
        public string Page { get; set; }

        string conString = @"Data Source=DESKTOP-7U9OT19\SQLEXPRESS;Initial Catalog=BloodPressureLog;Integrated Security=True";

        public EditRequest()
        {
            InitializeComponent();
        }

        //Load Edit request send form
        private void EditRequest_Load(object sender, EventArgs e)
        {
            lblAge.Text = Page;
            SqlConnection con = new SqlConnection(conString);
            string selectSql = ("SELECT * FROM BPLog WHERE PatientId = '" + Pid + "' AND Date = '" + Pdate + "' AND Time = '" + Ptime + "'");
            SqlCommand cmd = new SqlCommand(selectSql, con);
            try
            {
                con.Open();

                using (SqlDataReader readPatient = cmd.ExecuteReader())
                {
                    while (readPatient.Read())
                    {
                        txtPId.Text = (readPatient["PatientId"].ToString());
                        txtBpDate.Text = (readPatient["Date"].ToString());
                        txtSystolic1.Text = (readPatient["Reading1_Systolic"].ToString());
                        txtSystolic2.Text = (readPatient["Reading2_Systolic"].ToString());
                        txtDiastolic1.Text = (readPatient["Reading1_Diastolic"].ToString());
                        txtDiastolic2.Text = (readPatient["Reading2_Diastolic"].ToString());
                        txtSystolic.Text = (readPatient["Systolic"].ToString());
                        txtDiastolic.Text = (readPatient["Diastolic"].ToString());
                        txtBPStatus.Text = (readPatient["Status"].ToString());
                        string HTime = Ptime;
                        string[] timeHM = HTime.Split(':');
                        cmbHour.Text = timeHM[0];
                        cmbMin.Text = timeHM[1];
                    }
                }
            }

            finally
            {
                con.Close();
            }
        }

        //When clicl edit button - form editable and show save button
        private void btnREdit_Click(object sender, EventArgs e)
        {
            btnRequest.Visible = true;
            btnREdit.Visible = false;
            txtSystolic1.Enabled = true;
            txtSystolic2.Enabled = true;
            txtDiastolic1.Enabled = true;
            txtDiastolic2.Enabled = true;
            txtNote.Enabled = true;
        }

        //When type Systolic and diastolic polies in the text boxes Final BP and status change
        private void txtSystolic1_TextChanged(object sender, EventArgs e)
        {
            //Carer Carer_1 = new Carer();
            //Carer_1.BPrecordCalculate();

            //Carer Carer1 = new Carer();
            //Carer1.BPrecordStatus();

            //Carer Carer2 = new Carer();
            //Carer2.BPaddStatus();

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

        //Send request to Carer to edit the record
        private void btnRequest_Click(object sender, EventArgs e)
        {
            string message = "Do you want to send a request to Carer to edit this BP record?";
            string title = "Request edit BP record";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                using (var CA = new CarerApproval())
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(conString);
                        SqlCommand cmd = new SqlCommand("Request", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "RequestEdit");
                        cmd.Parameters.AddWithValue("@PatientId", txtPId.Text);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Parse(txtBpDate.Text));
                        string HMTime = cmbHour.Text + ":" + cmbMin.Text + ":" + "00";
                        DateTime STime = DateTime.Parse(HMTime);
                        cmd.Parameters.AddWithValue("@Time", HMTime);
                        cmd.Parameters.AddWithValue("@Reading1_Systolic", Decimal.Parse(txtSystolic1.Text));
                        cmd.Parameters.AddWithValue("@Reading2_Systolic", Decimal.Parse(txtSystolic2.Text));
                        cmd.Parameters.AddWithValue("@Reading1_Diastolic", Decimal.Parse(txtDiastolic1.Text));
                        cmd.Parameters.AddWithValue("@Reading2_Diastolic", Decimal.Parse(txtDiastolic2.Text));
                        cmd.Parameters.AddWithValue("@Systolic", Decimal.Parse(txtSystolic.Text));
                        cmd.Parameters.AddWithValue("@Diastolic", Decimal.Parse(txtDiastolic.Text));
                        cmd.Parameters.AddWithValue("@Status", txtBPStatus.Text);
                        cmd.Parameters.AddWithValue("@Note", txtNote.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                    finally
                    {
                        string title1 = "Edit Request Send ";
                        string message1 = "Successfully You send a request to edit the record.!";
                        MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                        DialogResult result1 = MessageBox.Show(message1, title1, buttons1, MessageBoxIcon.Information);

                        btnRequest.Visible = false;
                        btnREdit.Visible = true;
                        txtSystolic1.Enabled = false;
                        txtSystolic2.Enabled = false;
                        txtDiastolic1.Enabled = false;
                        txtDiastolic2.Enabled = false;
                        txtNote.Enabled = false;
                     }
                }
            }
            else
            {
                btnRequest.Visible = false;
                btnREdit.Visible = true;
                txtSystolic1.Enabled = false;
                txtSystolic2.Enabled = false;
                txtDiastolic1.Enabled = false;
                txtDiastolic2.Enabled = false;
                txtNote.Enabled = false;
            }
        }

        //Close the form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
