
namespace Camera_Calibration_test
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
            this.toolStripStatusLabel = new System.Windows.Forms.Label();
            this.BtnRunCalibration = new System.Windows.Forms.Button();
            this.buttonStartCal = new System.Windows.Forms.Button();
            this.pictureBoxFoundCorners = new System.Windows.Forms.PictureBox();
            this.pictureBoxUndistorted = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBoxShowPreFilter = new System.Windows.Forms.CheckBox();
            this.buttonSaveCalVals = new System.Windows.Forms.Button();
            this.buttonLoadCalVals = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoundCorners)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUndistorted)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxFoundCorners, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxUndistorted, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonLoadCalVals);
            this.panel1.Controls.Add(this.buttonSaveCalVals);
            this.panel1.Controls.Add(this.toolStripStatusLabel);
            this.panel1.Controls.Add(this.BtnRunCalibration);
            this.panel1.Controls.Add(this.buttonStartCal);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 114);
            this.panel1.TabIndex = 0;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.AutoSize = true;
            this.toolStripStatusLabel.Location = new System.Drawing.Point(270, 18);
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(35, 13);
            this.toolStripStatusLabel.TabIndex = 2;
            this.toolStripStatusLabel.Text = "label1";
            // 
            // BtnRunCalibration
            // 
            this.BtnRunCalibration.Location = new System.Drawing.Point(143, 38);
            this.BtnRunCalibration.Name = "BtnRunCalibration";
            this.BtnRunCalibration.Size = new System.Drawing.Size(94, 23);
            this.BtnRunCalibration.TabIndex = 1;
            this.BtnRunCalibration.Text = "Run Calibration";
            this.BtnRunCalibration.UseVisualStyleBackColor = true;
            this.BtnRunCalibration.Click += new System.EventHandler(this.BtnRunCalibration_Click);
            // 
            // buttonStartCal
            // 
            this.buttonStartCal.Location = new System.Drawing.Point(143, 9);
            this.buttonStartCal.Name = "buttonStartCal";
            this.buttonStartCal.Size = new System.Drawing.Size(94, 23);
            this.buttonStartCal.TabIndex = 0;
            this.buttonStartCal.Text = "Start Calibration";
            this.buttonStartCal.UseVisualStyleBackColor = true;
            this.buttonStartCal.Click += new System.EventHandler(this.buttonStartCal_Click);
            // 
            // pictureBoxFoundCorners
            // 
            this.pictureBoxFoundCorners.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxFoundCorners.Location = new System.Drawing.Point(3, 123);
            this.pictureBoxFoundCorners.Name = "pictureBoxFoundCorners";
            this.pictureBoxFoundCorners.Size = new System.Drawing.Size(394, 324);
            this.pictureBoxFoundCorners.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFoundCorners.TabIndex = 1;
            this.pictureBoxFoundCorners.TabStop = false;
            // 
            // pictureBoxUndistorted
            // 
            this.pictureBoxUndistorted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxUndistorted.Location = new System.Drawing.Point(403, 123);
            this.pictureBoxUndistorted.Name = "pictureBoxUndistorted";
            this.pictureBoxUndistorted.Size = new System.Drawing.Size(394, 324);
            this.pictureBoxUndistorted.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxUndistorted.TabIndex = 2;
            this.pictureBoxUndistorted.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBoxShowPreFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(403, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(394, 114);
            this.panel2.TabIndex = 3;
            // 
            // checkBoxShowPreFilter
            // 
            this.checkBoxShowPreFilter.AutoSize = true;
            this.checkBoxShowPreFilter.Location = new System.Drawing.Point(157, 94);
            this.checkBoxShowPreFilter.Name = "checkBoxShowPreFilter";
            this.checkBoxShowPreFilter.Size = new System.Drawing.Size(97, 17);
            this.checkBoxShowPreFilter.TabIndex = 0;
            this.checkBoxShowPreFilter.Text = "Show Pre Filter";
            this.checkBoxShowPreFilter.UseVisualStyleBackColor = true;
            this.checkBoxShowPreFilter.CheckStateChanged += new System.EventHandler(this.checkBoxShowPreFilter_CheckStateChanged);
            // 
            // buttonSaveCalVals
            // 
            this.buttonSaveCalVals.Location = new System.Drawing.Point(143, 67);
            this.buttonSaveCalVals.Name = "buttonSaveCalVals";
            this.buttonSaveCalVals.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonSaveCalVals.Size = new System.Drawing.Size(94, 23);
            this.buttonSaveCalVals.TabIndex = 3;
            this.buttonSaveCalVals.Text = "Save Calibration";
            this.buttonSaveCalVals.UseVisualStyleBackColor = true;
            this.buttonSaveCalVals.Click += new System.EventHandler(this.buttonSaveCalVals_Click);
            // 
            // buttonLoadCalVals
            // 
            this.buttonLoadCalVals.Location = new System.Drawing.Point(243, 67);
            this.buttonLoadCalVals.Name = "buttonLoadCalVals";
            this.buttonLoadCalVals.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonLoadCalVals.Size = new System.Drawing.Size(118, 23);
            this.buttonLoadCalVals.TabIndex = 4;
            this.buttonLoadCalVals.Text = "Load Calibration Vals";
            this.buttonLoadCalVals.UseVisualStyleBackColor = true;
            this.buttonLoadCalVals.Click += new System.EventHandler(this.buttonLoadCalVals_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoundCorners)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUndistorted)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonStartCal;
        private System.Windows.Forms.PictureBox pictureBoxFoundCorners;
        private System.Windows.Forms.PictureBox pictureBoxUndistorted;
        private System.Windows.Forms.Button BtnRunCalibration;
        private System.Windows.Forms.Label toolStripStatusLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBoxShowPreFilter;
        private System.Windows.Forms.Button buttonLoadCalVals;
        private System.Windows.Forms.Button buttonSaveCalVals;
    }
}

