namespace Measurement_Kits
{
	partial class Magnit
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
			this.panel3 = new System.Windows.Forms.Panel();
			this.checkBox_Lock_in_Multimeter = new System.Windows.Forms.CheckBox();
			this.button_SetMagne = new System.Windows.Forms.Button();
			this.textBox_SetMagne = new System.Windows.Forms.TextBox();
			this.button_Reset = new System.Windows.Forms.Button();
			this.checkBox_Hysteresis = new System.Windows.Forms.CheckBox();
			this.textBox_Mag_End = new System.Windows.Forms.TextBox();
			this.textBox_Mag_Delta = new System.Windows.Forms.TextBox();
			this.textBox_Mag_Start = new System.Windows.Forms.TextBox();
			this.checkBox_Wtite_time_in_file = new System.Windows.Forms.CheckBox();
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
			this.button_Menu = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button_Plot1Clear = new System.Windows.Forms.Button();
			this.label_Plot1_Coordinate = new System.Windows.Forms.Label();
			this.button_Plot1Scale = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.button_Plot2Clear = new System.Windows.Forms.Button();
			this.label_Plot2_Coordinate = new System.Windows.Forms.Label();
			this.button_Plot2Scale = new System.Windows.Forms.Button();
			this.button_SetFreq = new System.Windows.Forms.Button();
			this.textBox_SetFreq = new System.Windows.Forms.TextBox();
			this.checkBox_Set_Lock_Magnet = new System.Windows.Forms.CheckBox();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel3.Controls.Add(this.checkBox_Set_Lock_Magnet);
			this.panel3.Controls.Add(this.button_SetFreq);
			this.panel3.Controls.Add(this.textBox_SetFreq);
			this.panel3.Controls.Add(this.checkBox_Lock_in_Multimeter);
			this.panel3.Controls.Add(this.button_SetMagne);
			this.panel3.Controls.Add(this.textBox_SetMagne);
			this.panel3.Controls.Add(this.button_Reset);
			this.panel3.Controls.Add(this.checkBox_Hysteresis);
			this.panel3.Controls.Add(this.textBox_Mag_End);
			this.panel3.Controls.Add(this.textBox_Mag_Delta);
			this.panel3.Controls.Add(this.textBox_Mag_Start);
			this.panel3.Controls.Add(this.checkBox_Wtite_time_in_file);
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
			this.panel3.Location = new System.Drawing.Point(961, 3);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(238, 744);
			this.panel3.TabIndex = 4;
			// 
			// checkBox_Lock_in_Multimeter
			// 
			this.checkBox_Lock_in_Multimeter.AutoSize = true;
			this.checkBox_Lock_in_Multimeter.Location = new System.Drawing.Point(16, 125);
			this.checkBox_Lock_in_Multimeter.Name = "checkBox_Lock_in_Multimeter";
			this.checkBox_Lock_in_Multimeter.Size = new System.Drawing.Size(173, 17);
			this.checkBox_Lock_in_Multimeter.TabIndex = 26;
			this.checkBox_Lock_in_Multimeter.Text = "True Lock-in / False Multimeter";
			this.checkBox_Lock_in_Multimeter.UseVisualStyleBackColor = true;
			this.checkBox_Lock_in_Multimeter.CheckedChanged += new System.EventHandler(this.checkBox_Lock_in_Multimeter_CheckedChanged);
			// 
			// button_SetMagne
			// 
			this.button_SetMagne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button_SetMagne.Location = new System.Drawing.Point(60, 246);
			this.button_SetMagne.Name = "button_SetMagne";
			this.button_SetMagne.Size = new System.Drawing.Size(75, 23);
			this.button_SetMagne.TabIndex = 25;
			this.button_SetMagne.Text = "SendMagn";
			this.button_SetMagne.UseVisualStyleBackColor = true;
			this.button_SetMagne.Click += new System.EventHandler(this.button_SetMagne_Click);
			// 
			// textBox_SetMagne
			// 
			this.textBox_SetMagne.Location = new System.Drawing.Point(10, 246);
			this.textBox_SetMagne.Name = "textBox_SetMagne";
			this.textBox_SetMagne.Size = new System.Drawing.Size(45, 20);
			this.textBox_SetMagne.TabIndex = 24;
			this.textBox_SetMagne.Text = "-100";
			// 
			// button_Reset
			// 
			this.button_Reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Reset.Location = new System.Drawing.Point(73, 707);
			this.button_Reset.Name = "button_Reset";
			this.button_Reset.Size = new System.Drawing.Size(75, 23);
			this.button_Reset.TabIndex = 23;
			this.button_Reset.Text = "Reset";
			this.button_Reset.UseVisualStyleBackColor = true;
			this.button_Reset.Click += new System.EventHandler(this.button_Reset_Click);
			// 
			// checkBox_Hysteresis
			// 
			this.checkBox_Hysteresis.AutoSize = true;
			this.checkBox_Hysteresis.Location = new System.Drawing.Point(10, 221);
			this.checkBox_Hysteresis.Name = "checkBox_Hysteresis";
			this.checkBox_Hysteresis.Size = new System.Drawing.Size(74, 17);
			this.checkBox_Hysteresis.TabIndex = 22;
			this.checkBox_Hysteresis.Text = "Hysteresis";
			this.checkBox_Hysteresis.UseVisualStyleBackColor = true;
			// 
			// textBox_Mag_End
			// 
			this.textBox_Mag_End.Location = new System.Drawing.Point(112, 195);
			this.textBox_Mag_End.Name = "textBox_Mag_End";
			this.textBox_Mag_End.Size = new System.Drawing.Size(45, 20);
			this.textBox_Mag_End.TabIndex = 21;
			this.textBox_Mag_End.Text = "100";
			// 
			// textBox_Mag_Delta
			// 
			this.textBox_Mag_Delta.Location = new System.Drawing.Point(61, 195);
			this.textBox_Mag_Delta.Name = "textBox_Mag_Delta";
			this.textBox_Mag_Delta.Size = new System.Drawing.Size(45, 20);
			this.textBox_Mag_Delta.TabIndex = 20;
			this.textBox_Mag_Delta.Text = "0.1";
			// 
			// textBox_Mag_Start
			// 
			this.textBox_Mag_Start.Location = new System.Drawing.Point(10, 195);
			this.textBox_Mag_Start.Name = "textBox_Mag_Start";
			this.textBox_Mag_Start.Size = new System.Drawing.Size(45, 20);
			this.textBox_Mag_Start.TabIndex = 19;
			this.textBox_Mag_Start.Text = "-100";
			// 
			// checkBox_Wtite_time_in_file
			// 
			this.checkBox_Wtite_time_in_file.AutoSize = true;
			this.checkBox_Wtite_time_in_file.Location = new System.Drawing.Point(18, 381);
			this.checkBox_Wtite_time_in_file.Name = "checkBox_Wtite_time_in_file";
			this.checkBox_Wtite_time_in_file.Size = new System.Drawing.Size(100, 17);
			this.checkBox_Wtite_time_in_file.TabIndex = 17;
			this.checkBox_Wtite_time_in_file.Text = "Wtite time in file";
			this.checkBox_Wtite_time_in_file.UseVisualStyleBackColor = true;
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
			this.label_path.Location = new System.Drawing.Point(9, 179);
			this.label_path.Name = "label_path";
			this.label_path.Size = new System.Drawing.Size(54, 13);
			this.label_path.TabIndex = 6;
			this.label_path.Text = "C:\\Info.txt";
			this.label_path.Click += new System.EventHandler(this.label_path_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 82);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Magne";
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
            10000,
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
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Lock-In";
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
			this.panel1.Location = new System.Drawing.Point(10, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(945, 449);
			this.panel1.TabIndex = 5;
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
			this.panel2.Location = new System.Drawing.Point(10, 458);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(945, 301);
			this.panel2.TabIndex = 6;
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
			// button_SetFreq
			// 
			this.button_SetFreq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button_SetFreq.Location = new System.Drawing.Point(60, 286);
			this.button_SetFreq.Name = "button_SetFreq";
			this.button_SetFreq.Size = new System.Drawing.Size(75, 23);
			this.button_SetFreq.TabIndex = 28;
			this.button_SetFreq.Text = "SendFreq";
			this.button_SetFreq.UseVisualStyleBackColor = true;
			this.button_SetFreq.Click += new System.EventHandler(this.button_SetFreq_Click);
			// 
			// textBox_SetFreq
			// 
			this.textBox_SetFreq.Location = new System.Drawing.Point(10, 286);
			this.textBox_SetFreq.Name = "textBox_SetFreq";
			this.textBox_SetFreq.Size = new System.Drawing.Size(45, 20);
			this.textBox_SetFreq.TabIndex = 27;
			this.textBox_SetFreq.Text = "-100";
			// 
			// checkBox_Set_Lock_Magnet
			// 
			this.checkBox_Set_Lock_Magnet.AutoSize = true;
			this.checkBox_Set_Lock_Magnet.Location = new System.Drawing.Point(10, 329);
			this.checkBox_Set_Lock_Magnet.Name = "checkBox_Set_Lock_Magnet";
			this.checkBox_Set_Lock_Magnet.Size = new System.Drawing.Size(185, 17);
			this.checkBox_Set_Lock_Magnet.TabIndex = 29;
			this.checkBox_Set_Lock_Magnet.Text = "True Set Lock/ False Set Magnet";
			this.checkBox_Set_Lock_Magnet.UseVisualStyleBackColor = true;
			// 
			// Magnit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1201, 759);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel3);
			this.Name = "Magnit";
			this.Text = "Magnit";
			this.Load += new System.EventHandler(this.Magnit_Load);
			this.SizeChanged += new System.EventHandler(this.Magnit_SizeChanged);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.CheckBox checkBox_Wtite_time_in_file;
		private System.Windows.Forms.Label label_TempNow;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label_TempSpeed;
		private System.Windows.Forms.Label label_path;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Button button_ConnectToLakeShore;
		private System.Windows.Forms.Button button_ConnectToMultimetr;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button_Menu;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button_Plot1Clear;
		private System.Windows.Forms.Label label_Plot1_Coordinate;
		private System.Windows.Forms.Button button_Plot1Scale;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button button_Plot2Clear;
		private System.Windows.Forms.Label label_Plot2_Coordinate;
		private System.Windows.Forms.Button button_Plot2Scale;
		private System.Windows.Forms.TextBox textBox_Mag_End;
		private System.Windows.Forms.TextBox textBox_Mag_Delta;
		private System.Windows.Forms.TextBox textBox_Mag_Start;
		private System.Windows.Forms.CheckBox checkBox_Hysteresis;
		private System.Windows.Forms.Button button_Reset;
		private System.Windows.Forms.Button button_SetMagne;
		private System.Windows.Forms.TextBox textBox_SetMagne;
        private System.Windows.Forms.CheckBox checkBox_Lock_in_Multimeter;
		private System.Windows.Forms.Button button_SetFreq;
		private System.Windows.Forms.TextBox textBox_SetFreq;
		private System.Windows.Forms.CheckBox checkBox_Set_Lock_Magnet;
	}
}