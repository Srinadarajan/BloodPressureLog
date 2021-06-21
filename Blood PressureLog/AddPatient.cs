using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Blood_PressureLog
{
    public partial class AddPatient : UserControl
    {
        string conString = @"Data Source=DESKTOP-7U9OT19\SQLEXPRESS;Initial Catalog=BloodPressureLog;Integrated Security=True";
        
        public AddPatient()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand("AddPatient", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "AddPatient");
                //cmd.Parameters.AddWithValue("@PatientId", txtPatientId.Text);
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
                cmd.Parameters.AddWithValue("@Username", "jngfjr");
                cmd.Parameters.AddWithValue("@Password", "njnfr");
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                btnSave.Enabled = false;
            }

            finally
            {
                btnSave.Enabled = true;
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
    }
}
