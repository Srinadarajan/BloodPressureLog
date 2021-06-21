
namespace Blood_PressureLog
{
    partial class PatientAppointment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtNamepatient = new System.Windows.Forms.TextBox();
            this.dgvAppoinment = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppoinment)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNamepatient
            // 
            this.txtNamepatient.BackColor = System.Drawing.Color.Green;
            this.txtNamepatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.txtNamepatient.ForeColor = System.Drawing.Color.White;
            this.txtNamepatient.Location = new System.Drawing.Point(1, 4);
            this.txtNamepatient.Margin = new System.Windows.Forms.Padding(4);
            this.txtNamepatient.Name = "txtNamepatient";
            this.txtNamepatient.Size = new System.Drawing.Size(1145, 38);
            this.txtNamepatient.TabIndex = 10;
            this.txtNamepatient.Text = "Appointment ";
            this.txtNamepatient.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvAppoinment
            // 
            this.dgvAppoinment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppoinment.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAppoinment.BackgroundColor = System.Drawing.Color.White;
            this.dgvAppoinment.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAppoinment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAppoinment.ColumnHeadersHeight = 40;
            this.dgvAppoinment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAppoinment.Location = new System.Drawing.Point(12, 82);
            this.dgvAppoinment.Name = "dgvAppoinment";
            this.dgvAppoinment.RowHeadersVisible = false;
            this.dgvAppoinment.RowHeadersWidth = 51;
            this.dgvAppoinment.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAppoinment.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvAppoinment.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAppoinment.RowTemplate.Height = 24;
            this.dgvAppoinment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppoinment.Size = new System.Drawing.Size(1111, 353);
            this.dgvAppoinment.TabIndex = 9;
            // 
            // PatientAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 741);
            this.Controls.Add(this.txtNamepatient);
            this.Controls.Add(this.dgvAppoinment);
            this.Name = "PatientAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PatientAppointment";
            this.Load += new System.EventHandler(this.PatientAppointment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppoinment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNamepatient;
        private System.Windows.Forms.DataGridView dgvAppoinment;
    }
}