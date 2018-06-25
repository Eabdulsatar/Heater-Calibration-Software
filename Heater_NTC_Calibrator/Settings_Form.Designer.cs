namespace Heater_NTC_Calibrator
{
    partial class Settings_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings_Form));
            this.Data_Grid_1 = new System.Windows.Forms.DataGridView();
            this.Temperatures = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thermostat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Heaters_thermosters = new System.Windows.Forms.TabControl();
            this.Ref1 = new System.Windows.Forms.TabPage();
            this.Ref2 = new System.Windows.Forms.TabPage();
            this.Data_Grid_2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ref3 = new System.Windows.Forms.TabPage();
            this.Data_Grid_3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ref4 = new System.Windows.Forms.TabPage();
            this.Data_Grid_4 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paste1 = new System.Windows.Forms.Button();
            this.Save1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Data_Grid_1)).BeginInit();
            this.Heaters_thermosters.SuspendLayout();
            this.Ref1.SuspendLayout();
            this.Ref2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Data_Grid_2)).BeginInit();
            this.Ref3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Data_Grid_3)).BeginInit();
            this.Ref4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Data_Grid_4)).BeginInit();
            this.SuspendLayout();
            // 
            // Data_Grid_1
            // 
            this.Data_Grid_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Data_Grid_1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Temperatures,
            this.Thermostat});
            this.Data_Grid_1.Location = new System.Drawing.Point(3, 3);
            this.Data_Grid_1.Name = "Data_Grid_1";
            this.Data_Grid_1.Size = new System.Drawing.Size(249, 485);
            this.Data_Grid_1.TabIndex = 34;
            this.Data_Grid_1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Data_Grid_1_CellContentClick);
            // 
            // Temperatures
            // 
            this.Temperatures.HeaderText = "Temperatures";
            this.Temperatures.Name = "Temperatures";
            // 
            // Thermostat
            // 
            this.Thermostat.HeaderText = "Thermostat";
            this.Thermostat.Name = "Thermostat";
            // 
            // Heaters_thermosters
            // 
            this.Heaters_thermosters.Controls.Add(this.Ref1);
            this.Heaters_thermosters.Controls.Add(this.Ref2);
            this.Heaters_thermosters.Controls.Add(this.Ref3);
            this.Heaters_thermosters.Controls.Add(this.Ref4);
            this.Heaters_thermosters.Location = new System.Drawing.Point(40, 12);
            this.Heaters_thermosters.Name = "Heaters_thermosters";
            this.Heaters_thermosters.SelectedIndex = 0;
            this.Heaters_thermosters.Size = new System.Drawing.Size(263, 517);
            this.Heaters_thermosters.TabIndex = 35;
            // 
            // Ref1
            // 
            this.Ref1.Controls.Add(this.Data_Grid_1);
            this.Ref1.Location = new System.Drawing.Point(4, 22);
            this.Ref1.Name = "Ref1";
            this.Ref1.Padding = new System.Windows.Forms.Padding(3);
            this.Ref1.Size = new System.Drawing.Size(255, 491);
            this.Ref1.TabIndex = 0;
            this.Ref1.Text = "Ref 1";
            this.Ref1.UseVisualStyleBackColor = true;
            // 
            // Ref2
            // 
            this.Ref2.Controls.Add(this.Data_Grid_2);
            this.Ref2.Location = new System.Drawing.Point(4, 22);
            this.Ref2.Name = "Ref2";
            this.Ref2.Padding = new System.Windows.Forms.Padding(3);
            this.Ref2.Size = new System.Drawing.Size(255, 491);
            this.Ref2.TabIndex = 1;
            this.Ref2.Text = "Ref 2";
            this.Ref2.UseVisualStyleBackColor = true;
            // 
            // Data_Grid_2
            // 
            this.Data_Grid_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Data_Grid_2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.Data_Grid_2.Location = new System.Drawing.Point(3, 3);
            this.Data_Grid_2.Name = "Data_Grid_2";
            this.Data_Grid_2.Size = new System.Drawing.Size(249, 485);
            this.Data_Grid_2.TabIndex = 36;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Temperatures";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Thermostat";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // Ref3
            // 
            this.Ref3.Controls.Add(this.Data_Grid_3);
            this.Ref3.Location = new System.Drawing.Point(4, 22);
            this.Ref3.Name = "Ref3";
            this.Ref3.Size = new System.Drawing.Size(255, 491);
            this.Ref3.TabIndex = 2;
            this.Ref3.Text = "Ref 3";
            this.Ref3.UseVisualStyleBackColor = true;
            // 
            // Data_Grid_3
            // 
            this.Data_Grid_3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Data_Grid_3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.Data_Grid_3.Location = new System.Drawing.Point(3, 3);
            this.Data_Grid_3.Name = "Data_Grid_3";
            this.Data_Grid_3.Size = new System.Drawing.Size(249, 485);
            this.Data_Grid_3.TabIndex = 36;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Temperatures";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Thermostat";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // Ref4
            // 
            this.Ref4.Controls.Add(this.Data_Grid_4);
            this.Ref4.Location = new System.Drawing.Point(4, 22);
            this.Ref4.Name = "Ref4";
            this.Ref4.Size = new System.Drawing.Size(255, 491);
            this.Ref4.TabIndex = 3;
            this.Ref4.Text = "Ref 4";
            this.Ref4.UseVisualStyleBackColor = true;
            // 
            // Data_Grid_4
            // 
            this.Data_Grid_4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Data_Grid_4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.Data_Grid_4.Location = new System.Drawing.Point(3, 3);
            this.Data_Grid_4.Name = "Data_Grid_4";
            this.Data_Grid_4.Size = new System.Drawing.Size(249, 485);
            this.Data_Grid_4.TabIndex = 36;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Temperatures";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Thermostat";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // Paste1
            // 
            this.Paste1.Location = new System.Drawing.Point(47, 535);
            this.Paste1.Name = "Paste1";
            this.Paste1.Size = new System.Drawing.Size(96, 48);
            this.Paste1.TabIndex = 36;
            this.Paste1.Text = "Paste";
            this.Paste1.UseVisualStyleBackColor = true;
            this.Paste1.Click += new System.EventHandler(this.Paste1_Click);
            // 
            // Save1
            // 
            this.Save1.Location = new System.Drawing.Point(200, 535);
            this.Save1.Name = "Save1";
            this.Save1.Size = new System.Drawing.Size(96, 48);
            this.Save1.TabIndex = 37;
            this.Save1.Text = "Save";
            this.Save1.UseVisualStyleBackColor = true;
            this.Save1.Click += new System.EventHandler(this.Save1_Click);
            // 
            // Settings_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 597);
            this.Controls.Add(this.Save1);
            this.Controls.Add(this.Paste1);
            this.Controls.Add(this.Heaters_thermosters);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings_Form";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_Form_FormClosing);
            this.Load += new System.EventHandler(this.Settings_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Data_Grid_1)).EndInit();
            this.Heaters_thermosters.ResumeLayout(false);
            this.Ref1.ResumeLayout(false);
            this.Ref2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Data_Grid_2)).EndInit();
            this.Ref3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Data_Grid_3)).EndInit();
            this.Ref4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Data_Grid_4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Data_Grid_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temperatures;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thermostat;
        private System.Windows.Forms.TabControl Heaters_thermosters;
        private System.Windows.Forms.TabPage Ref1;
        private System.Windows.Forms.TabPage Ref2;
        private System.Windows.Forms.DataGridView Data_Grid_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TabPage Ref3;
        private System.Windows.Forms.DataGridView Data_Grid_3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.TabPage Ref4;
        private System.Windows.Forms.DataGridView Data_Grid_4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Button Paste1;
        private System.Windows.Forms.Button Save1;
    }
}