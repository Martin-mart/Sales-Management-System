namespace Inventory
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.adminDashboard1 = new Inventory.AdminDashboard();
            this.adminAddUser1 = new Inventory.AdminAddUser();
            this.adminAddCategories1 = new Inventory.AdminAddCategories();
            this.adminAddProducts1 = new Inventory.AdminAddProducts();
            this.cashierCustomersForm1 = new Inventory.CashierCustomersForm();
            this.label2 = new System.Windows.Forms.Label();
            this.user_username = new System.Windows.Forms.Label();
            this.Dashboard_btn = new System.Windows.Forms.Button();
            this.addusers_btn = new System.Windows.Forms.Button();
            this.addcategories_btn = new System.Windows.Forms.Button();
            this.addproducts_btn = new System.Windows.Forms.Button();
            this.customers_btn = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Inventory Management System | Admin\'s Portal";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.Firebrick;
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.ForeColor = System.Drawing.SystemColors.Control;
            this.close.Location = new System.Drawing.Point(926, 13);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(42, 23);
            this.close.TabIndex = 2;
            this.close.Text = "X";
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.adminDashboard1);
            this.panel3.Controls.Add(this.adminAddUser1);
            this.panel3.Controls.Add(this.adminAddCategories1);
            this.panel3.Controls.Add(this.adminAddProducts1);
            this.panel3.Controls.Add(this.cashierCustomersForm1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(200, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(780, 557);
            this.panel3.TabIndex = 2;
            // 
            // adminDashboard1
            // 
            this.adminDashboard1.Location = new System.Drawing.Point(0, 0);
            this.adminDashboard1.Name = "adminDashboard1";
            this.adminDashboard1.Size = new System.Drawing.Size(780, 558);
            this.adminDashboard1.TabIndex = 4;
            // 
            // adminAddUser1
            // 
            this.adminAddUser1.Location = new System.Drawing.Point(1, 0);
            this.adminAddUser1.Name = "adminAddUser1";
            this.adminAddUser1.Size = new System.Drawing.Size(776, 535);
            this.adminAddUser1.TabIndex = 3;
            // 
            // adminAddCategories1
            // 
            this.adminAddCategories1.Location = new System.Drawing.Point(3, 3);
            this.adminAddCategories1.Name = "adminAddCategories1";
            this.adminAddCategories1.Size = new System.Drawing.Size(776, 535);
            this.adminAddCategories1.TabIndex = 2;
            this.adminAddCategories1.Load += new System.EventHandler(this.adminAddCategories1_Load);
            // 
            // adminAddProducts1
            // 
            this.adminAddProducts1.Location = new System.Drawing.Point(1, 0);
            this.adminAddProducts1.Name = "adminAddProducts1";
            this.adminAddProducts1.Size = new System.Drawing.Size(776, 535);
            this.adminAddProducts1.TabIndex = 1;
            // 
            // cashierCustomersForm1
            // 
            this.cashierCustomersForm1.Location = new System.Drawing.Point(1, 0);
            this.cashierCustomersForm1.Name = "cashierCustomersForm1";
            this.cashierCustomersForm1.Size = new System.Drawing.Size(776, 535);
            this.cashierCustomersForm1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Welcome !";
            // 
            // user_username
            // 
            this.user_username.AutoSize = true;
            this.user_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_username.ForeColor = System.Drawing.Color.Black;
            this.user_username.Location = new System.Drawing.Point(87, 92);
            this.user_username.Name = "user_username";
            this.user_username.Size = new System.Drawing.Size(49, 18);
            this.user_username.TabIndex = 10;
            this.user_username.Text = "Admin";
            // 
            // Dashboard_btn
            // 
            this.Dashboard_btn.BackColor = System.Drawing.Color.Turquoise;
            this.Dashboard_btn.FlatAppearance.BorderSize = 0;
            this.Dashboard_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Dashboard_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dashboard_btn.Location = new System.Drawing.Point(10, 133);
            this.Dashboard_btn.Name = "Dashboard_btn";
            this.Dashboard_btn.Size = new System.Drawing.Size(176, 27);
            this.Dashboard_btn.TabIndex = 11;
            this.Dashboard_btn.Text = "Dashboard";
            this.Dashboard_btn.UseVisualStyleBackColor = false;
            this.Dashboard_btn.Click += new System.EventHandler(this.Dashboard_btn_Click);
            // 
            // addusers_btn
            // 
            this.addusers_btn.BackColor = System.Drawing.Color.Turquoise;
            this.addusers_btn.FlatAppearance.BorderSize = 0;
            this.addusers_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addusers_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addusers_btn.Location = new System.Drawing.Point(4, 182);
            this.addusers_btn.Name = "addusers_btn";
            this.addusers_btn.Size = new System.Drawing.Size(180, 27);
            this.addusers_btn.TabIndex = 12;
            this.addusers_btn.Text = "Add Users";
            this.addusers_btn.UseVisualStyleBackColor = false;
            this.addusers_btn.Click += new System.EventHandler(this.addusers_btn_Click);
            // 
            // addcategories_btn
            // 
            this.addcategories_btn.BackColor = System.Drawing.Color.Turquoise;
            this.addcategories_btn.FlatAppearance.BorderSize = 0;
            this.addcategories_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addcategories_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addcategories_btn.Location = new System.Drawing.Point(6, 228);
            this.addcategories_btn.Name = "addcategories_btn";
            this.addcategories_btn.Size = new System.Drawing.Size(180, 27);
            this.addcategories_btn.TabIndex = 13;
            this.addcategories_btn.Text = "Add Categories";
            this.addcategories_btn.UseVisualStyleBackColor = false;
            this.addcategories_btn.Click += new System.EventHandler(this.addcategories_btn_Click);
            // 
            // addproducts_btn
            // 
            this.addproducts_btn.BackColor = System.Drawing.Color.Turquoise;
            this.addproducts_btn.FlatAppearance.BorderSize = 0;
            this.addproducts_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addproducts_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addproducts_btn.Location = new System.Drawing.Point(7, 278);
            this.addproducts_btn.Name = "addproducts_btn";
            this.addproducts_btn.Size = new System.Drawing.Size(177, 27);
            this.addproducts_btn.TabIndex = 14;
            this.addproducts_btn.Text = "Add Products";
            this.addproducts_btn.UseVisualStyleBackColor = false;
            this.addproducts_btn.Click += new System.EventHandler(this.addproducts_btn_Click);
            // 
            // customers_btn
            // 
            this.customers_btn.BackColor = System.Drawing.Color.Turquoise;
            this.customers_btn.FlatAppearance.BorderSize = 0;
            this.customers_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customers_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customers_btn.Location = new System.Drawing.Point(7, 331);
            this.customers_btn.Name = "customers_btn";
            this.customers_btn.Size = new System.Drawing.Size(181, 27);
            this.customers_btn.TabIndex = 15;
            this.customers_btn.Text = "Customers";
            this.customers_btn.UseVisualStyleBackColor = false;
            this.customers_btn.Click += new System.EventHandler(this.customers_btn_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Teal;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aquamarine;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(12, 506);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(180, 27);
            this.button5.TabIndex = 16;
            this.button5.Text = "Logout";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Aquamarine;
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.customers_btn);
            this.panel2.Controls.Add(this.addproducts_btn);
            this.panel2.Controls.Add(this.addcategories_btn);
            this.panel2.Controls.Add(this.addusers_btn);
            this.panel2.Controls.Add(this.Dashboard_btn);
            this.panel2.Controls.Add(this.user_username);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 557);
            this.panel2.TabIndex = 1;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 602);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label user_username;
        private System.Windows.Forms.Button Dashboard_btn;
        private System.Windows.Forms.Button addusers_btn;
        private System.Windows.Forms.Button addcategories_btn;
        private System.Windows.Forms.Button addproducts_btn;
        private System.Windows.Forms.Button customers_btn;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel2;
        private AdminAddCategories adminAddCategories1;
        private AdminAddProducts adminAddProducts1;
        private CashierCustomersForm cashierCustomersForm1;
        private AdminDashboard adminDashboard1;
        private AdminAddUser adminAddUser1;
    }
}