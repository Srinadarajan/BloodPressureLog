namespace Blood_PressureLog
{
    partial class Appointments
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.appointmentUS1 = new Blood_PressureLog.AppointmentUS();
            this.SuspendLayout();
            // 
            // appointmentUS1
            // 
            this.appointmentUS1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.appointmentUS1.Location = new System.Drawing.Point(4, -2);
            this.appointmentUS1.Name = "appointmentUS1";
            this.appointmentUS1.Size = new System.Drawing.Size(1739, 912);
            this.appointmentUS1.TabIndex = 0;
            // 
            // Appointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1758, 914);
            this.Controls.Add(this.appointmentUS1);
            this.Name = "Appointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Appointments";
            this.Load += new System.EventHandler(this.Appointments_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AppointmentUS appointmentUS1;
    }
}