using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System.IO;
using Bonus_Program.Data;

namespace Bonus_Program
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        private TextBox focusedTextbox = null;
        public float MinPriceForBonus { get; set; }
        private const float MinBonusRedeem = 1f;

        private Label flashLabel;
        private System.Windows.Forms.Timer flashTimer;

        private readonly bool _isAdmin;
        private ScannerInputHandler _scannerHandler;

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

        private int clientId;
        private string clientName;
        private string clientLastname;
        private string clientCardNumber;
        private float clientBonus;
        private void GetClientInfo(int clientId)
        {
            using (var db = new BonusDbContext())
            {
                var client = db.Clients.Find(clientId);
                if (client != null)
                {
                    this.clientId = client.Id;
                    clientName = client.Name;
                    clientLastname = client.Lastname;
                    clientCardNumber = client.CardNumber;
                    clientBonus = (float)client.Bonus;
                }
            }
        }
        private void ResetClientInfo()
        {
            clientId = 0;
            clientName = string.Empty;
            clientLastname = string.Empty;
            clientCardNumber = string.Empty;
            clientBonus = -1;
        }

        private int managerId;
        private string managerName;
        private string managerLastname;
        private string managerLogin;
        private bool managerIsAdmin;
        private void GetManagerInfo(int managerId)
        {
            using (var db = new BonusDbContext())
            {
                var manager = db.Managers.Find(managerId);
                if (manager != null)
                {
                    this.managerId = manager.Id;
                    managerName = manager.Name;
                    managerLastname = manager.Lastname;
                    managerLogin = manager.Login;
                    managerIsAdmin = manager.Admin;
                }
            }
        }
        private void ResetManagerInfo()
        {
            managerId = 0;
            managerName = string.Empty;
            managerLastname = string.Empty;
            managerLogin = string.Empty;
            managerIsAdmin = false;
        }

        private int productId;
        private string productFullname;
        private float productPrice;
        private float productBonusPercent;
        private void GetProductInfo(int productId)
        {
            using (var db = new BonusDbContext())
            {
                var product = db.Products.Find(productId);
                if (product != null)
                {
                    this.productId = product.Id;
                    productFullname = product.Fullname;
                    productPrice = (float)product.Price;
                    productBonusPercent = (float)product.BonusPercent;
                }
            }
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
            _isAdmin = false;
        }
        public MainForm(int managerId, bool isAdmin)
        {
            InitializeComponent();
            InitializeGV();
            ResetForm();
            ResetFinal();
            ResetManagerInfo();
            ResetClientInfo();
            ResetProductInfo();

            _isAdmin = isAdmin;
            GetManagerInfo(managerId);
            ConfigureForRole();
        }

        private void ConfigureForRole()
        {
            if (!_isAdmin)
            {
                cardnumTB.ReadOnly = true;
                _scannerHandler = new ScannerInputHandler(cardnumTB, () => FindClient());

                cardnumTB.KeyDown += (s, ev) =>
                {
                    if (ev.KeyCode == Keys.Back || ev.KeyCode == Keys.Delete)
                    {
                        cardnumTB.Text = string.Empty;
                        ResetForm();
                        ResetGV();
                        ResetFinal();
                        ResetFinalVals();
                        ResetClientInfo();
                        ResetProductInfo();
                    }
                };
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (managerId != 0)
            {
                cashierLabel.Text = "Cashier: " + managerName + " " + managerLastname;
                statusLabel.Text = _isAdmin ? "Status: Admin" : "Status: Cashier";
            }
            GetMinLimit();
            InitFlashMessage();
        }

        private void InitFlashMessage()
        {
            flashLabel = new Label
            {
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Tahoma", 12F, FontStyle.Bold),
                BackColor = Color.FromArgb(255, 255, 192),
                ForeColor = Color.Black,
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false,
                Size = new Size(280, 40),
                Location = new Point((this.ClientSize.Width - 280) / 2, 12),
                Anchor = AnchorStyles.Top,
            };
            this.Controls.Add(flashLabel);
            flashLabel.BringToFront();

            flashTimer = new System.Windows.Forms.Timer { Interval = 2000 };
            flashTimer.Tick += FlashTimer_Tick;
        }

        private void FlashTimer_Tick(object sender, EventArgs e)
        {
            flashTimer.Stop();
            flashLabel.Visible = false;
        }

        private void FlashMessage(string text)
        {
            flashLabel.Text = text;
            flashLabel.Visible = true;
            flashLabel.BringToFront();
            flashTimer.Stop();
            flashTimer.Start();
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
            string buttonText = (sender as SimpleButton).Text;
            using (var db = new BonusDbContext())
            {
                var product = db.Products.FirstOrDefault(p => p.Fullname == buttonText);

                ResetProductPartForm();
                ResetSubtotalPartForm();
                ResetProductInfo();
                quantTLP.Enabled = false;

                if (product == null)
                {
                    MessageBox.Show("No such product in DB!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    GetProductInfo(product.Id);
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
            if (finalUseBonusTB.Text == string.Empty)
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

            if (total > 0)
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
            using (var db = new BonusDbContext())
            {
                for (int i = 0; i < currentGV.Rows.Count; i++)
                {
                    float subtotal = Convert.ToSingle(currentGV.Rows[i].Cells["Total"].Value.ToString());
                    string currentProductName = currentGV.Rows[i].Cells["Product"].Value.ToString();
                    var product = db.Products.FirstOrDefault(p => p.Fullname == currentProductName);
                    if (product != null)
                    {
                        float productPercent = (float)product.BonusPercent;
                        finalNewBonus += (subtotal - (subtotal / finalTotal * useBonus)) * (productPercent / 100);
                    }
                }
            }
            newBonus = finalNewBonus;
            if (clientName.ToLower().Contains("noname") || clientLastname.ToLower().Contains("noname") || total < MinPriceForBonus) newBonus = 0;

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
            if (currentGV.Rows.Count <= 0)
            {
                MessageBox.Show("No products in list!", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (useBonus > clientBonus)
            {
                MessageBox.Show("Too much bonus!", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (payment < 0)
            {
                MessageBox.Show("Payment can't be less than 0!", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (useBonus > 0 && useBonus < MinBonusRedeem)
            {
                FlashMessage("Below the limit!");
            }
            else
            {
                PerformTransaction();
            }
        }

        private void PerformTransaction()
        {
            bool isNoname = clientName.ToLower().Contains("noname") || clientLastname.ToLower().Contains("noname");
            decimal actualNewBonus = isNoname || total < MinPriceForBonus ? 0m : (decimal)newBonus;
            decimal newClientBonus = (decimal)clientBonus - (decimal)useBonus + actualNewBonus;

            using (var db = new BonusDbContext())
            {
                var client = db.Clients.Find(clientId);
                if (client == null) return;

                client.Bonus = newClientBonus;

                var bonusTx = new Models.BonusTransaction
                {
                    ClientId = clientId,
                    ManagerId = managerId,
                    UsedBonus = (decimal)useBonus,
                    NewBonus = actualNewBonus,
                    Payed = (decimal)payment,
                    Total = (decimal)total,
                    Date = DateTime.Now
                };
                db.BonusTransactions.Add(bonusTx);
                db.SaveChanges();

                for (int i = 0; i < currentGV.Rows.Count; i++)
                {
                    string productForDb = currentGV.Rows[i].Cells["Product"].Value.ToString();
                    float quantForDb = Convert.ToSingle(currentGV.Rows[i].Cells["Litres"].Value.ToString());
                    float totalForDb = Convert.ToSingle(currentGV.Rows[i].Cells["Total"].Value.ToString());

                    var product = db.Products.FirstOrDefault(p => p.Fullname == productForDb);
                    if (product != null)
                    {
                        db.Movements.Add(new Models.Movement
                        {
                            ProductId = product.Id,
                            BonusId = bonusTx.Id,
                            Quantity = (decimal)quantForDb,
                            Total = (decimal)totalForDb
                        });
                    }
                }
                db.SaveChanges();
            }

            ResetForm();
            ResetGV();
            ResetFinal();
            ResetFinalVals();
            ResetClientInfo();
            ResetProductInfo();
            cardnumTB.Focus();
        }

        private void newClientButton_Click(object sender, EventArgs e)
        {
            ClientForm client = new ClientForm();
            client.ShowDialog();
        }

        private void reportButton1_Click(object sender, EventArgs e)
        {
            if (_isAdmin)
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
            if (_isAdmin)
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
                string cardNumber = cardnumTB.Text.Trim();
                using (var db = new BonusDbContext())
                {
                    var client = db.Clients.FirstOrDefault(c => c.CardNumber == cardNumber);

                    ResetForm();
                    ResetFinal();
                    ResetFinalVals();
                    ResetGV();
                    ResetClientInfo();
                    ResetProductInfo();

                    if (client == null)
                    {
                        MessageBox.Show("Client not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        GetClientInfo(client.Id);
                        clientNameLabel.Text = clientName + " " + clientLastname;
                        clientBonusLabel.Text = "Bonus: " + clientBonus.ToString("n2");
                        cardnumTB.Text = cardNumber;
                        productsTLP.Enabled = true;
                    }
                }
            }
        }

        private bool isPressed = false;
        private void cardnumTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (_isAdmin)
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
                        limitValue.Text = MinPriceForBonus.ToString("n2");
                    }
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            else
            {
                if (e.Control && e.Alt && e.KeyCode == Keys.L && !isPressed)
                {
                    isPressed = true;
                    tableLayoutPanel26.Visible = !tableLayoutPanel26.Visible;
                    if (tableLayoutPanel26.Visible)
                    {
                        limitValue.Text = MinPriceForBonus.ToString("n2");
                    }
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
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
            if (limitValue.Text == String.Empty)
            {
                MinPriceForBonus = 0;
            }
            else
            {
                MinPriceForBonus = Single.Parse(limitValue.Text);
            }
            tableLayoutPanel26.Visible = false;
        }

        private void SaveMinLimit()
        {
            LimitValue minLimit = new LimitValue();
            if (limitValue.Text == String.Empty)
            {
                minLimit.MinPrice = 0;
            }
            else
            {
                minLimit.MinPrice = Single.Parse(limitValue.Text);
            }
            using (StreamWriter file = File.CreateText("limit.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, minLimit);
            }
        }
        private void GetMinLimit()
        {
            if (!File.Exists("limit.json"))
            {
                MinPriceForBonus = 0;
                return;
            }
            using (StreamReader r = new StreamReader("limit.json"))
            {
                string json = r.ReadToEnd();
                LimitValue limit = JsonConvert.DeserializeObject<LimitValue>(json);
                MinPriceForBonus = limit.MinPrice;
            }
        }
    }
}
