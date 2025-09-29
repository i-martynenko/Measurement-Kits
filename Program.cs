using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Measurement_Kits
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Menu());
        }
        
    }
    public static class GlobalExitHelper
    {
        // Підключаємо глобальний вихід для форми
        public static void AttachGlobalExit(Form form, bool isMainForm = false)
        {
            form.FormClosing += (s, e) =>
            {
                // Якщо головна форма закривається — завжди закриваємо всю програму
                if (isMainForm)
                {
                    Application.Exit();
                }
                else
                {
                    // Якщо закривається підформа без прапорця "Switching"
                    if (!form.Tag?.Equals("Switching") ?? true)
                    {
                        Application.Exit();
                    }
                }
            };
        }

        public static void SwitchTo(Form current, Form next, bool hideInsteadOfClose = false)
        {
            current.Tag = "Switching";
            //AttachGlobalExit(next);

            next.Show();
            next.BringToFront();

            if (hideInsteadOfClose)
                current.Hide();   // для головного меню
            else
                current.Close();  // для підменю
        }
    }
}
