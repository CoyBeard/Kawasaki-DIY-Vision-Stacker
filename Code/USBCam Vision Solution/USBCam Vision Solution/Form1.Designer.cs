
namespace USBCam_Vision_Solution
{
    partial class Form1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PbCamSnip = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PbBinaryThresh = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxCamCalMode = new System.Windows.Forms.CheckBox();
            this.checkBoxLoadUndistortPeram = new System.Windows.Forms.CheckBox();
            this.BtnCamStop = new System.Windows.Forms.Button();
            this.BtnCamStart = new System.Windows.Forms.Button();
            this.CbCameraSelect = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblContrastValue = new System.Windows.Forms.Label();
            this.lblBrightnessValue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBarBrightness = new System.Windows.Forms.TrackBar();
            this.trackBarContrast = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBoxMaxLength = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxMinLength = new System.Windows.Forms.TextBox();
            this.labelBinaryThresh = new System.Windows.Forms.Label();
            this.labelAngleThresh = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trackBarAngleThresh = new System.Windows.Forms.TrackBar();
            this.trackBarBinaryThresh = new System.Windows.Forms.TrackBar();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.checkBoxSendPickPos = new System.Windows.Forms.CheckBox();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.buttonCOMManSend = new System.Windows.Forms.Button();
            this.textBoxCOMUserInput = new System.Windows.Forms.TextBox();
            this.buttonCOMConnect = new System.Windows.Forms.Button();
            this.comboBoxCOMPorts = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectCamCalibrationFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbCamSnip)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbBinaryThresh)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarContrast)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleThresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBinaryThresh)).BeginInit();
            this.panel4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1182, 644);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PbCamSnip);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 153);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(703, 488);
            this.panel1.TabIndex = 0;
            // 
            // PbCamSnip
            // 
            this.PbCamSnip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PbCamSnip.Location = new System.Drawing.Point(0, 0);
            this.PbCamSnip.Name = "PbCamSnip";
            this.PbCamSnip.Size = new System.Drawing.Size(703, 488);
            this.PbCamSnip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbCamSnip.TabIndex = 0;
            this.PbCamSnip.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(712, 153);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(467, 488);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PbBinaryThresh);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 385);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Binary Threshold";
            // 
            // PbBinaryThresh
            // 
            this.PbBinaryThresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PbBinaryThresh.Location = new System.Drawing.Point(3, 16);
            this.PbBinaryThresh.Name = "PbBinaryThresh";
            this.PbBinaryThresh.Size = new System.Drawing.Size(455, 366);
            this.PbBinaryThresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbBinaryThresh.TabIndex = 0;
            this.PbBinaryThresh.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxCamCalMode);
            this.groupBox2.Controls.Add(this.checkBoxLoadUndistortPeram);
            this.groupBox2.Controls.Add(this.BtnCamStop);
            this.groupBox2.Controls.Add(this.BtnCamStart);
            this.groupBox2.Controls.Add(this.CbCameraSelect);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(461, 91);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Camera";
            // 
            // checkBoxCamCalMode
            // 
            this.checkBoxCamCalMode.AutoSize = true;
            this.checkBoxCamCalMode.Location = new System.Drawing.Point(200, 53);
            this.checkBoxCamCalMode.Name = "checkBoxCamCalMode";
            this.checkBoxCamCalMode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxCamCalMode.Size = new System.Drawing.Size(144, 17);
            this.checkBoxCamCalMode.TabIndex = 5;
            this.checkBoxCamCalMode.Text = "Camera Calibration Mode";
            this.checkBoxCamCalMode.UseVisualStyleBackColor = true;
            // 
            // checkBoxLoadUndistortPeram
            // 
            this.checkBoxLoadUndistortPeram.AutoSize = true;
            this.checkBoxLoadUndistortPeram.Location = new System.Drawing.Point(200, 22);
            this.checkBoxLoadUndistortPeram.Name = "checkBoxLoadUndistortPeram";
            this.checkBoxLoadUndistortPeram.Size = new System.Drawing.Size(151, 17);
            this.checkBoxLoadUndistortPeram.TabIndex = 4;
            this.checkBoxLoadUndistortPeram.Text = "Load Undistort Perameters";
            this.checkBoxLoadUndistortPeram.UseVisualStyleBackColor = true;
            this.checkBoxLoadUndistortPeram.CheckedChanged += new System.EventHandler(this.checkBoxLoadUndistortPeram_CheckedChanged);
            // 
            // BtnCamStop
            // 
            this.BtnCamStop.Location = new System.Drawing.Point(103, 48);
            this.BtnCamStop.Name = "BtnCamStop";
            this.BtnCamStop.Size = new System.Drawing.Size(91, 23);
            this.BtnCamStop.TabIndex = 2;
            this.BtnCamStop.Text = "Stop Camera";
            this.BtnCamStop.UseVisualStyleBackColor = true;
            this.BtnCamStop.Click += new System.EventHandler(this.BtnCamStop_Click);
            // 
            // BtnCamStart
            // 
            this.BtnCamStart.Location = new System.Drawing.Point(7, 48);
            this.BtnCamStart.Name = "BtnCamStart";
            this.BtnCamStart.Size = new System.Drawing.Size(91, 23);
            this.BtnCamStart.TabIndex = 1;
            this.BtnCamStart.Text = "Start Camera";
            this.BtnCamStart.UseVisualStyleBackColor = true;
            this.BtnCamStart.Click += new System.EventHandler(this.BtnCamStart_Click);
            // 
            // CbCameraSelect
            // 
            this.CbCameraSelect.FormattingEnabled = true;
            this.CbCameraSelect.Location = new System.Drawing.Point(7, 20);
            this.CbCameraSelect.Name = "CbCameraSelect";
            this.CbCameraSelect.Size = new System.Drawing.Size(187, 21);
            this.CbCameraSelect.TabIndex = 0;
            this.CbCameraSelect.Text = "Select Camera";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel3.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox3, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(703, 144);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblContrastValue);
            this.panel3.Controls.Add(this.lblBrightnessValue);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.trackBarBrightness);
            this.panel3.Controls.Add(this.trackBarContrast);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(310, 138);
            this.panel3.TabIndex = 0;
            // 
            // lblContrastValue
            // 
            this.lblContrastValue.Location = new System.Drawing.Point(160, 123);
            this.lblContrastValue.Name = "lblContrastValue";
            this.lblContrastValue.Size = new System.Drawing.Size(35, 13);
            this.lblContrastValue.TabIndex = 7;
            this.lblContrastValue.Text = "100";
            // 
            // lblBrightnessValue
            // 
            this.lblBrightnessValue.Location = new System.Drawing.Point(160, 81);
            this.lblBrightnessValue.Name = "lblBrightnessValue";
            this.lblBrightnessValue.Size = new System.Drawing.Size(35, 13);
            this.lblBrightnessValue.TabIndex = 6;
            this.lblBrightnessValue.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Contrast";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Brightness";
            // 
            // trackBarBrightness
            // 
            this.trackBarBrightness.Location = new System.Drawing.Point(60, 49);
            this.trackBarBrightness.Maximum = 250;
            this.trackBarBrightness.Minimum = -250;
            this.trackBarBrightness.Name = "trackBarBrightness";
            this.trackBarBrightness.Size = new System.Drawing.Size(215, 45);
            this.trackBarBrightness.TabIndex = 1;
            this.trackBarBrightness.Value = -13;
            this.trackBarBrightness.Scroll += new System.EventHandler(this.trackBarBrightness_Scroll);
            // 
            // trackBarContrast
            // 
            this.trackBarContrast.Location = new System.Drawing.Point(60, 91);
            this.trackBarContrast.Maximum = 500;
            this.trackBarContrast.Name = "trackBarContrast";
            this.trackBarContrast.Size = new System.Drawing.Size(215, 45);
            this.trackBarContrast.TabIndex = 0;
            this.trackBarContrast.Value = 141;
            this.trackBarContrast.Scroll += new System.EventHandler(this.trackBarContrast_Scroll);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.labelBinaryThresh);
            this.groupBox3.Controls.Add(this.labelAngleThresh);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.trackBarAngleThresh);
            this.groupBox3.Controls.Add(this.trackBarBinaryThresh);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(319, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(381, 138);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Find Contures";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBoxMaxLength);
            this.groupBox5.Location = new System.Drawing.Point(276, 93);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(105, 45);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Max Length";
            // 
            // textBoxMaxLength
            // 
            this.textBoxMaxLength.Location = new System.Drawing.Point(7, 20);
            this.textBoxMaxLength.Name = "textBoxMaxLength";
            this.textBoxMaxLength.Size = new System.Drawing.Size(92, 20);
            this.textBoxMaxLength.TabIndex = 0;
            this.textBoxMaxLength.Text = "600";
            this.textBoxMaxLength.TextChanged += new System.EventHandler(this.textBoxMaxLength_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxMinLength);
            this.groupBox4.Location = new System.Drawing.Point(276, 49);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(105, 45);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Min Length";
            // 
            // textBoxMinLength
            // 
            this.textBoxMinLength.Location = new System.Drawing.Point(7, 20);
            this.textBoxMinLength.Name = "textBoxMinLength";
            this.textBoxMinLength.Size = new System.Drawing.Size(92, 20);
            this.textBoxMinLength.TabIndex = 0;
            this.textBoxMinLength.Text = "200";
            this.textBoxMinLength.TextChanged += new System.EventHandler(this.textBoxMinLength_TextChanged);
            // 
            // labelBinaryThresh
            // 
            this.labelBinaryThresh.Location = new System.Drawing.Point(155, 123);
            this.labelBinaryThresh.Name = "labelBinaryThresh";
            this.labelBinaryThresh.Size = new System.Drawing.Size(35, 13);
            this.labelBinaryThresh.TabIndex = 13;
            this.labelBinaryThresh.Text = "100";
            // 
            // labelAngleThresh
            // 
            this.labelAngleThresh.Location = new System.Drawing.Point(155, 81);
            this.labelAngleThresh.Name = "labelAngleThresh";
            this.labelAngleThresh.Size = new System.Drawing.Size(35, 13);
            this.labelAngleThresh.TabIndex = 12;
            this.labelAngleThresh.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "BinaryThresh";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "AngleThresh";
            // 
            // trackBarAngleThresh
            // 
            this.trackBarAngleThresh.Location = new System.Drawing.Point(55, 49);
            this.trackBarAngleThresh.Maximum = 90;
            this.trackBarAngleThresh.Name = "trackBarAngleThresh";
            this.trackBarAngleThresh.Size = new System.Drawing.Size(215, 45);
            this.trackBarAngleThresh.TabIndex = 9;
            this.trackBarAngleThresh.Value = 10;
            this.trackBarAngleThresh.Scroll += new System.EventHandler(this.trackBarAngleThresh_Scroll);
            // 
            // trackBarBinaryThresh
            // 
            this.trackBarBinaryThresh.Location = new System.Drawing.Point(55, 91);
            this.trackBarBinaryThresh.Maximum = 255;
            this.trackBarBinaryThresh.Name = "trackBarBinaryThresh";
            this.trackBarBinaryThresh.Size = new System.Drawing.Size(215, 45);
            this.trackBarBinaryThresh.TabIndex = 8;
            this.trackBarBinaryThresh.Value = 119;
            this.trackBarBinaryThresh.Scroll += new System.EventHandler(this.trackBarBinaryThresh_Scroll);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(712, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(467, 144);
            this.panel4.TabIndex = 3;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.checkBoxSendPickPos);
            this.groupBox6.Controls.Add(this.comboBoxBaudRate);
            this.groupBox6.Controls.Add(this.buttonCOMManSend);
            this.groupBox6.Controls.Add(this.textBoxCOMUserInput);
            this.groupBox6.Controls.Add(this.buttonCOMConnect);
            this.groupBox6.Controls.Add(this.comboBoxCOMPorts);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(467, 144);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "COM Connect";
            // 
            // checkBoxSendPickPos
            // 
            this.checkBoxSendPickPos.AutoSize = true;
            this.checkBoxSendPickPos.Location = new System.Drawing.Point(10, 75);
            this.checkBoxSendPickPos.Name = "checkBoxSendPickPos";
            this.checkBoxSendPickPos.Size = new System.Drawing.Size(120, 17);
            this.checkBoxSendPickPos.TabIndex = 6;
            this.checkBoxSendPickPos.Text = "Send Pick Positions";
            this.checkBoxSendPickPos.UseVisualStyleBackColor = true;
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Location = new System.Drawing.Point(10, 47);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBaudRate.TabIndex = 4;
            // 
            // buttonCOMManSend
            // 
            this.buttonCOMManSend.Location = new System.Drawing.Point(363, 115);
            this.buttonCOMManSend.Name = "buttonCOMManSend";
            this.buttonCOMManSend.Size = new System.Drawing.Size(98, 20);
            this.buttonCOMManSend.TabIndex = 3;
            this.buttonCOMManSend.Text = "Manual Send";
            this.buttonCOMManSend.UseVisualStyleBackColor = true;
            this.buttonCOMManSend.Click += new System.EventHandler(this.buttonCOMManSend_Click);
            // 
            // textBoxCOMUserInput
            // 
            this.textBoxCOMUserInput.Location = new System.Drawing.Point(10, 115);
            this.textBoxCOMUserInput.Name = "textBoxCOMUserInput";
            this.textBoxCOMUserInput.Size = new System.Drawing.Size(346, 20);
            this.textBoxCOMUserInput.TabIndex = 2;
            // 
            // buttonCOMConnect
            // 
            this.buttonCOMConnect.Location = new System.Drawing.Point(138, 19);
            this.buttonCOMConnect.Name = "buttonCOMConnect";
            this.buttonCOMConnect.Size = new System.Drawing.Size(75, 21);
            this.buttonCOMConnect.TabIndex = 1;
            this.buttonCOMConnect.Text = "Connect";
            this.buttonCOMConnect.UseVisualStyleBackColor = true;
            this.buttonCOMConnect.Click += new System.EventHandler(this.buttonCOMConnect_Click);
            // 
            // comboBoxCOMPorts
            // 
            this.comboBoxCOMPorts.FormattingEnabled = true;
            this.comboBoxCOMPorts.Location = new System.Drawing.Point(10, 19);
            this.comboBoxCOMPorts.Name = "comboBoxCOMPorts";
            this.comboBoxCOMPorts.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCOMPorts.TabIndex = 0;
            this.comboBoxCOMPorts.Text = "Select COM";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1182, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectCamCalibrationFilePathToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // selectCamCalibrationFilePathToolStripMenuItem
            // 
            this.selectCamCalibrationFilePathToolStripMenuItem.Name = "selectCamCalibrationFilePathToolStripMenuItem";
            this.selectCamCalibrationFilePathToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.selectCamCalibrationFilePathToolStripMenuItem.Text = "Select Cam Calibration FilePath";
            this.selectCamCalibrationFilePathToolStripMenuItem.Click += new System.EventHandler(this.selectCamCalibrationFilePathToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 668);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "USB Vision System (Stacker)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbCamSnip)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbBinaryThresh)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarContrast)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngleThresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBinaryThresh)).EndInit();
            this.panel4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox PbCamSnip;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox PbBinaryThresh;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnCamStart;
        private System.Windows.Forms.ComboBox CbCameraSelect;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Button BtnCamStop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblContrastValue;
        private System.Windows.Forms.Label lblBrightnessValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBarBrightness;
        private System.Windows.Forms.TrackBar trackBarContrast;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBoxMaxLength;
        private System.Windows.Forms.TextBox textBoxMinLength;
        private System.Windows.Forms.Label labelBinaryThresh;
        private System.Windows.Forms.Label labelAngleThresh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trackBarAngleThresh;
        private System.Windows.Forms.TrackBar trackBarBinaryThresh;
        private System.Windows.Forms.CheckBox checkBoxLoadUndistortPeram;
        private System.Windows.Forms.ToolStripMenuItem selectCamCalibrationFilePathToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxCamCalMode;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.Button buttonCOMManSend;
        private System.Windows.Forms.TextBox textBoxCOMUserInput;
        private System.Windows.Forms.Button buttonCOMConnect;
        private System.Windows.Forms.ComboBox comboBoxCOMPorts;
        private System.Windows.Forms.CheckBox checkBoxSendPickPos;
    }
}

