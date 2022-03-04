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
    public partial class ReportForm1 : DevExpress.XtraEditors.XtraForm
    {
        public ReportForm1()
        {
            InitializeComponent();
        }
        private void ReportForm1_Load(object sender, EventArgs e)
        {
            DataTable products = Query.Show("SELECT Product.Fullname FROM Product;");
            productCB.Items.Add("All");
            productCB.SelectedIndex = 0;
            foreach (DataRow row in products.Rows)
            {
                productCB.Items.Add(row[0].ToString());
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void showButton_Click(object sender, EventArgs e)
        {
            string queryMain = $@"SELECT Product.Fullname, CAST(Product.Price as decimal(10,2)) as Price, CAST(Movement.Quantity as decimal(10,2)) as Litres, CAST(Movement.Total as decimal(10,2)) as Total, Bonus.Date FROM Movement
                                  JOIN Bonus ON Bonus.Id = Movement.BonusId
                                  JOIN Product ON Product.Id = Movement.ProductId
                                  WHERE Bonus.Date BETWEEN '{dateTimePicker1.Value.Date.ToString("yyyy-MM-dd")} 00:00:00' AND '{dateTimePicker2.Value.Date.ToString("yyyy-MM-dd")} 23:59:59'";

            string productNameFilter = string.Empty;
            if (productCB.Text == "All" || productCB.Text == "") productNameFilter = string.Empty;
            else productNameFilter = $@" AND Product.Fullname='{productCB.SelectedItem.ToString()}'";

            string totalLitres = $@"SELECT CAST(SUM(Movement.Quantity) as decimal(10,2)) as Quantity FROM Movement
                                    JOIN Bonus ON Bonus.Id = Movement.BonusId
                                    JOIN Product ON Product.Id = Movement.ProductId
                                    WHERE Bonus.Date BETWEEN '{dateTimePicker1.Value.Date.ToString("yyyy-MM-dd")} 00:00:00' AND '{dateTimePicker2.Value.Date.ToString("yyyy-MM-dd")} 23:59:59'";
            string totalLitresFilter = string.Empty;
            if (productCB.Text == "All" || productCB.Text == "") totalLitresFilter = string.Empty;
            else totalLitresFilter = $@" AND Product.Fullname='{productCB.SelectedItem.ToString()}'";

            string totalPrice =  $@"SELECT CAST(SUM(Movement.Total) as decimal(10,2)) as Price FROM Movement
                                    JOIN Bonus ON Bonus.Id = Movement.BonusId
                                    JOIN Product ON Product.Id = Movement.ProductId
                                    WHERE Bonus.Date BETWEEN '{dateTimePicker1.Value.Date.ToString("yyyy-MM-dd")} 00:00:00' AND '{dateTimePicker2.Value.Date.ToString("yyyy-MM-dd")} 23:59:59'";
            string totalPriceFilter = string.Empty;
            if (productCB.Text == "All" || productCB.Text == "") totalPriceFilter = string.Empty;
            else totalPriceFilter = $@" AND Product.Fullname='{productCB.SelectedItem.ToString()}'";

            using (SqlConnection connection = new SqlConnection(LoginForm.ConStr))
            {
                connection.Open();

                SqlCommand commandTotalLitres = new SqlCommand(totalLitres+totalLitresFilter, connection);
                string totalLitresText = (Convert.ToString(commandTotalLitres.ExecuteScalar()));
                totalLitresLabel.Text = $"{totalLitresText} Lt";

                SqlCommand commandTotalPrice = new SqlCommand(totalPrice + totalPriceFilter, connection);
                string totalPriceText = (Convert.ToString(commandTotalPrice.ExecuteScalar()));
                totalPriceLabel.Text = $"{totalPriceText} AZN";
            }

            dataGridView.DataSource = Query.Show(queryMain + productNameFilter);
            dataGridView.Columns[0].Width = 150;
            dataGridView.Columns[1].Width = 150;
            dataGridView.Columns[2].Width = 150;
            dataGridView.Columns[3].Width = 150;
            dataGridView.Columns[4].Width = 150;
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