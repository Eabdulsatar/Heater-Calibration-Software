namespace Heater_NTC_Calibrator
{
    partial class Calibration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calibration));
            this.label1 = new System.Windows.Forms.Label();
            this.Com_Ports = new System.Windows.Forms.ComboBox();
            this.Open_Port = new System.Windows.Forms.Button();
            this.Close_Port = new System.Windows.Forms.Button();
            this.Start_Cal = new System.Windows.Forms.Button();
            this.Stop_Cal = new System.Windows.Forms.Button();
            this.CalWorker = new System.ComponentModel.BackgroundWorker();
            this.Output_Data = new System.Windows.Forms.DataGridView();
            this.Temperature_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.J100_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.J101_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.J102_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.J103_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LookUpTable = new System.Windows.Forms.Button();
            this.Ontrak_SN = new System.Windows.Forms.Label();
            this.CalibrationSchedule = new System.Windows.Forms.Button();
            this.Contra_Gif = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Output_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contra_Gif)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(243, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Thermometer COM Port:";
            // 
            // Com_Ports
            // 
            this.Com_Ports.FormattingEnabled = true;
            this.Com_Ports.Location = new System.Drawing.Point(403, 46);
            this.Com_Ports.Name = "Com_Ports";
            this.Com_Ports.Size = new System.Drawing.Size(102, 21);
            this.Com_Ports.TabIndex = 1;
            this.Com_Ports.SelectedIndexChanged += new System.EventHandler(this.Com_Ports_SelectedIndexChanged);
            // 
            // Open_Port
            // 
            this.Open_Port.Location = new System.Drawing.Point(522, 40);
            this.Open_Port.Name = "Open_Port";
            this.Open_Port.Size = new System.Drawing.Size(81, 31);
            this.Open_Port.TabIndex = 2;
            this.Open_Port.Text = "Open Port";
            this.Open_Port.UseVisualStyleBackColor = true;
            this.Open_Port.Click += new System.EventHandler(this.Open_Port_Click);
            // 
            // Close_Port
            // 
            this.Close_Port.Location = new System.Drawing.Point(609, 40);
            this.Close_Port.Name = "Close_Port";
            this.Close_Port.Size = new System.Drawing.Size(81, 31);
            this.Close_Port.TabIndex = 3;
            this.Close_Port.Text = "Close Port";
            this.Close_Port.UseVisualStyleBackColor = true;
            this.Close_Port.Click += new System.EventHandler(this.Close_Port_Click);
            // 
            // Start_Cal
            // 
            this.Start_Cal.Location = new System.Drawing.Point(267, 120);
            this.Start_Cal.Name = "Start_Cal";
            this.Start_Cal.Size = new System.Drawing.Size(114, 38);
            this.Start_Cal.TabIndex = 5;
            this.Start_Cal.Text = "Start";
            this.Start_Cal.UseVisualStyleBackColor = true;
            this.Start_Cal.Click += new System.EventHandler(this.Start_Cal_Click);
            // 
            // Stop_Cal
            // 
            this.Stop_Cal.Location = new System.Drawing.Point(575, 120);
            this.Stop_Cal.Name = "Stop_Cal";
            this.Stop_Cal.Size = new System.Drawing.Size(114, 38);
            this.Stop_Cal.TabIndex = 6;
            this.Stop_Cal.Text = "Stop";
            this.Stop_Cal.UseVisualStyleBackColor = true;
            this.Stop_Cal.Click += new System.EventHandler(this.Stop_Cal_Click);
            // 
            // CalWorker
            // 
            this.CalWorker.WorkerReportsProgress = true;
            this.CalWorker.WorkerSupportsCancellation = true;
            this.CalWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CalWorker_DoWork);
            this.CalWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.CalWorker_ProgressChanged);
            // 
            // Output_Data
            // 
            this.Output_Data.AllowDrop = true;
            this.Output_Data.AllowUserToAddRows = false;
            this.Output_Data.AllowUserToDeleteRows = false;
            this.Output_Data.AllowUserToResizeColumns = false;
            this.Output_Data.AllowUserToResizeRows = false;
            this.Output_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Output_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Temperature_C,
            this.J100_C,
            this.J101_C,
            this.J102_C,
            this.J103_C});
            this.Output_Data.Location = new System.Drawing.Point(185, 213);
            this.Output_Data.Name = "Output_Data";
            this.Output_Data.Size = new System.Drawing.Size(653, 260);
            this.Output_Data.TabIndex = 7;
            // 
            // Temperature_C
            // 
            this.Temperature_C.HeaderText = "Temperature";
            this.Temperature_C.Name = "Temperature_C";
            // 
            // J100_C
            // 
            this.J100_C.HeaderText = "J100";
            this.J100_C.Name = "J100_C";
            // 
            // J101_C
            // 
            this.J101_C.HeaderText = "J101";
            this.J101_C.Name = "J101_C";
            // 
            // J102_C
            // 
            this.J102_C.HeaderText = "J102";
            this.J102_C.Name = "J102_C";
            // 
            // J103_C
            // 
            this.J103_C.HeaderText = "J103";
            this.J103_C.Name = "J103_C";
            // 
            // LookUpTable
            // 
            this.LookUpTable.ImageIndex = 2;
            this.LookUpTable.Location = new System.Drawing.Point(898, 46);
            this.LookUpTable.Name = "LookUpTable";
            this.LookUpTable.Size = new System.Drawing.Size(97, 33);
            this.LookUpTable.TabIndex = 9;
            this.LookUpTable.Text = "Look Up Table ";
            this.LookUpTable.UseVisualStyleBackColor = true;
            this.LookUpTable.Click += new System.EventHandler(this.LookUpTable_Click);
            // 
            // Ontrak_SN
            // 
            this.Ontrak_SN.AutoSize = true;
            this.Ontrak_SN.Location = new System.Drawing.Point(12, 472);
            this.Ontrak_SN.Name = "Ontrak_SN";
            this.Ontrak_SN.Size = new System.Drawing.Size(60, 13);
            this.Ontrak_SN.TabIndex = 91;
            this.Ontrak_SN.Text = "Ontrak SN:";
            // 
            // CalibrationSchedule
            // 
            this.CalibrationSchedule.FlatAppearance.BorderSize = 0;
            this.CalibrationSchedule.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.CalibrationSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CalibrationSchedule.Location = new System.Drawing.Point(898, 99);
            this.CalibrationSchedule.Name = "CalibrationSchedule";
            this.CalibrationSchedule.Size = new System.Drawing.Size(97, 34);
            this.CalibrationSchedule.TabIndex = 98;
            this.CalibrationSchedule.Text = "Calibration Schedule";
            this.CalibrationSchedule.UseVisualStyleBackColor = true;
            this.CalibrationSchedule.Click += new System.EventHandler(this.CalibrationTime_Click);
            // 
            // Contra_Gif
            // 
            this.Contra_Gif.Image = ((System.Drawing.Image)(resources.GetObject("Contra_Gif.Image")));
            this.Contra_Gif.InitialImage = ((System.Drawing.Image)(resources.GetObject("Contra_Gif.InitialImage")));
            this.Contra_Gif.Location = new System.Drawing.Point(62, 2);
            this.Contra_Gif.Name = "Contra_Gif";
            this.Contra_Gif.Size = new System.Drawing.Size(138, 205);
            this.Contra_Gif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Contra_Gif.TabIndex = 8;
            this.Contra_Gif.TabStop = false;
            // 
            // Calibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 494);
            this.Controls.Add(this.CalibrationSchedule);
            this.Controls.Add(this.Ontrak_SN);
            this.Controls.Add(this.LookUpTable);
            this.Controls.Add(this.Contra_Gif);
            this.Controls.Add(this.Output_Data);
            this.Controls.Add(this.Stop_Cal);
            this.Controls.Add(this.Start_Cal);
            this.Controls.Add(this.Close_Port);
            this.Controls.Add(this.Open_Port);
            this.Controls.Add(this.Com_Ports);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Calibration";
            this.Text = "Calibration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Calibration_FormClosing);
            this.Load += new System.EventHandler(this.Calibration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Output_Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contra_Gif)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Com_Ports;
        private System.Windows.Forms.Button Open_Port;
        private System.Windows.Forms.Button Close_Port;
        private System.Windows.Forms.Button Start_Cal;
        private System.Windows.Forms.Button Stop_Cal;
        private System.ComponentModel.BackgroundWorker CalWorker;
        private System.Windows.Forms.DataGridView Output_Data;
        private System.Windows.Forms.PictureBox Contra_Gif;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temperature_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn J100_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn J101_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn J102_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn J103_C;
        private System.Windows.Forms.Button LookUpTable;
        private System.Windows.Forms.Label Ontrak_SN;
        private System.Windows.Forms.Button CalibrationSchedule;
    }
}