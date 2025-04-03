using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;

namespace Inventory
{
    public partial class Form1 : Form
    {
        public static string username;
        private SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyNewDatabase;Integrated Security=True;TrustServerCertificate=True;");

        public Form1()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void updatepass_Click(object sender, EventArgs e)
        {
            Update_password updateForm = new Update_password();
            updateForm.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            RegisterForm regForm = new RegisterForm();
            regForm.Show();
            this.Hide();
        }

        private void login_showpassword_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_showpassword.Checked ? '\0' : '*';
        }

        private void label2_Click(object sender, EventArgs e)
        {
            RegisterForm regForm = new RegisterForm();
            regForm.Show();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                string query = "SELECT password, role FROM users WHERE username = @usern AND status = @status";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@usern", login_username.Text.Trim());
                    cmd.Parameters.AddWithValue("@status", "Active");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPassword = reader["password"].ToString();  // Hashed password from DB
                            string userRole = reader["role"].ToString();

                            if (BCrypt.Net.BCrypt.Verify(login_password.Text.Trim(), storedPassword))
                            {
                                username = login_username.Text.Trim(); // Set the username
                                MessageBox.Show("Login Successful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                OpenUserForm(userRole);
                            }
                            else
                            {
                                MessageBox.Show("Incorrect password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("User not found or inactive.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Failed! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }

        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        private void OpenUserForm(string role)
        {
            if (role == "Admin")
            {
                MainForm mForm = new MainForm();
                mForm.Show();
                this.Hide();
            }
            else if (role == "Cashier")
            {
                CashierMainForm cmForm = new CashierMainForm();
                cmForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid role assigned to the user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}