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
using System.Diagnostics;

namespace Bonus_Program
{
    public partial class ReportForm2 : DevExpress.XtraEditors.XtraForm
    {
        public ReportForm2()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void showButton_Click(object sender, EventArgs e)
        {
            string queryMain = $@"SELECT Client.Name+' '+Client.Lastname as Client, Client.Cardnumber as Card, CAST(Client.Bonus as decimal(10,2)) as 'Bonus', CAST(Bonus.UsedBonus as decimal(10,2)) as 'Used Bonus', CAST(Bonus.Payed as decimal(10,2)) as Payment, CAST(Bonus.Total as decimal(10,2)) as Total, CAST(Bonus.NewBonus as decimal(10,2)) as 'New Bonus', Bonus.Date, Manager.Name+' '+Manager.Lastname as Manager FROM Bonus
                                  JOIN Client ON Client.Id = Bonus.ClientId
                                  JOIN Manager ON Manager.Id = Bonus.ManagerId
                                  WHERE Bonus.Date BETWEEN '{dateTimePicker1.Value.Date.ToString("yyyy-MM-dd")} 00:00:00' AND '{dateTimePicker2.Value.Date.ToString("yyyy-MM-dd")} 23:59:59'";
            string clientFilter;
            if (clientTB.Text == "") clientFilter = string.Empty;
            else clientFilter = $@" AND Client.Name+' '+Client.Lastname LIKE '%{clientTB.Text}%'";
            string cardFilter;
            if (cardTB.Text == "") cardFilter = string.Empty;
            else cardFilter = $@" AND Client.Cardnumber LIKE '%{cardTB.Text}%'";
            string managerFilter;
            if (managerTB.Text == "") managerFilter = string.Empty;
            else managerFilter = $@" AND Manager.Name+' '+Manager.Lastname LIKE '%{managerTB.Text}%'";

            string totalUsedBonus = $@"SELECT CAST(SUM(Bonus.UsedBonus) as decimal(10,2)) as 'Used Bonus' FROM Bonus
                                       JOIN Client ON Client.Id = Bonus.ClientId
                                       JOIN Manager ON Manager.Id = Bonus.ManagerId
                                       WHERE Bonus.Date BETWEEN '{dateTimePicker1.Value.Date.ToString("yyyy-MM-dd")} 00:00:00' AND '{dateTimePicker2.Value.Date.ToString("yyyy-MM-dd")} 23:59:59'";
            
            string totalNewBonus = $@"SELECT CAST(SUM(Bonus.NewBonus) as decimal(10,2)) as 'New Bonus' FROM Bonus
                                      JOIN Client ON Client.Id = Bonus.ClientId
                                      JOIN Manager ON Manager.Id = Bonus.ManagerId
                                      WHERE Bonus.Date BETWEEN '{dateTimePicker1.Value.Date.ToString("yyyy-MM-dd")} 00:00:00' AND '{dateTimePicker2.Value.Date.ToString("yyyy-MM-dd")} 23:59:59'";
            
            string totalTotal = $@"SELECT CAST(SUM(Bonus.Total) as decimal(10,2)) as 'Total' FROM Bonus
                                   JOIN Client ON Client.Id = Bonus.ClientId
                                   JOIN Manager ON Manager.Id = Bonus.ManagerId
                                   WHERE Bonus.Date BETWEEN '{dateTimePicker1.Value.Date.ToString("yyyy-MM-dd")} 00:00:00' AND '{dateTimePicker2.Value.Date.ToString("yyyy-MM-dd")} 23:59:59'";
            
            string totalPayment = $@"SELECT CAST(SUM(Bonus.Payed) as decimal(10,2)) as 'Payment' FROM Bonus
                                     JOIN Client ON Client.Id = Bonus.ClientId
                                     JOIN Manager ON Manager.Id = Bonus.ManagerId
                                     WHERE Bonus.Date BETWEEN '{dateTimePicker1.Value.Date.ToString("yyyy-MM-dd")} 00:00:00' AND '{dateTimePicker2.Value.Date.ToString("yyyy-MM-dd")} 23:59:59'";

            using (SqlConnection connection = new SqlConnection(LoginForm.ConStr))
            {
                connection.Open();

                SqlCommand commandTotalUsedBonus = new SqlCommand(totalUsedBonus + clientFilter + cardFilter + managerFilter, connection);
                string totalUsedBonusText = (Convert.ToString(commandTotalUsedBonus.ExecuteScalar()));
                usedBonusLabel.Text = $"{totalUsedBonusText} AZN";

                SqlCommand commandTotalNewBonus = new SqlCommand(totalNewBonus + clientFilter + cardFilter + managerFilter, connection);
                string totalNewBonusText = (Convert.ToString(commandTotalNewBonus.ExecuteScalar()));
                newBonusLabel.Text = $"{totalNewBonusText} AZN";

                SqlCommand commandTotalTotal = new SqlCommand(totalTotal + clientFilter + cardFilter + managerFilter, connection);
                string totalTotalText = (Convert.ToString(commandTotalTotal.ExecuteScalar()));
                totalPriceLabel.Text = $"{totalTotalText} AZN";

                SqlCommand commandTotalPayment = new SqlCommand(totalPayment + clientFilter + cardFilter + managerFilter, connection);
                string totalPaymentText = (Convert.ToString(commandTotalPayment.ExecuteScalar()));
                paymentLabel.Text = $"{totalPaymentText} AZN";

                float realBonus = Convert.ToSingle(totalNewBonusText) - Convert.ToSingle(totalUsedBonusText);
                currentBonusLabel.Text = $"{realBonus.ToString("n2")} AZN";
            }

            dataGridView.DataSource = Query.Show(queryMain + clientFilter + cardFilter + managerFilter);
            dataGridView.Columns[0].Width = 120;
            dataGridView.Columns[1].Width = 120;
            dataGridView.Columns[2].Width = 100;
            dataGridView.Columns[3].Width = 100;
            dataGridView.Columns[4].Width = 100;
            dataGridView.Columns[5].Width = 100;
            dataGridView.Columns[6].Width = 100;
            dataGridView.Columns[7].Width = 120;
            dataGridView.Columns[8].Width = 120;
            dataGridView.RowTemplate.Height = 40;
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