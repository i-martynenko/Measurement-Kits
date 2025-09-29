
namespace Measurement_Kits
{
    partial class Form_Test_RS232
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
            this.textBox_Respond = new System.Windows.Forms.TextBox();
            this.richTextBox_Out = new System.Windows.Forms.RichTextBox();
            this.button_SendCommand = new System.Windows.Forms.Button();
            this.button_Menu = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_ConnectToLakeShore = new System.Windows.Forms.Button();
            this.button_ConnectToMultimetr = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button_LoopSendCommand = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button_Clr = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Respond
            // 
            this.textBox_Respond.Location = new System.Drawing.Point(56, 67);
            this.textBox_Respond.Name = "textBox_Respond";
            this.textBox_Respond.Size = new System.Drawing.Size(182, 20);
            this.textBox_Respond.TabIndex = 0;
            // 
            // richTextBox_Out
            // 
            this.richTextBox_Out.Location = new System.Drawing.Point(40, 104);
            this.richTextBox_Out.Name = "richTextBox_Out";
            this.richTextBox_Out.Size = new System.Drawing.Size(395, 334);
            this.richTextBox_Out.TabIndex = 1;
            this.richTextBox_Out.Text = "";
            // 
            // button_SendCommand
            // 
            this.button_SendCommand.Location = new System.Drawing.Point(244, 43);
            this.button_SendCommand.Name = "button_SendCommand";
            this.button_SendCommand.Size = new System.Drawing.Size(163, 44);
            this.button_SendCommand.TabIndex = 2;
            this.button_SendCommand.Text = "Send Command";
            this.button_SendCommand.UseVisualStyleBackColor = true;
            this.button_SendCommand.Click += new System.EventHandler(this.button_SendCommand_Click);
            // 
            // button_Menu
            // 
            this.button_Menu.Location = new System.Drawing.Point(499, 12);
            this.button_Menu.Name = "button_Menu";
            this.button_Menu.Size = new System.Drawing.Size(112, 43);
            this.button_Menu.TabIndex = 3;
            this.button_Menu.Text = "Menu";
            this.button_Menu.UseVisualStyleBackColor = true;
            this.button_Menu.Click += new System.EventHandler(this.button_Menu_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(449, 133);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 15;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(449, 90);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(447, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "LakeShore";
            // 
            // button_ConnectToLakeShore
            // 
            this.button_ConnectToLakeShore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_ConnectToLakeShore.Location = new System.Drawing.Point(587, 131);
            this.button_ConnectToLakeShore.Name = "button_ConnectToLakeShore";
            this.button_ConnectToLakeShore.Size = new System.Drawing.Size(24, 23);
            this.button_ConnectToLakeShore.TabIndex = 12;
            this.button_ConnectToLakeShore.UseVisualStyleBackColor = false;
            this.button_ConnectToLakeShore.Click += new System.EventHandler(this.button_ConnectToLakeShore_Click);
            // 
            // button_ConnectToMultimetr
            // 
            this.button_ConnectToMultimetr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_ConnectToMultimetr.Location = new System.Drawing.Point(587, 88);
            this.button_ConnectToMultimetr.Name = "button_ConnectToMultimetr";
            this.button_ConnectToMultimetr.Size = new System.Drawing.Size(24, 23);
            this.button_ConnectToMultimetr.TabIndex = 11;
            this.button_ConnectToMultimetr.UseVisualStyleBackColor = false;
            this.button_ConnectToMultimetr.Click += new System.EventHandler(this.button_ConnectToMultimetr_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(447, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Multimetr";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Multimetr",
            "LakeShore",
            "Lock-in Amplifier"});
            this.checkedListBox1.Location = new System.Drawing.Point(450, 172);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 94);
            this.checkedListBox1.TabIndex = 16;
            this.checkedListBox1.TabStop = false;
            // 
            // button_LoopSendCommand
            // 
            this.button_LoopSendCommand.Location = new System.Drawing.Point(244, 11);
            this.button_LoopSendCommand.Name = "button_LoopSendCommand";
            this.button_LoopSendCommand.Size = new System.Drawing.Size(163, 26);
            this.button_LoopSendCommand.TabIndex = 17;
            this.button_LoopSendCommand.Text = "Loop Send Command";
            this.button_LoopSendCommand.UseVisualStyleBackColor = true;
            this.button_LoopSendCommand.Click += new System.EventHandler(this.button_LoopSendCommand_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(450, 273);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 18;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button_Clr
            // 
            this.button_Clr.Location = new System.Drawing.Point(360, 104);
            this.button_Clr.Name = "button_Clr";
            this.button_Clr.Size = new System.Drawing.Size(75, 23);
            this.button_Clr.TabIndex = 19;
            this.button_Clr.Text = "Clr";
            this.button_Clr.UseVisualStyleBackColor = true;
            this.button_Clr.Click += new System.EventHandler(this.button_Clr_Click);
            // 
            // Form_Test_RS232
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 450);
            this.Controls.Add(this.button_Clr);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button_LoopSendCommand);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_ConnectToLakeShore);
            this.Controls.Add(this.button_ConnectToMultimetr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Menu);
            this.Controls.Add(this.button_SendCommand);
            this.Controls.Add(this.richTextBox_Out);
            this.Controls.Add(this.textBox_Respond);
            this.Name = "Form_Test_RS232";
            this.Text = "Test_Re232";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Respond;
        private System.Windows.Forms.RichTextBox richTextBox_Out;
        private System.Windows.Forms.Button button_SendCommand;
        private System.Windows.Forms.Button button_Menu;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_ConnectToLakeShore;
        private System.Windows.Forms.Button button_ConnectToMultimetr;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button button_LoopSendCommand;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button_Clr;
    }
}