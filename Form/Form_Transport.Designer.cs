
namespace Measurement_Kits
{
    partial class Form_Transport
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
			this.button_Menu = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button_Plot1Clear = new System.Windows.Forms.Button();
			this.label_Plot1_Coordinate = new System.Windows.Forms.Label();
			this.button_Plot1Scale = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.button_Plot2Clear = new System.Windows.Forms.Button();
			this.label_Plot2_Coordinate = new System.Windows.Forms.Label();
			this.button_Plot2Scale = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.checkBox_LockIn = new System.Windows.Forms.CheckBox();
			this.checkBox_Wtite_time_in_file = new System.Windows.Forms.CheckBox();
			this.checkBox_Get_Sensor = new System.Windows.Forms.CheckBox();
			this.checkBox_Get_K = new System.Windows.Forms.CheckBox();
			this.check_channel_B = new System.Windows.Forms.CheckBox();
			this.check_channel_A = new System.Windows.Forms.CheckBox();
			this.label_TempNow = new System.Windows.Forms.Label();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label_TempSpeed = new System.Windows.Forms.Label();
			this.label_path = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.button_ConnectToLakeShore = new System.Windows.Forms.Button();
			this.button_ConnectToMultimetr = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// button_Menu
			// 
			this.button_Menu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Menu.Location = new System.Drawing.Point(154, 9);
			this.button_Menu.Name = "button_Menu";
			this.button_Menu.Size = new System.Drawing.Size(75, 23);
			this.button_Menu.TabIndex = 0;
			this.button_Menu.Text = "Menu";
			this.button_Menu.UseVisualStyleBackColor = true;
			this.button_Menu.Click += new System.EventHandler(this.button_Menu_Click);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.button_Plot1Clear);
			this.panel1.Controls.Add(this.label_Plot1_Coordinate);
			this.panel1.Controls.Add(this.button_Plot1Scale);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(945, 528);
			this.panel1.TabIndex = 1;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// button_Plot1Clear
			// 
			this.button_Plot1Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Plot1Clear.Location = new System.Drawing.Point(857, 44);
			this.button_Plot1Clear.Name = "button_Plot1Clear";
			this.button_Plot1Clear.Size = new System.Drawing.Size(75, 23);
			this.button_Plot1Clear.TabIndex = 2;
			this.button_Plot1Clear.Text = "Clr";
			this.button_Plot1Clear.UseVisualStyleBackColor = true;
			this.button_Plot1Clear.Click += new System.EventHandler(this.button_Plot1Clear_Click);
			// 
			// label_Plot1_Coordinate
			// 
			this.label_Plot1_Coordinate.AutoSize = true;
			this.label_Plot1_Coordinate.Location = new System.Drawing.Point(87, 25);
			this.label_Plot1_Coordinate.Name = "label_Plot1_Coordinate";
			this.label_Plot1_Coordinate.Size = new System.Drawing.Size(35, 13);
			this.label_Plot1_Coordinate.TabIndex = 1;
			this.label_Plot1_Coordinate.Text = "label3";
			// 
			// button_Plot1Scale
			// 
			this.button_Plot1Scale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Plot1Scale.Location = new System.Drawing.Point(857, 15);
			this.button_Plot1Scale.Name = "button_Plot1Scale";
			this.button_Plot1Scale.Size = new System.Drawing.Size(75, 23);
			this.button_Plot1Scale.TabIndex = 0;
			this.button_Plot1Scale.Text = "Scale";
			this.button_Plot1Scale.UseVisualStyleBackColor = true;
			this.button_Plot1Scale.Click += new System.EventHandler(this.button_Plot1Scale_Click);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.Controls.Add(this.button_Plot2Clear);
			this.panel2.Controls.Add(this.label_Plot2_Coordinate);
			this.panel2.Controls.Add(this.button_Plot2Scale);
			this.panel2.Location = new System.Drawing.Point(0, 534);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(945, 222);
			this.panel2.TabIndex = 2;
			// 
			// button_Plot2Clear
			// 
			this.button_Plot2Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Plot2Clear.Location = new System.Drawing.Point(857, 44);
			this.button_Plot2Clear.Name = "button_Plot2Clear";
			this.button_Plot2Clear.Size = new System.Drawing.Size(75, 23);
			this.button_Plot2Clear.TabIndex = 3;
			this.button_Plot2Clear.Text = "Clr";
			this.button_Plot2Clear.UseVisualStyleBackColor = true;
			this.button_Plot2Clear.Click += new System.EventHandler(this.button_Plot2Clear_Click);
			// 
			// label_Plot2_Coordinate
			// 
			this.label_Plot2_Coordinate.AutoSize = true;
			this.label_Plot2_Coordinate.Location = new System.Drawing.Point(87, 25);
			this.label_Plot2_Coordinate.Name = "label_Plot2_Coordinate";
			this.label_Plot2_Coordinate.Size = new System.Drawing.Size(35, 13);
			this.label_Plot2_Coordinate.TabIndex = 2;
			this.label_Plot2_Coordinate.Text = "label4";
			// 
			// button_Plot2Scale
			// 
			this.button_Plot2Scale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Plot2Scale.Location = new System.Drawing.Point(857, 15);
			this.button_Plot2Scale.Name = "button_Plot2Scale";
			this.button_Plot2Scale.Size = new System.Drawing.Size(75, 23);
			this.button_Plot2Scale.TabIndex = 1;
			this.button_Plot2Scale.Text = "Scale";
			this.button_Plot2Scale.UseVisualStyleBackColor = true;
			this.button_Plot2Scale.Click += new System.EventHandler(this.button_Plot2Scale_Click);
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel3.Controls.Add(this.checkBox_LockIn);
			this.panel3.Controls.Add(this.checkBox_Wtite_time_in_file);
			this.panel3.Controls.Add(this.checkBox_Get_Sensor);
			this.panel3.Controls.Add(this.checkBox_Get_K);
			this.panel3.Controls.Add(this.check_channel_B);
			this.panel3.Controls.Add(this.check_channel_A);
			this.panel3.Controls.Add(this.label_TempNow);
			this.panel3.Controls.Add(this.comboBox2);
			this.panel3.Controls.Add(this.comboBox1);
			this.panel3.Controls.Add(this.label_TempSpeed);
			this.panel3.Controls.Add(this.label_path);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Controls.Add(this.button3);
			this.panel3.Controls.Add(this.numericUpDown1);
			this.panel3.Controls.Add(this.button_ConnectToLakeShore);
			this.panel3.Controls.Add(this.button_ConnectToMultimetr);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Controls.Add(this.button_Menu);
			this.panel3.Location = new System.Drawing.Point(960, 3);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(238, 744);
			this.panel3.TabIndex = 3;
			// 
			// checkBox_LockIn
			// 
			this.checkBox_LockIn.AutoSize = true;
			this.checkBox_LockIn.Location = new System.Drawing.Point(16, 176);
			this.checkBox_LockIn.Name = "checkBox_LockIn";
			this.checkBox_LockIn.Size = new System.Drawing.Size(62, 17);
			this.checkBox_LockIn.TabIndex = 18;
			this.checkBox_LockIn.Text = "Lock-In";
			this.checkBox_LockIn.UseVisualStyleBackColor = true;
			this.checkBox_LockIn.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// checkBox_Wtite_time_in_file
			// 
			this.checkBox_Wtite_time_in_file.AutoSize = true;
			this.checkBox_Wtite_time_in_file.Location = new System.Drawing.Point(16, 289);
			this.checkBox_Wtite_time_in_file.Name = "checkBox_Wtite_time_in_file";
			this.checkBox_Wtite_time_in_file.Size = new System.Drawing.Size(100, 17);
			this.checkBox_Wtite_time_in_file.TabIndex = 17;
			this.checkBox_Wtite_time_in_file.Text = "Wtite time in file";
			this.checkBox_Wtite_time_in_file.UseVisualStyleBackColor = true;
			// 
			// checkBox_Get_Sensor
			// 
			this.checkBox_Get_Sensor.AutoSize = true;
			this.checkBox_Get_Sensor.Location = new System.Drawing.Point(16, 266);
			this.checkBox_Get_Sensor.Name = "checkBox_Get_Sensor";
			this.checkBox_Get_Sensor.Size = new System.Drawing.Size(79, 17);
			this.checkBox_Get_Sensor.TabIndex = 16;
			this.checkBox_Get_Sensor.Text = "Get Sensor";
			this.checkBox_Get_Sensor.UseVisualStyleBackColor = true;
			this.checkBox_Get_Sensor.CheckedChanged += new System.EventHandler(this.checkBox_Get_Sensor_CheckedChanged);
			// 
			// checkBox_Get_K
			// 
			this.checkBox_Get_K.AutoSize = true;
			this.checkBox_Get_K.Location = new System.Drawing.Point(16, 243);
			this.checkBox_Get_K.Name = "checkBox_Get_K";
			this.checkBox_Get_K.Size = new System.Drawing.Size(75, 17);
			this.checkBox_Get_K.TabIndex = 15;
			this.checkBox_Get_K.Text = "Get Kelvin";
			this.checkBox_Get_K.UseVisualStyleBackColor = true;
			this.checkBox_Get_K.CheckedChanged += new System.EventHandler(this.checkBox_Get_K_CheckedChanged);
			// 
			// check_channel_B
			// 
			this.check_channel_B.AutoSize = true;
			this.check_channel_B.Location = new System.Drawing.Point(16, 220);
			this.check_channel_B.Name = "check_channel_B";
			this.check_channel_B.Size = new System.Drawing.Size(75, 17);
			this.check_channel_B.TabIndex = 14;
			this.check_channel_B.Text = "Channel B";
			this.check_channel_B.UseVisualStyleBackColor = true;
			this.check_channel_B.CheckedChanged += new System.EventHandler(this.check_channel_B_CheckedChanged);
			// 
			// check_channel_A
			// 
			this.check_channel_A.AutoSize = true;
			this.check_channel_A.Location = new System.Drawing.Point(16, 197);
			this.check_channel_A.Name = "check_channel_A";
			this.check_channel_A.Size = new System.Drawing.Size(75, 17);
			this.check_channel_A.TabIndex = 13;
			this.check_channel_A.Text = "Channel A";
			this.check_channel_A.UseVisualStyleBackColor = true;
			this.check_channel_A.CheckedChanged += new System.EventHandler(this.check_channel_A_CheckedChanged);
			// 
			// label_TempNow
			// 
			this.label_TempNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_TempNow.AutoSize = true;
			this.label_TempNow.Location = new System.Drawing.Point(15, 687);
			this.label_TempNow.Name = "label_TempNow";
			this.label_TempNow.Size = new System.Drawing.Size(35, 13);
			this.label_TempNow.TabIndex = 11;
			this.label_TempNow.Text = "label4";
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(16, 98);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(121, 21);
			this.comboBox2.TabIndex = 9;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(16, 55);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 8;
			// 
			// label_TempSpeed
			// 
			this.label_TempSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_TempSpeed.AutoSize = true;
			this.label_TempSpeed.Location = new System.Drawing.Point(14, 712);
			this.label_TempSpeed.Name = "label_TempSpeed";
			this.label_TempSpeed.Size = new System.Drawing.Size(35, 13);
			this.label_TempSpeed.TabIndex = 7;
			this.label_TempSpeed.Text = "label4";
			// 
			// label_path
			// 
			this.label_path.AutoSize = true;
			this.label_path.Location = new System.Drawing.Point(14, 160);
			this.label_path.Name = "label_path";
			this.label_path.Size = new System.Drawing.Size(54, 13);
			this.label_path.TabIndex = 6;
			this.label_path.Text = "C:\\Info.txt";
			this.label_path.Click += new System.EventHandler(this.label_path_Click_1);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 82);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "LakeShore";
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.Location = new System.Drawing.Point(154, 707);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 4;
			this.button3.Text = "Start";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.numericUpDown1.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.numericUpDown1.Location = new System.Drawing.Point(17, 647);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
			this.numericUpDown1.TabIndex = 0;
			this.numericUpDown1.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
			// 
			// button_ConnectToLakeShore
			// 
			this.button_ConnectToLakeShore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.button_ConnectToLakeShore.Location = new System.Drawing.Point(154, 96);
			this.button_ConnectToLakeShore.Name = "button_ConnectToLakeShore";
			this.button_ConnectToLakeShore.Size = new System.Drawing.Size(24, 23);
			this.button_ConnectToLakeShore.TabIndex = 3;
			this.button_ConnectToLakeShore.UseVisualStyleBackColor = false;
			this.button_ConnectToLakeShore.Click += new System.EventHandler(this.button_ConnectToLakeShore_Click);
			// 
			// button_ConnectToMultimetr
			// 
			this.button_ConnectToMultimetr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.button_ConnectToMultimetr.Location = new System.Drawing.Point(154, 53);
			this.button_ConnectToMultimetr.Name = "button_ConnectToMultimetr";
			this.button_ConnectToMultimetr.Size = new System.Drawing.Size(24, 23);
			this.button_ConnectToMultimetr.TabIndex = 2;
			this.button_ConnectToMultimetr.UseVisualStyleBackColor = false;
			this.button_ConnectToMultimetr.Click += new System.EventHandler(this.button_ConnectToMultimetr_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 39);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Multimetr";
			// 
			// Form_Transport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1201, 759);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "Form_Transport";
			this.Text = "Transport";
			this.Load += new System.EventHandler(this.Transport_Load);
			this.SizeChanged += new System.EventHandler(this.Form_Transport_SizeChanged);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Menu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button_ConnectToLakeShore;
        private System.Windows.Forms.Button button_ConnectToMultimetr;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label_TempSpeed;
        private System.Windows.Forms.Label label_path;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button_Plot1Scale;
        private System.Windows.Forms.Button button_Plot2Scale;
        private System.Windows.Forms.Label label_Plot1_Coordinate;
        private System.Windows.Forms.Label label_Plot2_Coordinate;
        private System.Windows.Forms.Label label_TempNow;
        private System.Windows.Forms.CheckBox checkBox_Wtite_time_in_file;
        private System.Windows.Forms.CheckBox checkBox_Get_Sensor;
        private System.Windows.Forms.CheckBox checkBox_Get_K;
        private System.Windows.Forms.CheckBox check_channel_B;
        private System.Windows.Forms.CheckBox check_channel_A;
        private System.Windows.Forms.Button button_Plot1Clear;
        private System.Windows.Forms.Button button_Plot2Clear;
        private System.Windows.Forms.CheckBox checkBox_LockIn;
    }
}