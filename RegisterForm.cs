using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BCrypt.Net; // Include BCrypt for hashing

namespace Inventory
{
    public partial class RegisterForm : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyNewDatabase;Integrated Security=True;TrustServerCertificate=True;");

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void register_label_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Hide();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            if (register_username.Text == "" || register_password.Text == "" || register_cpassword.Text == "")
            {
                MessageBox.Show("Please fill all the empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (register_password.Text.Length < 8 || register_cpassword.Text.Length < 8)
            {
                MessageBox.Show("Invalid Password, at least 8 characters are required", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (register_password.Text != register_cpassword.Text)
            {
                MessageBox.Show("Passwords do not match!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    connect.Open();

                    string checkUsername = "SELECT * FROM users WHERE username = @usern";
                    using (SqlCommand cmd = new SqlCommand(checkUsername, connect))
                    {
                        cmd.Parameters.AddWithValue("@usern", register_username.Text.Trim());

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            MessageBox.Show(register_username.Text.Trim() + " is already taken", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // Hash the password before storing it
                            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(register_password.Text.Trim());

                            string insertData = "INSERT INTO users (username, password, role, status, date) " +
                                                "VALUES(@usern, @pass, @role, @status, @date)";
                            using (SqlCommand insertD = new SqlCommand(insertData, connect))
                            {
                                insertD.Parameters.AddWithValue("@usern", register_username.Text.Trim());
                                insertD.Parameters.AddWithValue("@pass", hashedPassword); // Store the hashed password
                                insertD.Parameters.AddWithValue("@role", "Cashier");
                                insertD.Parameters.AddWithValue("@status", "Approval");

                                DateTime today = DateTime.Today;
                                insertD.Parameters.AddWithValue("@date", today);

                                insertD.ExecuteNonQuery();

                                MessageBox.Show("Registered successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Form1 loginForm = new Form1();
                                loginForm.Show();
                                this.Hide();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection Failed! " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        public bool checkConnection()
        {
            return connect.State == ConnectionState.Closed;
        }

        private void register_showpassword_CheckedChanged(object sender, EventArgs e)
        {
            register_password.PasswordChar = register_showpassword.Checked ? '\0' : '*';
            register_cpassword.PasswordChar = register_showpassword.Checked ? '\0' : '*';
        }
    }
}
