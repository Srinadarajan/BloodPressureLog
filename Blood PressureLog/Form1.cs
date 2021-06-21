using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using Blood_PressureLog.Properties;

namespace Blood_PressureLog
{
    public partial class Form1 : Form
    {
     
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //playaudio();
            //DateTime expiryDate = new DateTime(2021, 6, 20);
            //if (DateTime.Now.AddDays(5) >= expiryDate)
            //{
            //    MessageBox.Show("Expired");
            //    //SoundPlayer simpleSound = new SoundPlayer(Audio);
            //    //simpleSound.Play();
            //}
        }

        //private void playaudio() // defining the function
        //{
        //    SoundPlayer audio = new SoundPlayer(Blood_PressureLog.Properties.Resources.Connect); 
        //    audio.Play();
        //}
    }
}
