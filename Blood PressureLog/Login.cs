using Blood_PressureLog.Properties;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blood_PressureLog
{
    public partial class Login : Form
    {
        //Connection String
        string cs = @"Data Source=DESKTOP-7U9OT19\SQLEXPRESS;Initial Catalog=BloodPressureLog;Integrated Security=True";
        int attempt = 0;
        string userType = "";

        Image Carer = Resources.Carer;
        Image Patient = Resources.Patient;

        public Login()
        {
            InitializeComponent();
            picCarer.Image = Carer;
            picPatient.Image = Patient;
        }

        //Load Picture in Carerbox
        private void picCarer_Click(object sender, EventArgs e)
        {
            picCarer.BorderStyle = BorderStyle.Fixed3D;
            picCarer.BackColor = Color.White;
            picPatient.BorderStyle = BorderStyle.None;
            picPatient.BackColor = Color.Transparent;
            userType = "Carer";
        }

        //Load Picture in Patientbox
        private void picPatient_Click(object sender, EventArgs e)
        {
            picPatient.BorderStyle = BorderStyle.Fixed3D;
            picPatient.BackColor = Color.White;
            picCarer.BorderStyle = BorderStyle.None;
            picCarer.BackColor = Color.Transparent;
            userType = "Patient";
        }

        //Carerbox - Select
        private void picCarer_MouseHover(object sender, EventArgs e)
        {
            int Carer_width = Carer.Width + ((Carer.Width + 1000) / 100);
            int Carer_height = Carer.Height + ((Carer.Height + 1000) / 100);
            Bitmap Carer_1 = new Bitmap(Carer_width, Carer_height);
            Graphics g = Graphics.FromImage(Carer_1);
            g.DrawImage(Carer, new Rectangle(Point.Empty, Carer_1.Size));
            picCarer.Image = Carer_1;
        }

        //Patientbox - Select
        private void picPatient_MouseHover(object sender, EventArgs e)
        {
            int Patient_width = Patient.Width + ((Patient.Width + 1000) / 100);
            int Patient_height = Patient.Height + ((Patient.Height + 1000) / 100);
            Bitmap Patient_1 = new Bitmap(Patient_width, Patient_height);
            Graphics g = Graphics.FromImage(Patient_1);
            g.DrawImage(Patient, new Rectangle(Point.Empty, Patient_1.Size));
            picPatient.Image = Patient_1;
        }

        //Carerbox - Mouse Leave
        private void picCarer_MouseLeave(object sender, EventArgs e)
        {
            picCarer.Image = Carer;
        }

        //Patientbox - Mouse leave
        private void picPatient_MouseLeave(object sender, EventArgs e)
        {
            picPatient.Image = Patient;
        }

        //Lofin to the PAtien or Carer Forms
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Not allowed emoty UN or PW fields
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                string message = "Please Provide UserName and Password";
                string title = "Empty Username OR/AND Password";
                MessageBox.Show(message, title);
                return;
            }

            try
            {
                if (userType == "Carer")
                {
                    //Create SqlConnection
                    SqlConnection con = new SqlConnection(cs);
                    //Query for check available UN and PW in Login Table
                    SqlCommand cmd = new SqlCommand("Select * from Patient where Username=@Username and Password=@Password", con);
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    con.Open();
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);
                    con.Close();
                    int count = ds.Tables[0].Rows.Count;
                    //Allow only 3 attempts to login
                    if (attempt < 2)
                    {
                        if (count == 1)
                        {
                            MessageBox.Show("Login Successful!");
                            this.Hide();
                            using (var f = new Patient())
                            {
                                f.Username = txtUsername.Text;
                                f.Password = txtPassword.Text;
                                f.Closed += (s, args) => this.Close();
                                f.ShowDialog();
                            }
                        }
                        else
                        {
                            attempt = attempt + 1;
                            string message = "You enterd wrong Username and/or Password So Please try again";
                            string title = "TRY AGAIN :(";
                            MessageBox.Show(message, title);
                            txtUsername.Text = "";
                            txtPassword.Text = "";
                        }
                    }

                    else
                    {
                        string message = "You across three attempt with wrong Username and/or Password So Please try again later!";
                        string title = "TRY AGAIN LATER :(";
                        MessageBox.Show(message, title);
                        this.Close();
                    }
                }
                else if (userType == "Patient")
                {
                    //Create SqlConnection
                    SqlConnection con = new SqlConnection(cs);
                    //Query for check available UN and PW in Carer Table
                    SqlCommand cmd = new SqlCommand("Select * from Carer where Username=@Username and Password=@Password", con);
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    con.Open();
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);
                    con.Close();
                    int count = ds.Tables[0].Rows.Count;
                    //Allow only 3 attempts to login
                    if (attempt < 2)
                    {
                        if (count == 1)
                        {
                            MessageBox.Show("Login Successful!");
                            this.Hide();
                            using (var f = new Carer())
                            {
                                f.Username = txtUsername.Text;
                                f.Password = txtPassword.Text;
                                f.Closed += (s, args) => this.Close();
                                f.ShowDialog();
                            }
                        }
                        else
                        {
                            attempt = attempt + 1;
                            string message = "You enterd wrong Username and/or Password So Please try again";
                            string title = "TRY AGAIN :(";
                            MessageBox.Show(message, title);
                            txtUsername.Text = "";
                            txtPassword.Text = "";
                        }
                    }

                    else
                    {
                        string message = "You across three attempt with wrong Username and/or Password So Please try again later!";
                        string title = "TRY AGAIN LATER :(";
                        MessageBox.Show(message, title);
                        this.Close();
                    }
                }
                else
                {
                    string message = "Are you a Patient or Carer ? First select the user Type.";
                    string title = "SELECT THE USER Type FIRST ! ";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
