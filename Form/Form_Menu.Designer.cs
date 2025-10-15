
namespace Measurement_Kits
{
    partial class Form_Menu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Transport = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button_Test_Plot = new System.Windows.Forms.Button();
            this.button_Test_RS232 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Transport
            // 
            this.button_Transport.Location = new System.Drawing.Point(87, 50);
            this.button_Transport.Name = "button_Transport";
            this.button_Transport.Size = new System.Drawing.Size(170, 40);
            this.button_Transport.TabIndex = 0;
            this.button_Transport.Text = "Transport";
            this.button_Transport.UseVisualStyleBackColor = true;
            this.button_Transport.Click += new System.EventHandler(this.button_Transport_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(87, 109);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 40);
            this.button2.TabIndex = 1;
            this.button2.Text = "Magnetic susceptibility\r\n Multimete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 40);
            this.button1.TabIndex = 2;
            this.button1.Text = "Magnetic susceptibility\r\nLakeShore\r\n";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button_Test_Plot
            // 
            this.button_Test_Plot.Location = new System.Drawing.Point(12, 398);
            this.button_Test_Plot.Name = "button_Test_Plot";
            this.button_Test_Plot.Size = new System.Drawing.Size(170, 40);
            this.button_Test_Plot.TabIndex = 3;
            this.button_Test_Plot.Text = "Test Plot";
            this.button_Test_Plot.UseVisualStyleBackColor = true;
            this.button_Test_Plot.Click += new System.EventHandler(this.button_Test_Plot_Click);
            // 
            // button_Test_RS232
            // 
            this.button_Test_RS232.Location = new System.Drawing.Point(199, 398);
            this.button_Test_RS232.Name = "button_Test_RS232";
            this.button_Test_RS232.Size = new System.Drawing.Size(170, 40);
            this.button_Test_RS232.TabIndex = 4;
            this.button_Test_RS232.Text = "Test RS232";
            this.button_Test_RS232.UseVisualStyleBackColor = true;
            this.button_Test_RS232.Click += new System.EventHandler(this.button_Test_RS232_Click);
            // 
            // Form_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 450);
            this.Controls.Add(this.button_Test_RS232);
            this.Controls.Add(this.button_Test_Plot);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_Transport);
            this.Name = "Form_Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Form_Menu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Transport;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_Test_Plot;
        private System.Windows.Forms.Button button_Test_RS232;
    }
}

