using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Configuration;

namespace Bonus_Program
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        public static string ConStr { get; set; }
        public int ManagerId { get; set; }


        public LoginForm()
        {
            InitializeComponent();
            ConStr = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            DataTable managers = Query.Show("SELECT Manager.Login FROM [Manager];");
            foreach (DataRow row in managers.Rows)
            {
                managerCB.Properties.Items.Add(row[0].ToString());
                managerCB.SelectedIndex = 0;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                string passQuery = $@"SELECT Manager.Password FROM Manager WHERE Manager.Login = '{managerCB.SelectedItem.ToString()}';";
                SqlCommand passCommand = new SqlCommand(passQuery, connection);
                string password = Convert.ToString(passCommand.ExecuteScalar());

                if (password == passTB.Text)
                {
                    string managerQuery = $@"SELECT Manager.Id FROM Manager WHERE Manager.Login = '{managerCB.SelectedItem.ToString()}' AND Manager.Password = '{passTB.Text}';";
                    SqlCommand managerCommand = new SqlCommand(managerQuery, connection);
                    this.ManagerId = Convert.ToInt32(managerCommand.ExecuteScalar());
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