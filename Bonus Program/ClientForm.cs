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
using System.Diagnostics;
using System.Data.SqlClient;

namespace Bonus_Program
{
    public partial class ClientForm : DevExpress.XtraEditors.XtraForm
    {

        private string getTable = "SELECT Client.Name, Client.Lastname, Client.Cardnumber, Client.Bonus FROM Client";

        public ClientForm()
        {
            InitializeComponent();
        }
        private void ClientForm_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = Query.Show(getTable);

            dataGridView.Columns[0].Width = 200;
            dataGridView.Columns[1].Width = 200;
            dataGridView.Columns[2].Width = 200;
            dataGridView.Columns[3].Width = 200;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void addClient_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(LoginForm.ConStr))
            {
                connection.Open();
                string query = $@"INSERT INTO [Client] (Name,Lastname,Cardnumber)
                                  VALUES('{nameTB.Text}','{lastnameTB.Text}','{cardTB.Text}')";

                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            
            dataGridView.DataSource = Query.Show(getTable);
            nameTB.Text = string.Empty;
            lastnameTB.Text = string.Empty;
            cardTB.Text = string.Empty;
        }

        private void turnOnKeyboard_Click(object sender, EventArgs e)
        {
            bool flag = false;
            try
            {
                foreach (Process process in Process.GetProcesses())
                {
                    if (process.ProcessName == "osk")
                        flag = true;
                }
                if (flag)
                    return;
                Process.Start("osk.exe");
            }
            catch (Exception ex)
            {
            }
        }
        private void turnOffKeyboard_Click(object sender, EventArgs e)
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName == "osk")
                    process.Kill();
            }
        }
    }
}