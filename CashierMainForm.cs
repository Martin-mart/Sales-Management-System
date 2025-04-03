using System;
using System.Windows.Forms;

namespace Inventory
{
    public partial class CashierMainForm : Form
    {
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Button logoutBtn;
        private Button customers_btn;
        private Button addProducts_btn;
        private Button order_btn;
        private Button dashboard_btn;
        private Label user_username;
        private Label label2;
        private PictureBox pictureBox3;
        private CashierOrder cashierOrder1;
        private CashierCustomersForm cashierCustomersForm1;
        private AdminAddProducts adminAddProducts1;
        private AdminDashboard adminDashboard1;
        private CashierOrder cashierOrder2;
        private Button close;

        public CashierMainForm()
        {
            InitializeComponent();
            displayUsername();
        }
        public void displayUsername()
        {
            if (string.IsNullOrEmpty(Form1.username))
            {
                MessageBox.Show("Username is not set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string username = Form1.username.Substring(0, 1).ToUpper() + Form1.username.Substring(1);
            user_username.Text = username;
        }
        private void cashierOrder2_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.customers_btn = new System.Windows.Forms.Button();
            this.addProducts_btn = new System.Windows.Forms.Button();
            this.order_btn = new System.Windows.Forms.Button();
            this.dashboard_btn = new System.Windows.Forms.Button();
            this.user_username = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.adminAddProducts1 = new Inventory.AdminAddProducts();
            this.cashierCustomersForm1 = new Inventory.CashierCustomersForm();
            this.cashierOrder1 = new Inventory.CashierOrder();
            this.adminDashboard1 = new Inventory.AdminDashboard();
            this.cashierOrder2 = new Inventory.CashierOrder();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(980, 45);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(393, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Inventory Management System | Cashier\'s Portal";
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.Firebrick;
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.ForeColor = System.Drawing.SystemColors.Control;
            this.close.Location = new System.Drawing.Point(916, 13);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(42, 23);
            this.close.TabIndex = 2;
            this.close.Text = "X";
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Aquamarine;
            this.panel2.Controls.Add(this.logoutBtn);
            this.panel2.Controls.Add(this.customers_btn);
            this.panel2.Controls.Add(this.addProducts_btn);
            this.panel2.Controls.Add(this.order_btn);
            this.panel2.Controls.Add(this.dashboard_btn);
            this.panel2.Controls.Add(this.user_username);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 557);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // logoutBtn
            // 
            this.logoutBtn.BackColor = System.Drawing.Color.Teal;
            this.logoutBtn.FlatAppearance.BorderSize = 0;
            this.logoutBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.logoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.Location = new System.Drawing.Point(12, 506);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(180, 27);
            this.logoutBtn.TabIndex = 16;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = false;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // customers_btn
            // 
            this.customers_btn.BackColor = System.Drawing.Color.Turquoise;
            this.customers_btn.FlatAppearance.BorderSize = 0;
            this.customers_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customers_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customers_btn.Location = new System.Drawing.Point(13, 259);
            this.customers_btn.Name = "customers_btn";
            this.customers_btn.Size = new System.Drawing.Size(171, 27);
            this.customers_btn.TabIndex = 15;
            this.customers_btn.Text = "Customers";
            this.customers_btn.UseVisualStyleBackColor = false;
            this.customers_btn.Click += new System.EventHandler(this.customers_btn_Click);
            // 
            // addProducts_btn
            // 
            this.addProducts_btn.BackColor = System.Drawing.Color.Turquoise;
            this.addProducts_btn.FlatAppearance.BorderSize = 0;
            this.addProducts_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addProducts_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addProducts_btn.Location = new System.Drawing.Point(12, 205);
            this.addProducts_btn.Name = "addProducts_btn";
            this.addProducts_btn.Size = new System.Drawing.Size(171, 27);
            this.addProducts_btn.TabIndex = 14;
            this.addProducts_btn.Text = "Add Products";
            this.addProducts_btn.UseVisualStyleBackColor = false;
            this.addProducts_btn.Click += new System.EventHandler(this.addProducts_btn_Click);
            // 
            // order_btn
            // 
            this.order_btn.BackColor = System.Drawing.Color.Turquoise;
            this.order_btn.FlatAppearance.BorderSize = 0;
            this.order_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.order_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.order_btn.Location = new System.Drawing.Point(13, 316);
            this.order_btn.Name = "order_btn";
            this.order_btn.Size = new System.Drawing.Size(171, 27);
            this.order_btn.TabIndex = 13;
            this.order_btn.Text = "Order";
            this.order_btn.UseVisualStyleBackColor = false;
            this.order_btn.Click += new System.EventHandler(this.order_btn_Click);
            // 
            // dashboard_btn
            // 
            this.dashboard_btn.BackColor = System.Drawing.Color.Turquoise;
            this.dashboard_btn.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.dashboard_btn.FlatAppearance.BorderSize = 0;
            this.dashboard_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboard_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard_btn.Location = new System.Drawing.Point(13, 155);
            this.dashboard_btn.Name = "dashboard_btn";
            this.dashboard_btn.Size = new System.Drawing.Size(171, 27);
            this.dashboard_btn.TabIndex = 11;
            this.dashboard_btn.Text = "Dashboard";
            this.dashboard_btn.UseVisualStyleBackColor = false;
            this.dashboard_btn.Click += new System.EventHandler(this.dashboard_btn_Click);
            // 
            // user_username
            // 
            this.user_username.AutoSize = true;
            this.user_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_username.ForeColor = System.Drawing.Color.Black;
            this.user_username.Location = new System.Drawing.Point(99, 108);
            this.user_username.Name = "user_username";
            this.user_username.Size = new System.Drawing.Size(59, 18);
            this.user_username.TabIndex = 10;
            this.user_username.Text = "Cashier";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(24, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Welcome !";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Inventory.Properties.Resources.user;
            this.pictureBox3.Location = new System.Drawing.Point(80, 22);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(56, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // adminAddProducts1
            // 
            this.adminAddProducts1.Location = new System.Drawing.Point(198, 43);
            this.adminAddProducts1.Name = "adminAddProducts1";
            this.adminAddProducts1.Size = new System.Drawing.Size(776, 535);
            this.adminAddProducts1.TabIndex = 4;
            // 
            // cashierCustomersForm1
            // 
            this.cashierCustomersForm1.Location = new System.Drawing.Point(206, 45);
            this.cashierCustomersForm1.Name = "cashierCustomersForm1";
            this.cashierCustomersForm1.Size = new System.Drawing.Size(776, 545);
            this.cashierCustomersForm1.TabIndex = 3;
            // 
            // cashierOrder1
            // 
            this.cashierOrder1.Location = new System.Drawing.Point(201, 45);
            this.cashierOrder1.Name = "cashierOrder1";
            this.cashierOrder1.Size = new System.Drawing.Size(776, 557);
            this.cashierOrder1.TabIndex = 3;
            // 
            // adminDashboard1
            // 
            this.adminDashboard1.Location = new System.Drawing.Point(198, 45);
            this.adminDashboard1.Name = "adminDashboard1";
            this.adminDashboard1.Size = new System.Drawing.Size(784, 561);
            this.adminDashboard1.TabIndex = 5;
            // 
            // cashierOrder2
            // 
            this.cashierOrder2.Location = new System.Drawing.Point(204, 45);
            this.cashierOrder2.Name = "cashierOrder2";
            this.cashierOrder2.Size = new System.Drawing.Size(776, 538);
            this.cashierOrder2.TabIndex = 6;
            // 
            // CashierMainForm
            // 
            this.ClientSize = new System.Drawing.Size(980, 602);
            this.Controls.Add(this.adminDashboard1);
            this.Controls.Add(this.cashierCustomersForm1);
            this.Controls.Add(this.adminAddProducts1);
            this.Controls.Add(this.cashierOrder2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CashierMainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        private void customers_btn_Click(object sender, EventArgs e)
        {
            cashierOrder1.Visible = false;
            cashierCustomersForm1.Visible = true;
            adminAddProducts1.Visible = false;
            adminDashboard1.Visible = false;

            CashierCustomersForm ccForm = cashierCustomersForm1 as CashierCustomersForm;
            if (ccForm != null)
            {
                ccForm.refreshData();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirmation Message"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 login_form = new Form1();
                login_form.Show();

                this.Hide();
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close?", "Confirmation Message"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
           cashierOrder1.Visible = false;
           cashierCustomersForm1.Visible = false;
           adminAddProducts1.Visible = false;
           adminDashboard1.Visible = true;

            AdminDashboard adForm = adminDashboard1 as AdminDashboard;
            if (adForm != null)
            {
                adForm.displayTotalIncome();
            }

        }

        private void addProducts_btn_Click(object sender, EventArgs e)
        {
            cashierOrder1.Visible = false;
            cashierCustomersForm1.Visible = false;
            adminAddProducts1.Visible = true;
            adminDashboard1.Visible = false;

            AdminAddProducts aapForm = adminAddProducts1 as AdminAddProducts;
            if (aapForm != null)
            {
                aapForm.refreshData();
            }
        }

        private void order_btn_Click(object sender, EventArgs e)
        {
            cashierOrder1.Visible = true;
            cashierCustomersForm1.Visible = false;
            adminAddProducts1.Visible = false;
            adminDashboard1.Visible = false;
        }
    }
}
