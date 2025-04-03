using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using BCrypt.Net;

namespace Inventory
{
    public partial class Update_password : Form
    {
        public Update_password()
        {
            InitializeComponent();
        }

        // Toggle password visibility
        private void login_showpassword_CheckedChanged(object sender, EventArgs e)
        {
            changelogin_password.PasswordChar = login_showpassword.Checked ? '\0' : '*';
            cupdate_password.PasswordChar = login_showpassword.Checked ? '\0' : '*';
        }

        private void cupdate_password_TextChanged(object sender, EventArgs e)
        {
            // Your logic here (if any)
        }

        private void login_username_TextChanged(object sender, EventArgs e)
        {
            // Your logic here (if any)
        }

        // Navigate to the registration form
        private void register_label_Click(object sender, EventArgs e)
        {
            Form1 upForm = new Form1();
            upForm.Show();
            this.Hide();
        }

        private void changelogin_password_TextChanged(object sender, EventArgs e)
        {
            // Your logic here (if any)
        }

        // Update password button click event
        private void login_btn_Click(object sender, EventArgs e)
        {
            string username = login_username.Text;
            string newPassword = changelogin_password.Text;
            string confirmPassword = cupdate_password.Text;

            // Validate inputs
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if passwords match
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hash the password
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword); // Corrected method call

            // Update password in the database
            try
            {
                // Use your preferred connection string with a verbatim string (@)
                using (SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyNewDatabase;Integrated Security=True;TrustServerCertificate=True;"))
                {
                    connect.Open();

                    // Check if the username exists
                    string checkUserQuery = "SELECT COUNT(*) FROM users WHERE username = @username";
                    using (SqlCommand checkUserCommand = new SqlCommand(checkUserQuery, connect))
                    {
                        checkUserCommand.Parameters.AddWithValue("@username", username);
                        int userCount = (int)checkUserCommand.ExecuteScalar();

                        if (userCount == 0)
                        {
                            MessageBox.Show("Username not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Update the password
                    string updatePasswordQuery = "UPDATE users SET password = @password WHERE username = @username";
                    using (SqlCommand updatePasswordCommand = new SqlCommand(updatePasswordQuery, connect))
                    {
                        updatePasswordCommand.Parameters.AddWithValue("@password", hashedPassword); // Use the hashed password
                        updatePasswordCommand.Parameters.AddWithValue("@username", username);
                        int rowsAffected = updatePasswordCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Show success message
                            MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Open the login form
                            Form1 loginForm = new Form1();
                            loginForm.Show();

                            // Close the current form
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Close the application
        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}