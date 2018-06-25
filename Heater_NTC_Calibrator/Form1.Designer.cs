namespace Heater_NTC_Calibrator
{
    partial class Heater_Calibrator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Heater_Calibrator));
            this.Icons = new System.Windows.Forms.ImageList(this.components);
            this.Connect2 = new System.Windows.Forms.Button();
            this.Second_Worker = new System.ComponentModel.BackgroundWorker();
            this.Temperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TopHeater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BottomHeater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Top_Heater_Temp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bottom_Heater_Temp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.J100_Therm = new System.Windows.Forms.Label();
            this.J101_Therm = new System.Windows.Forms.Label();
            this.J135_Therm = new System.Windows.Forms.Label();
            this.J134_Therm = new System.Windows.Forms.Label();
            this.THERM_AVG = new System.Windows.Forms.Label();
            this.HTR_RESUTLS = new System.Windows.Forms.DataGridView();
            this.Heater_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HTR_OFFSET = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HTR_VALUE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.HTR1_Radio = new System.Windows.Forms.RadioButton();
            this.HTR2_Radio = new System.Windows.Forms.RadioButton();
            this.HTR4_Radio = new System.Windows.Forms.RadioButton();
            this.HTR6_Radio = new System.Windows.Forms.RadioButton();
            this.HTR5_Radio = new System.Windows.Forms.RadioButton();
            this.HTR3_Radio = new System.Windows.Forms.RadioButton();
            this.HTR9_Radio = new System.Windows.Forms.RadioButton();
            this.HTR8_Radio = new System.Windows.Forms.RadioButton();
            this.HTR7_Radio = new System.Windows.Forms.RadioButton();
            this.HTR12_Radio = new System.Windows.Forms.RadioButton();
            this.HTR11_Radio = new System.Windows.Forms.RadioButton();
            this.HTR10_Radio = new System.Windows.Forms.RadioButton();
            this.HTR16_Radio = new System.Windows.Forms.RadioButton();
            this.HTR15_Radio = new System.Windows.Forms.RadioButton();
            this.HTR14_Radio = new System.Windows.Forms.RadioButton();
            this.HTR13_Radio = new System.Windows.Forms.RadioButton();
            this.Print_PB = new System.Windows.Forms.Button();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.LotNum = new System.Windows.Forms.TextBox();
            this.Ontrak_SN = new System.Windows.Forms.Label();
            this.Version_Number = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fireworks = new System.Windows.Forms.PictureBox();
            this.Kenny = new System.Windows.Forms.PictureBox();
            this.Calibration_PB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.HTR_RESUTLS)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fireworks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Kenny)).BeginInit();
            this.SuspendLayout();
            // 
            // Icons
            // 
            this.Icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Icons.ImageStream")));
            this.Icons.TransparentColor = System.Drawing.Color.Transparent;
            this.Icons.Images.SetKeyName(0, "IconPause");
            this.Icons.Images.SetKeyName(1, "IconPlay");
            this.Icons.Images.SetKeyName(2, "74035-settings-symbol.png");
            // 
            // Connect2
            // 
            this.Connect2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Connect2.Location = new System.Drawing.Point(246, 28);
            this.Connect2.Name = "Connect2";
            this.Connect2.Size = new System.Drawing.Size(113, 40);
            this.Connect2.TabIndex = 12;
            this.Connect2.Text = "Start";
            this.Connect2.Click += new System.EventHandler(this.Connect2_Click);
            // 
            // Second_Worker
            // 
            this.Second_Worker.WorkerReportsProgress = true;
            this.Second_Worker.WorkerSupportsCancellation = true;
            this.Second_Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Second_Worker_DoWork);
            this.Second_Worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Second_Worker_ProgressChanged);
            // 
            // Temperature
            // 
            this.Temperature.HeaderText = "Temperature";
            this.Temperature.Name = "Temperature";
            // 
            // TopHeater
            // 
            this.TopHeater.HeaderText = "TopHeater";
            this.TopHeater.Name = "TopHeater";
            // 
            // BottomHeater
            // 
            this.BottomHeater.HeaderText = "BottomHeater";
            this.BottomHeater.Name = "BottomHeater";
            // 
            // Top_Heater_Temp
            // 
            this.Top_Heater_Temp.HeaderText = "Top Heater Temp";
            this.Top_Heater_Temp.Name = "Top_Heater_Temp";
            // 
            // Bottom_Heater_Temp
            // 
            this.Bottom_Heater_Temp.HeaderText = "Bottom_Heater_Temp";
            this.Bottom_Heater_Temp.Name = "Bottom_Heater_Temp";
            // 
            // J100_Therm
            // 
            this.J100_Therm.AutoSize = true;
            this.J100_Therm.Location = new System.Drawing.Point(6, 59);
            this.J100_Therm.Name = "J100_Therm";
            this.J100_Therm.Size = new System.Drawing.Size(66, 13);
            this.J100_Therm.TabIndex = 62;
            this.J100_Therm.Text = "J100_Therm";
            this.J100_Therm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // J101_Therm
            // 
            this.J101_Therm.AutoSize = true;
            this.J101_Therm.Location = new System.Drawing.Point(6, 33);
            this.J101_Therm.Name = "J101_Therm";
            this.J101_Therm.Size = new System.Drawing.Size(66, 13);
            this.J101_Therm.TabIndex = 63;
            this.J101_Therm.Text = "J101_Therm";
            this.J101_Therm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // J135_Therm
            // 
            this.J135_Therm.AutoSize = true;
            this.J135_Therm.Location = new System.Drawing.Point(6, 20);
            this.J135_Therm.Name = "J135_Therm";
            this.J135_Therm.Size = new System.Drawing.Size(66, 13);
            this.J135_Therm.TabIndex = 65;
            this.J135_Therm.Text = "J135_Therm";
            this.J135_Therm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // J134_Therm
            // 
            this.J134_Therm.AutoSize = true;
            this.J134_Therm.Location = new System.Drawing.Point(6, 46);
            this.J134_Therm.Name = "J134_Therm";
            this.J134_Therm.Size = new System.Drawing.Size(66, 13);
            this.J134_Therm.TabIndex = 64;
            this.J134_Therm.Text = "J134_Therm";
            this.J134_Therm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // THERM_AVG
            // 
            this.THERM_AVG.AutoSize = true;
            this.THERM_AVG.Location = new System.Drawing.Point(6, 72);
            this.THERM_AVG.Name = "THERM_AVG";
            this.THERM_AVG.Size = new System.Drawing.Size(74, 13);
            this.THERM_AVG.TabIndex = 66;
            this.THERM_AVG.Text = "THERM_AVG";
            this.THERM_AVG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HTR_RESUTLS
            // 
            this.HTR_RESUTLS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.HTR_RESUTLS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HTR_RESUTLS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Heater_Number,
            this.HTR_OFFSET,
            this.HTR_VALUE});
            this.HTR_RESUTLS.Location = new System.Drawing.Point(101, 109);
            this.HTR_RESUTLS.Name = "HTR_RESUTLS";
            this.HTR_RESUTLS.RowHeadersVisible = false;
            this.HTR_RESUTLS.Size = new System.Drawing.Size(325, 489);
            this.HTR_RESUTLS.TabIndex = 68;
            // 
            // Heater_Number
            // 
            this.Heater_Number.HeaderText = "Heater Number ";
            this.Heater_Number.Name = "Heater_Number";
            // 
            // HTR_OFFSET
            // 
            this.HTR_OFFSET.HeaderText = "Heater Offset";
            this.HTR_OFFSET.Name = "HTR_OFFSET";
            // 
            // HTR_VALUE
            // 
            this.HTR_VALUE.HeaderText = "Heater Temperature";
            this.HTR_VALUE.Name = "HTR_VALUE";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.J135_Therm);
            this.groupBox1.Controls.Add(this.J101_Therm);
            this.groupBox1.Controls.Add(this.J134_Therm);
            this.groupBox1.Controls.Add(this.J100_Therm);
            this.groupBox1.Controls.Add(this.THERM_AVG);
            this.groupBox1.Location = new System.Drawing.Point(467, 507);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 91);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thermistors Temperature";
            // 
            // HTR1_Radio
            // 
            this.HTR1_Radio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.HTR1_Radio.AutoSize = true;
            this.HTR1_Radio.Location = new System.Drawing.Point(133, 149);
            this.HTR1_Radio.Name = "HTR1_Radio";
            this.HTR1_Radio.Size = new System.Drawing.Size(14, 13);
            this.HTR1_Radio.TabIndex = 71;
            this.HTR1_Radio.TabStop = true;
            this.HTR1_Radio.UseVisualStyleBackColor = true;
            this.HTR1_Radio.CheckedChanged += new System.EventHandler(this.HTR1_Radio_CheckedChanged);
            // 
            // HTR2_Radio
            // 
            this.HTR2_Radio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.HTR2_Radio.AutoSize = true;
            this.HTR2_Radio.Location = new System.Drawing.Point(133, 171);
            this.HTR2_Radio.Name = "HTR2_Radio";
            this.HTR2_Radio.Size = new System.Drawing.Size(14, 13);
            this.HTR2_Radio.TabIndex = 72;
            this.HTR2_Radio.TabStop = true;
            this.HTR2_Radio.UseVisualStyleBackColor = true;
            this.HTR2_Radio.CheckedChanged += new System.EventHandler(this.HTR2_Radio_CheckedChanged);
            // 
            // HTR4_Radio
            // 
            this.HTR4_Radio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.HTR4_Radio.AutoSize = true;
            this.HTR4_Radio.Location = new System.Drawing.Point(133, 215);
            this.HTR4_Radio.Name = "HTR4_Radio";
            this.HTR4_Radio.Size = new System.Drawing.Size(14, 13);
            this.HTR4_Radio.TabIndex = 73;
            this.HTR4_Radio.TabStop = true;
            this.HTR4_Radio.UseVisualStyleBackColor = true;
            this.HTR4_Radio.CheckedChanged += new System.EventHandler(this.HTR4_Radio_CheckedChanged);
            // 
            // HTR6_Radio
            // 
            this.HTR6_Radio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.HTR6_Radio.AutoSize = true;
            this.HTR6_Radio.Location = new System.Drawing.Point(133, 259);
            this.HTR6_Radio.Name = "HTR6_Radio";
            this.HTR6_Radio.Size = new System.Drawing.Size(14, 13);
            this.HTR6_Radio.TabIndex = 76;
            this.HTR6_Radio.TabStop = true;
            this.HTR6_Radio.UseVisualStyleBackColor = true;
            this.HTR6_Radio.CheckedChanged += new System.EventHandler(this.HTR6_Radio_CheckedChanged);
            // 
            // HTR5_Radio
            // 
            this.HTR5_Radio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.HTR5_Radio.AutoSize = true;
            this.HTR5_Radio.Location = new System.Drawing.Point(133, 237);
            this.HTR5_Radio.Name = "HTR5_Radio";
            this.HTR5_Radio.Size = new System.Drawing.Size(14, 13);
            this.HTR5_Radio.TabIndex = 75;
            this.HTR5_Radio.TabStop = true;
            this.HTR5_Radio.UseVisualStyleBackColor = true;
            this.HTR5_Radio.CheckedChanged += new System.EventHandler(this.HTR5_Radio_CheckedChanged);
            // 
            // HTR3_Radio
            // 
            this.HTR3_Radio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.HTR3_Radio.AutoSize = true;
            this.HTR3_Radio.Location = new System.Drawing.Point(133, 193);
            this.HTR3_Radio.Name = "HTR3_Radio";
            this.HTR3_Radio.Size = new System.Drawing.Size(14, 13);
            this.HTR3_Radio.TabIndex = 74;
            this.HTR3_Radio.TabStop = true;
            this.HTR3_Radio.UseVisualStyleBackColor = true;
            this.HTR3_Radio.CheckedChanged += new System.EventHandler(this.HTR3_Radio_CheckedChanged);
            // 
            // HTR9_Radio
            // 
            this.HTR9_Radio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.HTR9_Radio.AutoSize = true;
            this.HTR9_Radio.Location = new System.Drawing.Point(133, 325);
            this.HTR9_Radio.Name = "HTR9_Radio";
            this.HTR9_Radio.Size = new System.Drawing.Size(14, 13);
            this.HTR9_Radio.TabIndex = 79;
            this.HTR9_Radio.TabStop = true;
            this.HTR9_Radio.UseVisualStyleBackColor = true;
            this.HTR9_Radio.CheckedChanged += new System.EventHandler(this.HTR9_Radio_CheckedChanged);
            // 
            // HTR8_Radio
            // 
            this.HTR8_Radio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.HTR8_Radio.AutoSize = true;
            this.HTR8_Radio.Location = new System.Drawing.Point(133, 303);
            this.HTR8_Radio.Name = "HTR8_Radio";
            this.HTR8_Radio.Size = new System.Drawing.Size(14, 13);
            this.HTR8_Radio.TabIndex = 78;
            this.HTR8_Radio.TabStop = true;
            this.HTR8_Radio.UseVisualStyleBackColor = true;
            this.HTR8_Radio.CheckedChanged += new System.EventHandler(this.HTR8_Radio_CheckedChanged);
            // 
            // HTR7_Radio
            // 
            this.HTR7_Radio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.HTR7_Radio.AutoSize = true;
            this.HTR7_Radio.Location = new System.Drawing.Point(133, 281);
            this.HTR7_Radio.Name = "HTR7_Radio";
            this.HTR7_Radio.Size = new System.Drawing.Size(14, 13);
            this.HTR7_Radio.TabIndex = 77;
            this.HTR7_Radio.TabStop = true;
            this.HTR7_Radio.UseVisualStyleBackColor = true;
            this.HTR7_Radio.CheckedChanged += new System.EventHandler(this.HTR7_Radio_CheckedChanged);
            // 
            // HTR12_Radio
            // 
            this.HTR12_Radio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.HTR12_Radio.AutoSize = true;
            this.HTR12_Radio.Location = new System.Drawing.Point(133, 391);
            this.HTR12_Radio.Name = "HTR12_Radio";
            this.HTR12_Radio.Size = new System.Drawing.Size(14, 13);
            this.HTR12_Radio.TabIndex = 82;
            this.HTR12_Radio.TabStop = true;
            this.HTR12_Radio.UseVisualStyleBackColor = true;
            this.HTR12_Radio.CheckedChanged += new System.EventHandler(this.HTR12_Radio_CheckedChanged);
            // 
            // HTR11_Radio
            // 
            this.HTR11_Radio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.HTR11_Radio.AutoSize = true;
            this.HTR11_Radio.Location = new System.Drawing.Point(133, 369);
            this.HTR11_Radio.Name = "HTR11_Radio";
            this.HTR11_Radio.Size = new System.Drawing.Size(14, 13);
            this.HTR11_Radio.TabIndex = 81;
            this.HTR11_Radio.TabStop = true;
            this.HTR11_Radio.UseVisualStyleBackColor = true;
            this.HTR11_Radio.CheckedChanged += new System.EventHandler(this.HTR11_Radio_CheckedChanged);
            // 
            // HTR10_Radio
            // 
            this.HTR10_Radio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.HTR10_Radio.AutoSize = true;
            this.HTR10_Radio.Location = new System.Drawing.Point(133, 347);
            this.HTR10_Radio.Name = "HTR10_Radio";
            this.HTR10_Radio.Size = new System.Drawing.Size(14, 13);
            this.HTR10_Radio.TabIndex = 80;
            this.HTR10_Radio.TabStop = true;
            this.HTR10_Radio.UseVisualStyleBackColor = true;
            this.HTR10_Radio.CheckedChanged += new System.EventHandler(this.HTR10_Radio_CheckedChanged);
            // 
            // HTR16_Radio
            // 
            this.HTR16_Radio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.HTR16_Radio.AutoSize = true;
            this.HTR16_Radio.Location = new System.Drawing.Point(133, 479);
            this.HTR16_Radio.Name = "HTR16_Radio";
            this.HTR16_Radio.Size = new System.Drawing.Size(14, 13);
            this.HTR16_Radio.TabIndex = 86;
            this.HTR16_Radio.TabStop = true;
            this.HTR16_Radio.UseVisualStyleBackColor = true;
            this.HTR16_Radio.CheckedChanged += new System.EventHandler(this.HTR16_Radio_CheckedChanged);
            // 
            // HTR15_Radio
            // 
            this.HTR15_Radio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.HTR15_Radio.AutoSize = true;
            this.HTR15_Radio.Location = new System.Drawing.Point(133, 457);
            this.HTR15_Radio.Name = "HTR15_Radio";
            this.HTR15_Radio.Size = new System.Drawing.Size(14, 13);
            this.HTR15_Radio.TabIndex = 85;
            this.HTR15_Radio.TabStop = true;
            this.HTR15_Radio.UseVisualStyleBackColor = true;
            this.HTR15_Radio.CheckedChanged += new System.EventHandler(this.HTR15_Radio_CheckedChanged);
            // 
            // HTR14_Radio
            // 
            this.HTR14_Radio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.HTR14_Radio.AutoSize = true;
            this.HTR14_Radio.Location = new System.Drawing.Point(133, 435);
            this.HTR14_Radio.Name = "HTR14_Radio";
            this.HTR14_Radio.Size = new System.Drawing.Size(14, 13);
            this.HTR14_Radio.TabIndex = 84;
            this.HTR14_Radio.TabStop = true;
            this.HTR14_Radio.UseVisualStyleBackColor = true;
            this.HTR14_Radio.CheckedChanged += new System.EventHandler(this.HTR14_Radio_CheckedChanged);
            // 
            // HTR13_Radio
            // 
            this.HTR13_Radio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.HTR13_Radio.AutoSize = true;
            this.HTR13_Radio.Location = new System.Drawing.Point(133, 413);
            this.HTR13_Radio.Name = "HTR13_Radio";
            this.HTR13_Radio.Size = new System.Drawing.Size(14, 13);
            this.HTR13_Radio.TabIndex = 83;
            this.HTR13_Radio.TabStop = true;
            this.HTR13_Radio.UseVisualStyleBackColor = true;
            this.HTR13_Radio.CheckedChanged += new System.EventHandler(this.HTR13_Radio_CheckedChanged);
            // 
            // Print_PB
            // 
            this.Print_PB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Print_PB.Location = new System.Drawing.Point(429, 28);
            this.Print_PB.Name = "Print_PB";
            this.Print_PB.Size = new System.Drawing.Size(113, 40);
            this.Print_PB.TabIndex = 87;
            this.Print_PB.Text = "Print";
            this.Print_PB.Click += new System.EventHandler(this.Print_PB_Click);
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // printDocument
            // 
            this.printDocument.DocumentName = "";
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage_1);
            // 
            // printDialog
            // 
            this.printDialog.Document = this.printDocument;
            this.printDialog.UseEXDialog = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 88;
            this.label1.Text = "Lot Number:";
            // 
            // LotNum
            // 
            this.LotNum.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LotNum.Location = new System.Drawing.Point(271, 79);
            this.LotNum.Name = "LotNum";
            this.LotNum.Size = new System.Drawing.Size(100, 20);
            this.LotNum.TabIndex = 89;
            // 
            // Ontrak_SN
            // 
            this.Ontrak_SN.AutoSize = true;
            this.Ontrak_SN.Location = new System.Drawing.Point(12, 613);
            this.Ontrak_SN.Name = "Ontrak_SN";
            this.Ontrak_SN.Size = new System.Drawing.Size(60, 13);
            this.Ontrak_SN.TabIndex = 90;
            this.Ontrak_SN.Text = "Ontrak SN:";
            // 
            // Version_Number
            // 
            this.Version_Number.AutoSize = true;
            this.Version_Number.Location = new System.Drawing.Point(12, 9);
            this.Version_Number.Name = "Version_Number";
            this.Version_Number.Size = new System.Drawing.Size(35, 13);
            this.Version_Number.TabIndex = 93;
            this.Version_Number.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(596, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 94;
            this.label2.Text = "-";
            // 
            // fireworks
            // 
            this.fireworks.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fireworks.Image = global::Heater_NTC_Calibrator.Properties.Resources.fireworks_clipart_animated_12;
            this.fireworks.Location = new System.Drawing.Point(487, 148);
            this.fireworks.Name = "fireworks";
            this.fireworks.Size = new System.Drawing.Size(135, 192);
            this.fireworks.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fireworks.TabIndex = 92;
            this.fireworks.TabStop = false;
            // 
            // Kenny
            // 
            this.Kenny.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Kenny.Image = global::Heater_NTC_Calibrator.Properties.Resources._20130107_092218_542;
            this.Kenny.Location = new System.Drawing.Point(487, 148);
            this.Kenny.Name = "Kenny";
            this.Kenny.Size = new System.Drawing.Size(135, 192);
            this.Kenny.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Kenny.TabIndex = 91;
            this.Kenny.TabStop = false;
            // 
            // Calibration_PB
            // 
            this.Calibration_PB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Calibration_PB.Location = new System.Drawing.Point(77, 28);
            this.Calibration_PB.Name = "Calibration_PB";
            this.Calibration_PB.Size = new System.Drawing.Size(70, 40);
            this.Calibration_PB.TabIndex = 27;
            this.Calibration_PB.Text = "Calibration";
            this.Calibration_PB.UseVisualStyleBackColor = true;
            this.Calibration_PB.Click += new System.EventHandler(this.Calibration_PB_Click);
            // 
            // Heater_Calibrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(643, 635);
            this.Controls.Add(this.HTR1_Radio);
            this.Controls.Add(this.HTR16_Radio);
            this.Controls.Add(this.HTR15_Radio);
            this.Controls.Add(this.HTR14_Radio);
            this.Controls.Add(this.HTR13_Radio);
            this.Controls.Add(this.HTR12_Radio);
            this.Controls.Add(this.HTR11_Radio);
            this.Controls.Add(this.HTR10_Radio);
            this.Controls.Add(this.HTR9_Radio);
            this.Controls.Add(this.HTR8_Radio);
            this.Controls.Add(this.HTR7_Radio);
            this.Controls.Add(this.HTR6_Radio);
            this.Controls.Add(this.HTR5_Radio);
            this.Controls.Add(this.HTR3_Radio);
            this.Controls.Add(this.HTR4_Radio);
            this.Controls.Add(this.HTR2_Radio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Version_Number);
            this.Controls.Add(this.fireworks);
            this.Controls.Add(this.Kenny);
            this.Controls.Add(this.Ontrak_SN);
            this.Controls.Add(this.LotNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Print_PB);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.HTR_RESUTLS);
            this.Controls.Add(this.Calibration_PB);
            this.Controls.Add(this.Connect2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Heater_Calibrator";
            this.Text = "Heater Calibrator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Heater_Calibrator_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Heater_Calibrator_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.HTR_RESUTLS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fireworks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Kenny)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Connect2;
        private System.ComponentModel.BackgroundWorker Second_Worker;
        private System.Windows.Forms.ImageList Icons;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn TopHeater;
        private System.Windows.Forms.DataGridViewTextBoxColumn BottomHeater;
        private System.Windows.Forms.DataGridViewTextBoxColumn Top_Heater_Temp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bottom_Heater_Temp;
        private System.Windows.Forms.Label J100_Therm;
        private System.Windows.Forms.Label J101_Therm;
        private System.Windows.Forms.Label J135_Therm;
        private System.Windows.Forms.Label J134_Therm;
        private System.Windows.Forms.Label THERM_AVG;
        private System.Windows.Forms.DataGridView HTR_RESUTLS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton HTR1_Radio;
        private System.Windows.Forms.RadioButton HTR2_Radio;
        private System.Windows.Forms.RadioButton HTR4_Radio;
        private System.Windows.Forms.RadioButton HTR6_Radio;
        private System.Windows.Forms.RadioButton HTR5_Radio;
        private System.Windows.Forms.RadioButton HTR3_Radio;
        private System.Windows.Forms.RadioButton HTR9_Radio;
        private System.Windows.Forms.RadioButton HTR8_Radio;
        private System.Windows.Forms.RadioButton HTR7_Radio;
        private System.Windows.Forms.RadioButton HTR12_Radio;
        private System.Windows.Forms.RadioButton HTR11_Radio;
        private System.Windows.Forms.RadioButton HTR10_Radio;
        private System.Windows.Forms.RadioButton HTR16_Radio;
        private System.Windows.Forms.RadioButton HTR15_Radio;
        private System.Windows.Forms.RadioButton HTR14_Radio;
        private System.Windows.Forms.RadioButton HTR13_Radio;
        private System.Windows.Forms.Button Print_PB;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LotNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Heater_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn HTR_OFFSET;
        private System.Windows.Forms.DataGridViewTextBoxColumn HTR_VALUE;
        private System.Windows.Forms.Label Ontrak_SN;
        private System.Windows.Forms.PictureBox Kenny;
        private System.Windows.Forms.PictureBox fireworks;
        private System.Windows.Forms.Label Version_Number;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Calibration_PB;
    }
}

