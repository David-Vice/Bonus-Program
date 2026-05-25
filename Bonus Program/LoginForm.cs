using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Configuration;
using Bonus_Program.Data;

namespace Bonus_Program
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        public static string ConStr { get; set; }
        public int ManagerId { get; set; }
        public bool ManagerIsAdmin { get; set; }

        public LoginForm()
        {
            InitializeComponent();
            ConStr = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            using (var db = new BonusDbContext())
            {
                var logins = db.Managers.Select(m => m.Login).ToList();
                foreach (var login in logins)
                {
                    managerCB.Properties.Items.Add(login);
                }
                if (managerCB.Properties.Items.Count > 0)
                    managerCB.SelectedIndex = 0;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (managerCB.SelectedItem == null) return;

            string selectedLogin = managerCB.SelectedItem.ToString();
            string enteredPassword = passTB.Text;

            using (var db = new BonusDbContext())
            {
                var manager = db.Managers.FirstOrDefault(m => m.Login == selectedLogin);
                if (manager != null && manager.Password == enteredPassword)
                {
                    this.ManagerId = manager.Id;
                    this.ManagerIsAdmin = manager.Admin;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong login or password!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPanel_Click(object sender, EventArgs e)
        {
            if (((Control)sender).Tag.ToString() == "<")
            {
                if (this.passTB.Text.Length > 0) this.passTB.Text = this.passTB.Text.Remove(this.passTB.Text.Length - 1, 1);
                this.passTB.Select(this.passTB.Text.Length, 0);
            }
            else
            {
                this.passTB.Text += (string)((Control)sender).Tag;
                this.passTB.Select(this.passTB.Text.Length, 0);
            }
        }
    }
}
