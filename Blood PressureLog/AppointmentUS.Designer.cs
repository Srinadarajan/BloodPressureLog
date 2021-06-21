
namespace Blood_PressureLog
{
    partial class AppointmentUS
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAppoinment = new System.Windows.Forms.DataGridView();
            this.txtNamepatient = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AppointDgv = new System.Windows.Forms.DataGridView();
            this.pnlSchedule = new System.Windows.Forms.Panel();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.AppCalendar = new System.Windows.Forms.MonthCalendar();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblampm = new System.Windows.Forms.Label();
            this.lbltime = new System.Windows.Forms.Label();
            this.cmbTimeM = new System.Windows.Forms.ComboBox();
            this.label49 = new System.Windows.Forms.Label();
            this.cmbTimeH = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtAppDate = new System.Windows.Forms.TextBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtPatientId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Calendar = new System.Windows.Forms.MonthCalendar();
            this.lblAge = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtDOB = new System.Windows.Forms.TextBox();
            this.txtNic = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppoinment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppointDgv)).BeginInit();
            this.pnlSchedule.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAppoinment
            // 
            this.dgvAppoinment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppoinment.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAppoinment.BackgroundColor = System.Drawing.Color.White;
            this.dgvAppoinment.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAppoinment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvAppoinment.ColumnHeadersHeight = 40;
            this.dgvAppoinment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAppoinment.Location = new System.Drawing.Point(17, 112);
            this.dgvAppoinment.Name = "dgvAppoinment";
            this.dgvAppoinment.RowHeadersVisible = false;
            this.dgvAppoinment.RowHeadersWidth = 51;
            this.dgvAppoinment.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAppoinment.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvAppoinment.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAppoinment.RowTemplate.Height = 24;
            this.dgvAppoinment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppoinment.Size = new System.Drawing.Size(1705, 353);
            this.dgvAppoinment.TabIndex = 0;
            this.dgvAppoinment.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAppoinment_CellClick);
            // 
            // txtNamepatient
            // 
            this.txtNamepatient.BackColor = System.Drawing.Color.Green;
            this.txtNamepatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.txtNamepatient.ForeColor = System.Drawing.Color.White;
            this.txtNamepatient.Location = new System.Drawing.Point(0, 4);
            this.txtNamepatient.Margin = new System.Windows.Forms.Padding(4);
            this.txtNamepatient.Name = "txtNamepatient";
            this.txtNamepatient.Size = new System.Drawing.Size(1739, 45);
            this.txtNamepatient.TabIndex = 5;
            this.txtNamepatient.Text = "Appointment Requests";
            this.txtNamepatient.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(4, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "BP in                Risk";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(83, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 36);
            this.label2.TabIndex = 8;
            this.label2.Text = "HIGH";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(91, 491);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 36);
            this.label3.TabIndex = 10;
            this.label3.Text = "LOW";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(13, 494);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(230, 31);
            this.label4.TabIndex = 9;
            this.label4.Text = "BP in              Risk";
            // 
            // AppointDgv
            // 
            this.AppointDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AppointDgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.AppointDgv.BackgroundColor = System.Drawing.Color.White;
            this.AppointDgv.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AppointDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.AppointDgv.ColumnHeadersHeight = 40;
            this.AppointDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.AppointDgv.Location = new System.Drawing.Point(19, 530);
            this.AppointDgv.Name = "AppointDgv";
            this.AppointDgv.RowHeadersVisible = false;
            this.AppointDgv.RowHeadersWidth = 51;
            this.AppointDgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.AppointDgv.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.AppointDgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppointDgv.RowTemplate.Height = 24;
            this.AppointDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AppointDgv.Size = new System.Drawing.Size(1705, 353);
            this.AppointDgv.TabIndex = 11;
            this.AppointDgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AppointDgv_CellClick);
            // 
            // pnlSchedule
            // 
            this.pnlSchedule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSchedule.Controls.Add(this.textBox5);
            this.pnlSchedule.Controls.Add(this.textBox4);
            this.pnlSchedule.Controls.Add(this.textBox3);
            this.pnlSchedule.Controls.Add(this.AppCalendar);
            this.pnlSchedule.Controls.Add(this.btnClear);
            this.pnlSchedule.Controls.Add(this.btnCancel);
            this.pnlSchedule.Controls.Add(this.btnSave);
            this.pnlSchedule.Controls.Add(this.lblampm);
            this.pnlSchedule.Controls.Add(this.lbltime);
            this.pnlSchedule.Controls.Add(this.cmbTimeM);
            this.pnlSchedule.Controls.Add(this.label49);
            this.pnlSchedule.Controls.Add(this.cmbTimeH);
            this.pnlSchedule.Controls.Add(this.label14);
            this.pnlSchedule.Controls.Add(this.label16);
            this.pnlSchedule.Controls.Add(this.txtAppDate);
            this.pnlSchedule.Controls.Add(this.txtNote);
            this.pnlSchedule.Controls.Add(this.label15);
            this.pnlSchedule.Controls.Add(this.label13);
            this.pnlSchedule.Controls.Add(this.textBox2);
            this.pnlSchedule.Controls.Add(this.txtPatientId);
            this.pnlSchedule.Controls.Add(this.label5);
            this.pnlSchedule.Controls.Add(this.Calendar);
            this.pnlSchedule.Controls.Add(this.lblAge);
            this.pnlSchedule.Controls.Add(this.txtLastName);
            this.pnlSchedule.Controls.Add(this.label6);
            this.pnlSchedule.Controls.Add(this.txtMail);
            this.pnlSchedule.Controls.Add(this.label7);
            this.pnlSchedule.Controls.Add(this.txtFirstName);
            this.pnlSchedule.Controls.Add(this.label8);
            this.pnlSchedule.Controls.Add(this.txtPhone);
            this.pnlSchedule.Controls.Add(this.txtDOB);
            this.pnlSchedule.Controls.Add(this.txtNic);
            this.pnlSchedule.Controls.Add(this.label12);
            this.pnlSchedule.Controls.Add(this.label9);
            this.pnlSchedule.Controls.Add(this.label10);
            this.pnlSchedule.Controls.Add(this.label11);
            this.pnlSchedule.Controls.Add(this.textBox1);
            this.pnlSchedule.Location = new System.Drawing.Point(0, 4);
            this.pnlSchedule.Name = "pnlSchedule";
            this.pnlSchedule.Size = new System.Drawing.Size(1736, 908);
            this.pnlSchedule.TabIndex = 12;
            this.pnlSchedule.Visible = false;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.Green;
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(1531, 13);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(2, 869);
            this.textBox5.TabIndex = 130;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Green;
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(210, 13);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(2, 869);
            this.textBox4.TabIndex = 129;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Green;
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(210, 880);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(1323, 2);
            this.textBox3.TabIndex = 128;
            // 
            // AppCalendar
            // 
            this.AppCalendar.Location = new System.Drawing.Point(717, 410);
            this.AppCalendar.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.AppCalendar.Name = "AppCalendar";
            this.AppCalendar.TabIndex = 113;
            this.AppCalendar.Visible = false;
            this.AppCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.AppCalendar_DateChanged);
            this.AppCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.AppCalendar_DateSelected);
            this.AppCalendar.Leave += new System.EventHandler(this.AppCalendar_Leave);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Green;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(772, 795);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(187, 55);
            this.btnClear.TabIndex = 125;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Green;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(1314, 795);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(187, 55);
            this.btnCancel.TabIndex = 126;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(230, 795);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(187, 55);
            this.btnSave.TabIndex = 127;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblampm
            // 
            this.lblampm.AutoSize = true;
            this.lblampm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblampm.ForeColor = System.Drawing.Color.Green;
            this.lblampm.Location = new System.Drawing.Point(1097, 527);
            this.lblampm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblampm.Name = "lblampm";
            this.lblampm.Size = new System.Drawing.Size(17, 25);
            this.lblampm.TabIndex = 124;
            this.lblampm.Text = " ";
            // 
            // lbltime
            // 
            this.lbltime.AutoSize = true;
            this.lbltime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltime.ForeColor = System.Drawing.Color.Green;
            this.lbltime.Location = new System.Drawing.Point(1017, 527);
            this.lbltime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(17, 25);
            this.lbltime.TabIndex = 123;
            this.lbltime.Text = " ";
            // 
            // cmbTimeM
            // 
            this.cmbTimeM.DropDownHeight = 200;
            this.cmbTimeM.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.cmbTimeM.ForeColor = System.Drawing.Color.Navy;
            this.cmbTimeM.FormattingEnabled = true;
            this.cmbTimeM.IntegralHeight = false;
            this.cmbTimeM.Items.AddRange(new object[] {
            "00",
            "05",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55"});
            this.cmbTimeM.Location = new System.Drawing.Point(865, 516);
            this.cmbTimeM.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTimeM.Name = "cmbTimeM";
            this.cmbTimeM.Size = new System.Drawing.Size(89, 38);
            this.cmbTimeM.TabIndex = 119;
            this.cmbTimeM.SelectedIndexChanged += new System.EventHandler(this.cmbTimeH_SelectedIndexChanged);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.ForeColor = System.Drawing.Color.Green;
            this.label49.Location = new System.Drawing.Point(952, 519);
            this.label49.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(36, 31);
            this.label49.TabIndex = 122;
            this.label49.Text = "m";
            // 
            // cmbTimeH
            // 
            this.cmbTimeH.DropDownHeight = 200;
            this.cmbTimeH.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.cmbTimeH.ForeColor = System.Drawing.Color.Navy;
            this.cmbTimeH.FormattingEnabled = true;
            this.cmbTimeH.IntegralHeight = false;
            this.cmbTimeH.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "00"});
            this.cmbTimeH.Location = new System.Drawing.Point(717, 516);
            this.cmbTimeH.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTimeH.Name = "cmbTimeH";
            this.cmbTimeH.Size = new System.Drawing.Size(89, 38);
            this.cmbTimeH.TabIndex = 120;
            this.cmbTimeH.SelectedIndexChanged += new System.EventHandler(this.cmbTimeH_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Green;
            this.label14.Location = new System.Drawing.Point(801, 520);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 31);
            this.label14.TabIndex = 121;
            this.label14.Text = "h";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Green;
            this.label16.Location = new System.Drawing.Point(505, 516);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 31);
            this.label16.TabIndex = 118;
            this.label16.Text = "Time";
            // 
            // txtAppDate
            // 
            this.txtAppDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.txtAppDate.Location = new System.Drawing.Point(717, 410);
            this.txtAppDate.Name = "txtAppDate";
            this.txtAppDate.Size = new System.Drawing.Size(288, 37);
            this.txtAppDate.TabIndex = 117;
            this.txtAppDate.Enter += new System.EventHandler(this.txtAppDate_Enter);
            this.txtAppDate.Leave += new System.EventHandler(this.txtAppDate_Leave);
            // 
            // txtNote
            // 
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtNote.Location = new System.Drawing.Point(717, 604);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(431, 149);
            this.txtNote.TabIndex = 116;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Green;
            this.label15.Location = new System.Drawing.Point(505, 604);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(151, 31);
            this.label15.TabIndex = 115;
            this.label15.Text = "Description";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Green;
            this.label13.Location = new System.Drawing.Point(505, 410);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 31);
            this.label13.TabIndex = 111;
            this.label13.Text = "Date";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Green;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(210, 367);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(1323, 2);
            this.textBox2.TabIndex = 110;
            // 
            // txtPatientId
            // 
            this.txtPatientId.Enabled = false;
            this.txtPatientId.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientId.Location = new System.Drawing.Point(391, 81);
            this.txtPatientId.Margin = new System.Windows.Forms.Padding(4);
            this.txtPatientId.Name = "txtPatientId";
            this.txtPatientId.Size = new System.Drawing.Size(431, 37);
            this.txtPatientId.TabIndex = 109;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(230, 84);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 31);
            this.label5.TabIndex = 108;
            this.label5.Text = "Patient Id";
            // 
            // Calendar
            // 
            this.Calendar.Enabled = false;
            this.Calendar.Location = new System.Drawing.Point(1088, 78);
            this.Calendar.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.Calendar.Name = "Calendar";
            this.Calendar.TabIndex = 102;
            this.Calendar.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.lblAge.Location = new System.Drawing.Point(1051, 158);
            this.lblAge.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(44, 31);
            this.lblAge.TabIndex = 107;
            this.lblAge.Text = "00";
            // 
            // txtLastName
            // 
            this.txtLastName.Enabled = false;
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(391, 225);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(4);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(431, 37);
            this.txtLastName.TabIndex = 106;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Green;
            this.label6.Location = new System.Drawing.Point(230, 228);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 31);
            this.label6.TabIndex = 105;
            this.label6.Text = "Last Name";
            // 
            // txtMail
            // 
            this.txtMail.Enabled = false;
            this.txtMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMail.Location = new System.Drawing.Point(1051, 224);
            this.txtMail.Margin = new System.Windows.Forms.Padding(4);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(431, 38);
            this.txtMail.TabIndex = 103;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Green;
            this.label7.Location = new System.Drawing.Point(881, 228);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 31);
            this.label7.TabIndex = 93;
            this.label7.Text = "Email Id";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Enabled = false;
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(391, 155);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(431, 37);
            this.txtFirstName.TabIndex = 99;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Green;
            this.label8.Location = new System.Drawing.Point(230, 158);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 31);
            this.label8.TabIndex = 94;
            this.label8.Text = "First Name";
            // 
            // txtPhone
            // 
            this.txtPhone.Enabled = false;
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(1051, 300);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(431, 38);
            this.txtPhone.TabIndex = 104;
            // 
            // txtDOB
            // 
            this.txtDOB.Enabled = false;
            this.txtDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDOB.Location = new System.Drawing.Point(1051, 80);
            this.txtDOB.Margin = new System.Windows.Forms.Padding(4);
            this.txtDOB.Name = "txtDOB";
            this.txtDOB.ReadOnly = true;
            this.txtDOB.Size = new System.Drawing.Size(431, 38);
            this.txtDOB.TabIndex = 101;
            // 
            // txtNic
            // 
            this.txtNic.Enabled = false;
            this.txtNic.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNic.Location = new System.Drawing.Point(391, 301);
            this.txtNic.Margin = new System.Windows.Forms.Padding(4);
            this.txtNic.Name = "txtNic";
            this.txtNic.Size = new System.Drawing.Size(431, 37);
            this.txtNic.TabIndex = 100;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Green;
            this.label12.Location = new System.Drawing.Point(881, 158);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 31);
            this.label12.TabIndex = 95;
            this.label12.Text = "Age";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Green;
            this.label9.Location = new System.Drawing.Point(881, 304);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 31);
            this.label9.TabIndex = 96;
            this.label9.Text = "Mobile No";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Green;
            this.label10.Location = new System.Drawing.Point(881, 84);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 31);
            this.label10.TabIndex = 97;
            this.label10.Text = "DOB";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Green;
            this.label11.Location = new System.Drawing.Point(230, 304);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 31);
            this.label11.TabIndex = 98;
            this.label11.Text = "NIC No";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Green;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(210, 13);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1323, 45);
            this.textBox1.TabIndex = 92;
            this.textBox1.Text = "Appointment Schedule";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // AppointmentUS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.pnlSchedule);
            this.Controls.Add(this.AppointDgv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNamepatient);
            this.Controls.Add(this.dgvAppoinment);
            this.Name = "AppointmentUS";
            this.Size = new System.Drawing.Size(1739, 912);
            this.Load += new System.EventHandler(this.AppointmentUS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppoinment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppointDgv)).EndInit();
            this.pnlSchedule.ResumeLayout(false);
            this.pnlSchedule.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAppoinment;
        private System.Windows.Forms.TextBox txtNamepatient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView AppointDgv;
        private System.Windows.Forms.Panel pnlSchedule;
        private System.Windows.Forms.TextBox txtPatientId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MonthCalendar Calendar;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtDOB;
        private System.Windows.Forms.TextBox txtNic;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.MonthCalendar AppCalendar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtAppDate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lblampm;
        private System.Windows.Forms.Label lbltime;
        private System.Windows.Forms.ComboBox cmbTimeM;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.ComboBox cmbTimeH;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
    }
}
