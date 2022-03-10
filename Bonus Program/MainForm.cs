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
using Newtonsoft.Json;
using System.IO;

namespace Bonus_Program
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        private TextBox focusedTextbox = null;
        public int MinLitresForBonus { get; set; }

        private void InitializeGV()
        {
            currentGV.Columns.Add("Product", "Product");
            currentGV.Columns.Add("Price", "Price");
            currentGV.Columns.Add("Litres", "Litres");
            currentGV.Columns.Add("Total", "Total");

            currentGV.Columns[0].Width = 100;
            currentGV.Columns[1].Width = 100;
            currentGV.Columns[2].Width = 100;
            currentGV.Columns[3].Width = 100;
        }
        private void ResetGV()
        {
            currentGV.Rows.Clear();
        }

        //Final Values
        private float total;
        private float useBonus;
        private float payment;
        private float newBonus;
        private float totalLitres;
        private void ResetFinalVals()
        {
            total = 0;
            useBonus = 0;
            payment = 0;
            newBonus = 0;
            totalLitres = 0;
        }
        private void ResetFinal()
        {
            finalTotalLabel.Text = "0.00";
            finalNewBonusLabel.Text = "0.00";
            finalUseBonusTB.Text = string.Empty;
            finalPaymentLabel.Text = "0.00";
        }

        //Client
        private int clientId;
        private string clientName;
        private string clientLastname;
        private string clientCardNumber;
        private float clientBonus;
        private void GetClientInfo(int clientId)
        {
            DataTable clientData = Query.Show($"SELECT Client.Id, Client.Name, Client.Lastname, Client.CardNumber, Client.Bonus FROM Client WHERE Client.Id = {clientId}");
            DataRow clientRow = clientData.Rows[0];
            this.clientId = Convert.ToInt32(clientRow[0]);
            clientName = Convert.ToString(clientRow[1]);
            clientLastname = Convert.ToString(clientRow[2]);
            clientCardNumber = Convert.ToString(clientRow[3]);
            clientBonus = Convert.ToSingle(clientRow[4]);
        }
        private void ResetClientInfo()
        {
            clientId = 0;
            clientName = string.Empty;
            clientLastname = string.Empty;
            clientCardNumber = string.Empty;
            clientBonus = -1;
        }

        //Manager
        private int managerId;
        private string managerName;
        private string managerLastname;
        private string managerLogin;
        private string managerPassword;
        private bool managerIsAdmin;
        private void GetManagerInfo(int managerId)
        {
            DataTable managerData = Query.Show($"SELECT Manager.Id, Manager.Name, Manager.Lastname, Manager.Login, Manager.Password, Manager.Admin FROM Manager WHERE Manager.Id = {managerId}");
            DataRow managerRow = managerData.Rows[0];
            this.managerId = Convert.ToInt32(managerRow[0]);
            managerName = Convert.ToString(managerRow[1]);
            managerLastname = Convert.ToString(managerRow[2]);
            managerLogin = Convert.ToString(managerRow[3]);
            managerPassword = Convert.ToString(managerRow[4]);
            managerIsAdmin = Convert.ToBoolean(managerRow[5]);
        }
        private void ResetManagerInfo()
        {
            managerId = 0;
            managerName = string.Empty;
            managerLastname = string.Empty;
            managerLogin = string.Empty;
            managerPassword = string.Empty;
            managerIsAdmin = false;
        }

        //Product
        private int productId;
        private string productFullname;
        private float productPrice;
        private float productBonusPercent;
        private void GetProductInfo(int productId)
        {
            DataTable productData = Query.Show($"SELECT Product.Id, Product.Fullname, Product.Price, Product.BonusPercent FROM Product WHERE Product.Id = {productId}");
            DataRow productRow = productData.Rows[0];
            this.productId = Convert.ToInt32(productRow[0]);
            productFullname = Convert.ToString(productRow[1]);
            productPrice = Convert.ToSingle(productRow[2]);
            productBonusPercent = Convert.ToSingle(productRow[3]);
        }
        private void ResetProductInfo()
        {
            productId = 0;
            productFullname = string.Empty;
            productPrice = -1;
            productBonusPercent = -1;
        }

        public MainForm()
        {
            InitializeComponent();
            InitializeGV();
            ResetForm();
            ResetFinal();
            ResetManagerInfo();
            ResetClientInfo();
            ResetProductInfo();
        }
        public MainForm(int managerId)
        {
            InitializeComponent();
            InitializeGV();
            ResetForm();
            ResetFinal();
            ResetManagerInfo();
            ResetClientInfo();
            ResetProductInfo();

            GetManagerInfo(managerId);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            if(Convert.ToBoolean(managerId))
            {
                cashierLabel.Text = "Cashier: " + managerName + " " + managerLastname; 
                if (managerIsAdmin)
                {
                    statusLabel.Text = "Status: " + "Admin";
                }
                else
                {
                    statusLabel.Text = "Status: " + "User";
                }
            }
            GetMinLimit();
        }
        private void ResetForm()
        {
            cardnumTB.Text = string.Empty;
            clientNameLabel.Text = "Client Info";
            clientBonusLabel.Text = "Bonus";

            productLabel.Text = "Product";
            priceLabel.Text = "0.00";
            totalLabel.Text = "0.00";

            aznTB.Text = string.Empty;
            ltTB.Text = string.Empty;
            subtotalLabel.Text = "Subtotal";

            productsTLP.Enabled = false;
            quantTLP.Enabled = false;
        }
        private void ResetClientPartForm()
        {
            cardnumTB.Text = string.Empty;
            clientNameLabel.Text = "Client Info";
            clientBonusLabel.Text = "Bonus";
        }
        private void ResetProductPartForm()
        {
            productLabel.Text = "Product";
            priceLabel.Text = "0.00";
            totalLabel.Text = "0.00";
        }
        private void ResetSubtotalPartForm()
        {
            aznTB.Text = string.Empty;
            ltTB.Text = string.Empty;
            subtotalLabel.Text = "Subtotal";
        }

        private void tb_Enter(object sender, EventArgs e)
        {
            focusedTextbox = (TextBox)sender;
            (sender as TextBox).BackColor = Color.LightSteelBlue;
        }
        private void tb_Leave(object sender, EventArgs e)
        {
            focusedTextbox = null;
            (sender as TextBox).BackColor = Color.White;
        }

        private void aznTB_TextChanged(object sender, EventArgs e)
        {
            if (focusedTextbox == (TextBox)sender)
            {
                if (aznTB.Text == string.Empty)
                {
                    ltTB.Text = string.Empty;
                    subtotalLabel.Text = "Subtotal: 0";
                }
                else
                {
                    ltTB.Text = (Convert.ToSingle(aznTB.Text) / productPrice).ToString("n2");
                    subtotalLabel.Text = "Subtotal: " + aznTB.Text;
                }
            }
        }
        private void ltTB_TextChanged(object sender, EventArgs e)
        {
            if (focusedTextbox == (TextBox)sender)
            {
                if (ltTB.Text == string.Empty)
                {
                    aznTB.Text = string.Empty;
                    subtotalLabel.Text = "Subtotal: 0";
                }
                else
                {
                    aznTB.Text = (Convert.ToSingle(ltTB.Text) * productPrice).ToString("n2");
                    subtotalLabel.Text = "Subtotal: " + aznTB.Text;
                }
            }
        }

        private void numPad_Click(object sender, EventArgs e)
        {
            if (focusedTextbox != null)
            {
                if (((Control)sender).Tag.ToString() == "<")
                {
                    if (this.focusedTextbox.Text.Length > 0) this.focusedTextbox.Text = this.focusedTextbox.Text.Remove(this.focusedTextbox.Text.Length - 1, 1);
                    this.focusedTextbox.Select(this.focusedTextbox.Text.Length, 0);
                }
                else
                {
                    this.focusedTextbox.Text += (string)((Control)sender).Tag;
                    this.focusedTextbox.Select(this.focusedTextbox.Text.Length, 0);
                }
            }
        }

        private void productButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(LoginForm.ConStr))
            {
                connection.Open();
                string productIdQuery = $@"SELECT Product.Id FROM Product WHERE Product.Fullname = '{(sender as SimpleButton).Text}';";
                SqlCommand productIdCommand = new SqlCommand(productIdQuery, connection);
                int productId = Convert.ToInt32(productIdCommand.ExecuteScalar());

                ResetProductPartForm();
                ResetSubtotalPartForm();
                ResetProductInfo();
                quantTLP.Enabled = false;

                if (productId == 0)
                {
                    MessageBox.Show("No such product in DB!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    GetProductInfo(productId);
                    quantTLP.Enabled = true;

                    productLabel.Text = productFullname;
                    priceLabel.Text = productPrice.ToString("n2");
                    aznTB.Focus();
                }
            }
        }

        private void addToListButton_Click(object sender, EventArgs e)
        {
            int rowId = currentGV.Rows.Add();
            currentGV.Rows[rowId].Cells["Product"].Value = productFullname;
            currentGV.Rows[rowId].Cells["Price"].Value = productPrice;
            currentGV.Rows[rowId].Cells["Litres"].Value = Convert.ToSingle(ltTB.Text);
            currentGV.Rows[rowId].Cells["Total"].Value = Convert.ToSingle(aznTB.Text);
            UpdateTotal();
        }
        private void delRowButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.currentGV.SelectedRows)
            {
                currentGV.Rows.RemoveAt(item.Index);
            }
            UpdateTotal();
        }
        private void finalUseBonusTB_TextChanged(object sender, EventArgs e)
        {
            if(finalUseBonusTB.Text == string.Empty)
            {
                useBonus = 0;
            }
            else
            {
                useBonus = Convert.ToSingle(finalUseBonusTB.Text);
            }
            UpdateTotal();
        }
        private void UpdateTotal()
        {
            float finalTotal = 0;
            float finalTotalLitres = 0;
            for (int i = 0; i < currentGV.Rows.Count; i++)
            {
                finalTotal += Convert.ToSingle(currentGV.Rows[i].Cells["Total"].Value.ToString());
                finalTotalLitres += Convert.ToSingle(currentGV.Rows[i].Cells["Litres"].Value.ToString());
            }
            total = finalTotal;
            totalLitres = finalTotalLitres;

            if(total>0)
            {
                finalUseBonusTB.Enabled = true;
            }
            else
            {
                finalUseBonusTB.Enabled = false;
                finalUseBonusTB.Text = string.Empty;
            }

            payment = total - useBonus;

            float finalNewBonus = 0;
            float subtotal = 0;
            string currentProductName = "";
            for (int i = 0; i < currentGV.Rows.Count; i++)
            {
                subtotal = Convert.ToSingle(currentGV.Rows[i].Cells["Total"].Value.ToString());
                currentProductName = currentGV.Rows[i].Cells["Product"].Value.ToString();
                DataTable productData = Query.Show($"SELECT Product.BonusPercent FROM Product WHERE Product.Fullname = '{currentProductName}'");
                DataRow productRow = productData.Rows[0];
                float productPercent = Convert.ToSingle(productRow[0]);

                finalNewBonus += (subtotal - (subtotal / finalTotal * useBonus))*(productPercent/100);
            }
            newBonus = finalNewBonus;
            if (clientName.ToLower().Contains("noname") || clientLastname.ToLower().Contains("noname") || totalLitres<MinLitresForBonus) newBonus = 0;

            finalTotalLabel.Text = total.ToString("n2");
            finalPaymentLabel.Text = payment.ToString("n2");
            totalLabel.Text = payment.ToString("n2");
            finalNewBonusLabel.Text = newBonus.ToString("n2");
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            ExitForm exit = new ExitForm();
            exit.ShowDialog();
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to cancel current operation?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ResetForm();
                ResetGV();
                ResetFinal();
                ResetFinalVals();
                ResetClientInfo();
                ResetProductInfo();
            }
        }
        private void confirmButton_Click(object sender, EventArgs e)
        {
            if(currentGV.Rows.Count <= 0)
            {
                MessageBox.Show("No products in list!", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(useBonus>clientBonus)
            {
                MessageBox.Show("Too much bonus!", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(payment<0)
            {
                MessageBox.Show("Payment can't be less than 0!", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(clientName.ToLower().Contains("noname") || clientLastname.ToLower().Contains("noname"))
            {
                using (SqlConnection connection = new SqlConnection(LoginForm.ConStr))
                {
                    connection.Open();

                    string queryUpdate = $@"UPDATE Client SET Client.Bonus = 0 WHERE Client.Id = {clientId};";
                    SqlCommand commandUpdate = new SqlCommand(queryUpdate, connection);
                    commandUpdate.ExecuteNonQuery();

                    string bonusInsertQuery = $@"INSERT INTO Bonus(ClientId, ManagerId, UsedBonus, NewBonus, Payed, Total, Date)
                                             OUTPUT INSERTED.ID
                                             VALUES({clientId}, {managerId}, 0, 0, CAST({payment} as decimal(10,2)), CAST({total} as decimal(10,2)), GETDATE())";
                    SqlCommand bonusInsertCommand = new SqlCommand(bonusInsertQuery, connection);
                    int lastBonusId = Convert.ToInt32(bonusInsertCommand.ExecuteScalar());

                    for (int i = 0; i < currentGV.Rows.Count; i++)
                    {
                        string productForDb = currentGV.Rows[i].Cells["Product"].Value.ToString();
                        float quantForDb = Convert.ToSingle(currentGV.Rows[i].Cells["Litres"].Value.ToString());
                        float totalForDb = Convert.ToSingle(currentGV.Rows[i].Cells["Total"].Value.ToString());

                        string query = $@"INSERT INTO Movement(ProductId, BonusId, Quantity, Total)
                                      SELECT Product.Id,{lastBonusId},CAST({quantForDb} as decimal(10,2)),CAST({totalForDb}as decimal(10,2))
                                      FROM Product
                                      WHERE Product.Fullname = '{productForDb}';";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                    }
                }
                ResetForm();
                ResetGV();
                ResetFinal();
                ResetFinalVals();
                ResetClientInfo();
                ResetProductInfo();
                cardnumTB.Focus();
            }
            else if(totalLitres<MinLitresForBonus)
            {
                using (SqlConnection connection = new SqlConnection(LoginForm.ConStr))
                {
                    connection.Open();

                    string bonusInsertQuery = $@"INSERT INTO Bonus(ClientId, ManagerId, UsedBonus, NewBonus, Payed, Total, Date)
                                             OUTPUT INSERTED.ID
                                             VALUES({clientId}, {managerId}, CAST({useBonus} as decimal(10,2)), 0, CAST({payment} as decimal(10,2)), CAST({total} as decimal(10,2)), GETDATE())";
                    SqlCommand bonusInsertCommand = new SqlCommand(bonusInsertQuery, connection);
                    int lastBonusId = Convert.ToInt32(bonusInsertCommand.ExecuteScalar());

                    for (int i = 0; i < currentGV.Rows.Count; i++)
                    {
                        string productForDb = currentGV.Rows[i].Cells["Product"].Value.ToString();
                        float quantForDb = Convert.ToSingle(currentGV.Rows[i].Cells["Litres"].Value.ToString());
                        float totalForDb = Convert.ToSingle(currentGV.Rows[i].Cells["Total"].Value.ToString());

                        string query = $@"INSERT INTO Movement(ProductId, BonusId, Quantity, Total)
                                      SELECT Product.Id,{lastBonusId},CAST({quantForDb} as decimal(10,2)),CAST({totalForDb}as decimal(10,2))
                                      FROM Product
                                      WHERE Product.Fullname = '{productForDb}';";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                    }
                }
                ResetForm();
                ResetGV();
                ResetFinal();
                ResetFinalVals();
                ResetClientInfo();
                ResetProductInfo();
                cardnumTB.Focus();
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(LoginForm.ConStr))
                {
                    connection.Open();

                    string queryUpdate = $@"UPDATE Client SET Client.Bonus = CAST({clientBonus - useBonus + newBonus} as decimal(10,2)) WHERE Client.Id = {clientId};";
                    SqlCommand commandUpdate = new SqlCommand(queryUpdate, connection);
                    commandUpdate.ExecuteNonQuery();

                    string bonusInsertQuery = $@"INSERT INTO Bonus(ClientId, ManagerId, UsedBonus, NewBonus, Payed, Total, Date)
                                             OUTPUT INSERTED.ID
                                             VALUES({clientId}, {managerId}, CAST({useBonus} as decimal(10,2)), CAST({newBonus} as decimal(10,2)), CAST({payment} as decimal(10,2)), CAST({total} as decimal(10,2)), GETDATE())";
                    SqlCommand bonusInsertCommand = new SqlCommand(bonusInsertQuery, connection);
                    int lastBonusId = Convert.ToInt32(bonusInsertCommand.ExecuteScalar());

                    for (int i = 0; i < currentGV.Rows.Count; i++)
                    {
                        string productForDb = currentGV.Rows[i].Cells["Product"].Value.ToString();
                        float quantForDb = Convert.ToSingle(currentGV.Rows[i].Cells["Litres"].Value.ToString());
                        float totalForDb = Convert.ToSingle(currentGV.Rows[i].Cells["Total"].Value.ToString());

                        string query = $@"INSERT INTO Movement(ProductId, BonusId, Quantity, Total)
                                      SELECT Product.Id,{lastBonusId},CAST({quantForDb} as decimal(10,2)),CAST({totalForDb}as decimal(10,2))
                                      FROM Product
                                      WHERE Product.Fullname = '{productForDb}';";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                    }
                }
                ResetForm();
                ResetGV();
                ResetFinal();
                ResetFinalVals();
                ResetClientInfo();
                ResetProductInfo();
                cardnumTB.Focus();
            }
        }
        private void newClientButton_Click(object sender, EventArgs e)
        {
            ClientForm client = new ClientForm();
            client.ShowDialog();
        }

        private void reportButton1_Click(object sender, EventArgs e)
        {
            if(managerIsAdmin)
            {
                ReportForm1 report = new ReportForm1();
                report.ShowDialog();
            }
            else
            {
                MessageBox.Show("Only admin can check reports!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void reportButton2_Click(object sender, EventArgs e)
        {
            if (managerIsAdmin)
            {
                ReportForm2 report = new ReportForm2();
                report.ShowDialog();
            }
            else
            {
                MessageBox.Show("Only admin can check reports!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            FindClient();
        }

        private void FindClient()
        {
            if (cardnumTB.Text != string.Empty)
            {
                using (SqlConnection connection = new SqlConnection(LoginForm.ConStr))
                {
                    connection.Open();
                    string clientIdQuery = $@"SELECT Client.Id FROM Client WHERE Client.CardNumber = '{cardnumTB.Text}';";
                    SqlCommand clientIdCommand = new SqlCommand(clientIdQuery, connection);
                    int clientId = Convert.ToInt32(clientIdCommand.ExecuteScalar());

                    ResetForm();
                    ResetFinal();
                    ResetFinalVals();
                    ResetGV();
                    ResetClientInfo();
                    ResetProductInfo();

                    if (clientId == 0)
                    {
                        MessageBox.Show("Client not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        GetClientInfo(clientId);
                        clientNameLabel.Text = clientName + " " + clientLastname;
                        clientBonusLabel.Text = "Bonus: " + clientBonus.ToString("n2");

                        productsTLP.Enabled = true;
                    }
                }
            }
        }

        private bool isPressed = false;
        private void cardnumTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !isPressed)
            {
                isPressed = true;
                FindClient();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.Alt && e.KeyCode == Keys.L && !isPressed)
            {
                isPressed = true;
                tableLayoutPanel26.Visible = !tableLayoutPanel26.Visible;
                if (tableLayoutPanel26.Visible)
                {
                    limitValue.Text = MinLitresForBonus.ToString();
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void cardnumTB_KeyUp(object sender, KeyEventArgs e)
        {
            if (isPressed) isPressed = false;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            tableLayoutPanel26.Visible = false;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            SaveMinLimit();
            if(limitValue.Text == String.Empty)
            {
                MinLitresForBonus = 0;
            }
            else
            {
                MinLitresForBonus = Int32.Parse(limitValue.Text);
            }
            tableLayoutPanel26.Visible = false;
        }

        private void SaveMinLimit()
        {
            LimitValue minLimit = new LimitValue();
            if(limitValue.Text == String.Empty)
            {
                minLimit.MinLimit = 0;
            }
            else
            {
                minLimit.MinLimit = Int32.Parse(limitValue.Text);
            }
            using (StreamWriter file = File.CreateText("limit.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, minLimit);
            }
        }
        private void GetMinLimit()
        {
            using (StreamReader r = new StreamReader("limit.json"))
            {
                string json = r.ReadToEnd();
                LimitValue limit = JsonConvert.DeserializeObject<LimitValue>(json);
                MinLitresForBonus = limit.MinLimit;
            }
        }
    }
}