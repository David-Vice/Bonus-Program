namespace Bonus_Program
{
    partial class ReportForm2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.totalPriceLabel = new System.Windows.Forms.Label();
            this.totalLabelNoCh = new System.Windows.Forms.Label();
            this.totalLitresLabelNoCh = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.paymentLabel = new System.Windows.Forms.Label();
            this.bonusLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.currentBonusLabel = new System.Windows.Forms.Label();
            this.usedBonusLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.newBonusLabel = new System.Windows.Forms.Label();
            this.backButton = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.keyboardOnButton = new DevExpress.XtraEditors.SimpleButton();
            this.showButton = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.keyboardOffButton = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.managerTB = new System.Windows.Forms.TextBox();
            this.cardTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.clientTB = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // totalPriceLabel
            // 
            this.totalPriceLabel.AutoSize = true;
            this.totalPriceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalPriceLabel.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.totalPriceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.totalPriceLabel.Location = new System.Drawing.Point(190, 102);
            this.totalPriceLabel.Name = "totalPriceLabel";
            this.totalPriceLabel.Size = new System.Drawing.Size(223, 34);
            this.totalPriceLabel.TabIndex = 4;
            this.totalPriceLabel.Text = "0.00 AZN";
            this.totalPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // totalLabelNoCh
            // 
            this.totalLabelNoCh.AutoSize = true;
            this.totalLabelNoCh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalLabelNoCh.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.totalLabelNoCh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.totalLabelNoCh.Location = new System.Drawing.Point(3, 102);
            this.totalLabelNoCh.Name = "totalLabelNoCh";
            this.totalLabelNoCh.Size = new System.Drawing.Size(181, 34);
            this.totalLabelNoCh.TabIndex = 3;
            this.totalLabelNoCh.Text = "Total:";
            this.totalLabelNoCh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // totalLitresLabelNoCh
            // 
            this.totalLitresLabelNoCh.AutoSize = true;
            this.totalLitresLabelNoCh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalLitresLabelNoCh.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.totalLitresLabelNoCh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.totalLitresLabelNoCh.Location = new System.Drawing.Point(3, 0);
            this.totalLitresLabelNoCh.Name = "totalLitresLabelNoCh";
            this.totalLitresLabelNoCh.Size = new System.Drawing.Size(181, 34);
            this.totalLitresLabelNoCh.TabIndex = 1;
            this.totalLitresLabelNoCh.Text = "Collected bonus:";
            this.totalLitresLabelNoCh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel5.Controls.Add(this.paymentLabel, 1, 4);
            this.tableLayoutPanel5.Controls.Add(this.bonusLabel, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel5.Controls.Add(this.currentBonusLabel, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.usedBonusLabel, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.totalPriceLabel, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.totalLabelNoCh, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.newBonusLabel, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.totalLitresLabelNoCh, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 706);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 5;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(416, 170);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // paymentLabel
            // 
            this.paymentLabel.AutoSize = true;
            this.paymentLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentLabel.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.paymentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.paymentLabel.Location = new System.Drawing.Point(190, 136);
            this.paymentLabel.Name = "paymentLabel";
            this.paymentLabel.Size = new System.Drawing.Size(223, 34);
            this.paymentLabel.TabIndex = 15;
            this.paymentLabel.Text = "0.00 AZN";
            this.paymentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bonusLabel
            // 
            this.bonusLabel.AutoSize = true;
            this.bonusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bonusLabel.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.bonusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bonusLabel.Location = new System.Drawing.Point(3, 68);
            this.bonusLabel.Name = "bonusLabel";
            this.bonusLabel.Size = new System.Drawing.Size(181, 34);
            this.bonusLabel.TabIndex = 14;
            this.bonusLabel.Text = "Current bonus:";
            this.bonusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(3, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 34);
            this.label5.TabIndex = 13;
            this.label5.Text = "Payment:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // currentBonusLabel
            // 
            this.currentBonusLabel.AutoSize = true;
            this.currentBonusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentBonusLabel.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.currentBonusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.currentBonusLabel.Location = new System.Drawing.Point(190, 68);
            this.currentBonusLabel.Name = "currentBonusLabel";
            this.currentBonusLabel.Size = new System.Drawing.Size(223, 34);
            this.currentBonusLabel.TabIndex = 8;
            this.currentBonusLabel.Text = "0.00 AZN";
            this.currentBonusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // usedBonusLabel
            // 
            this.usedBonusLabel.AutoSize = true;
            this.usedBonusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usedBonusLabel.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.usedBonusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.usedBonusLabel.Location = new System.Drawing.Point(190, 34);
            this.usedBonusLabel.Name = "usedBonusLabel";
            this.usedBonusLabel.Size = new System.Drawing.Size(223, 34);
            this.usedBonusLabel.TabIndex = 7;
            this.usedBonusLabel.Text = "0.00 AZN";
            this.usedBonusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(3, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 34);
            this.label4.TabIndex = 5;
            this.label4.Text = "Used bonus:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // newBonusLabel
            // 
            this.newBonusLabel.AutoSize = true;
            this.newBonusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newBonusLabel.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.newBonusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.newBonusLabel.Location = new System.Drawing.Point(190, 0);
            this.newBonusLabel.Name = "newBonusLabel";
            this.newBonusLabel.Size = new System.Drawing.Size(223, 34);
            this.newBonusLabel.TabIndex = 2;
            this.newBonusLabel.Text = "0.00 AZN";
            this.newBonusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // backButton
            // 
            this.backButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.backButton.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.backButton.Appearance.Options.UseBackColor = true;
            this.backButton.Appearance.Options.UseFont = true;
            this.backButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backButton.Location = new System.Drawing.Point(10, 3);
            this.backButton.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(185, 56);
            this.backButton.TabIndex = 8;
            this.backButton.Text = "Back";
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 55);
            this.label2.TabIndex = 8;
            this.label2.Text = "Client:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateTimePicker2.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dateTimePicker2.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dateTimePicker2.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(127, 64);
            this.dateTimePicker2.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(251, 36);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 55);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ending:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Beginning:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dateTimePicker1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(127, 9);
            this.dateTimePicker1.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(251, 36);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // keyboardOnButton
            // 
            this.keyboardOnButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.keyboardOnButton.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.keyboardOnButton.Appearance.Options.UseBackColor = true;
            this.keyboardOnButton.Appearance.Options.UseFont = true;
            this.keyboardOnButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyboardOnButton.Location = new System.Drawing.Point(10, 65);
            this.keyboardOnButton.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.keyboardOnButton.Name = "keyboardOnButton";
            this.keyboardOnButton.Size = new System.Drawing.Size(185, 56);
            this.keyboardOnButton.TabIndex = 10;
            this.keyboardOnButton.Text = "Keyboard On";
            this.keyboardOnButton.Click += new System.EventHandler(this.turnOnKeyboard_Click);
            // 
            // showButton
            // 
            this.showButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.showButton.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.showButton.Appearance.Options.UseBackColor = true;
            this.showButton.Appearance.Options.UseFont = true;
            this.showButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showButton.Location = new System.Drawing.Point(215, 3);
            this.showButton.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(185, 56);
            this.showButton.TabIndex = 9;
            this.showButton.Text = "Show";
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel4.SetColumnSpan(this.tableLayoutPanel6, 2);
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.keyboardOffButton, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.keyboardOnButton, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.showButton, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.backButton, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 278);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(410, 416);
            this.tableLayoutPanel6.TabIndex = 10;
            // 
            // keyboardOffButton
            // 
            this.keyboardOffButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.keyboardOffButton.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.keyboardOffButton.Appearance.Options.UseBackColor = true;
            this.keyboardOffButton.Appearance.Options.UseFont = true;
            this.keyboardOffButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyboardOffButton.Location = new System.Drawing.Point(215, 65);
            this.keyboardOffButton.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.keyboardOffButton.Name = "keyboardOffButton";
            this.keyboardOffButton.Size = new System.Drawing.Size(185, 56);
            this.keyboardOffButton.TabIndex = 11;
            this.keyboardOffButton.Text = "Keyboard Off";
            this.keyboardOffButton.Click += new System.EventHandler(this.turnOffKeyboard_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel4.Controls.Add(this.managerTB, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.cardTB, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.dateTimePicker2, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.dateTimePicker1, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.clientTB, 1, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(416, 697);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // managerTB
            // 
            this.managerTB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.managerTB.Font = new System.Drawing.Font("Tahoma", 14F);
            this.managerTB.Location = new System.Drawing.Point(127, 229);
            this.managerTB.Name = "managerTB";
            this.managerTB.Size = new System.Drawing.Size(251, 36);
            this.managerTB.TabIndex = 15;
            // 
            // cardTB
            // 
            this.cardTB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cardTB.Font = new System.Drawing.Font("Tahoma", 14F);
            this.cardTB.Location = new System.Drawing.Point(127, 174);
            this.cardTB.Name = "cardTB";
            this.cardTB.Size = new System.Drawing.Size(251, 36);
            this.cardTB.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 55);
            this.label7.TabIndex = 12;
            this.label7.Text = "Manager:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 55);
            this.label6.TabIndex = 11;
            this.label6.Text = "Card:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // clientTB
            // 
            this.clientTB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.clientTB.Font = new System.Drawing.Font("Tahoma", 14F);
            this.clientTB.Location = new System.Drawing.Point(127, 119);
            this.clientTB.Name = "clientTB";
            this.clientTB.Size = new System.Drawing.Size(251, 36);
            this.clientTB.TabIndex = 13;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.dataGridView, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 879F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(991, 879);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(3, 3);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(985, 873);
            this.dataGridView.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1000, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(422, 879);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1425, 885);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // ReportForm2
            // 
            this.Appearance.BackColor = System.Drawing.Color.Silver;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1425, 885);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportForm2";
            this.Text = "ReportForm2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label totalPriceLabel;
        private System.Windows.Forms.Label totalLabelNoCh;
        private System.Windows.Forms.Label totalLitresLabelNoCh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label newBonusLabel;
        private DevExpress.XtraEditors.SimpleButton backButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private DevExpress.XtraEditors.SimpleButton keyboardOnButton;
        private DevExpress.XtraEditors.SimpleButton showButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private DevExpress.XtraEditors.SimpleButton keyboardOffButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label currentBonusLabel;
        private System.Windows.Forms.Label usedBonusLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox clientTB;
        private System.Windows.Forms.TextBox managerTB;
        private System.Windows.Forms.TextBox cardTB;
        private System.Windows.Forms.Label bonusLabel;
        private System.Windows.Forms.Label paymentLabel;
    }
}