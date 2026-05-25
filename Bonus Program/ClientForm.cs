using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;
using Bonus_Program.Data;
using Bonus_Program.Models;

namespace Bonus_Program
{
    public partial class ClientForm : DevExpress.XtraEditors.XtraForm
    {
        public ClientForm()
        {
            InitializeComponent();
        }
        private void ClientForm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            using (var db = new BonusDbContext())
            {
                var clients = db.Clients.Select(c => new
                {
                    c.Name,
                    c.Lastname,
                    c.CardNumber,
                    c.Bonus
                }).ToList();

                var dt = new DataTable();
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Lastname", typeof(string));
                dt.Columns.Add("CardNumber", typeof(string));
                dt.Columns.Add("Bonus", typeof(decimal));

                foreach (var c in clients)
                    dt.Rows.Add(c.Name, c.Lastname, c.CardNumber, c.Bonus);

                dataGridView.DataSource = dt;
            }

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
            using (var db = new BonusDbContext())
            {
                db.Clients.Add(new Client
                {
                    Name = nameTB.Text,
                    Lastname = lastnameTB.Text,
                    CardNumber = cardTB.Text,
                    Bonus = 0
                });
                db.SaveChanges();
            }

            RefreshGrid();
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
            catch (Exception)
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
