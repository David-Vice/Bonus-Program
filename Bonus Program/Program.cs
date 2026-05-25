using System;
using System.Windows.Forms;
using Bonus_Program.Data;

namespace Bonus_Program
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var db = new BonusDbContext())
            {
                db.Database.Initialize(false);
            }

            LoginForm login = new LoginForm();
            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm(login.ManagerId, login.ManagerIsAdmin));
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
