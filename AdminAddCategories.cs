using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Inventory
{
    public partial class AdminAddCategories : UserControl
    {
        
        private readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyNewDatabase;Integrated Security=True;TrustServerCertificate=True;";

        public AdminAddCategories()
        {
            InitializeComponent();
            displayCategoriesData();
        }
        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(refreshData));
                return;
            }
            displayCategoriesData();
        }

        public void displayCategoriesData()
        {
            CategoriesData cData = new CategoriesData();
            List<CategoriesData> listData = cData.AllCategoriesData();
            dataGridView1.DataSource = listData;
        }

        private void addCategories_addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(addCategories_category.Text))
            {
                MessageBox.Show("Please enter a category name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                try
                {
                    connect.Open();

                    // ✅ Check if the category already exists using ExecuteScalar()
                    string checkQuery = "SELECT COUNT(*) FROM categories WHERE category = @cat";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, connect))
                    {
                        checkCmd.Parameters.AddWithValue("@cat", addCategories_category.Text.Trim());

                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show($"Category '{addCategories_category.Text.Trim()}' already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // ✅ Insert the new category
                    string insertQuery = "INSERT INTO categories (category, date) VALUES (@cat, @date)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, connect))
                    {
                        insertCmd.Parameters.AddWithValue("@cat", addCategories_category.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@date", DateTime.Now);

                        int rowsAffected = insertCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            addCategories_category.Clear();
                            displayCategoriesData();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void addCategories_updateBtn_Click(object sender, EventArgs e)
        {
            // Ensure a category is selected
            if (getID == 0)
            {
                MessageBox.Show("Please select a category to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ensure the category name is not empty
            if (string.IsNullOrWhiteSpace(addCategories_category.Text))
            {
                MessageBox.Show("Please enter a category name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyNewDatabase;Integrated Security=True;TrustServerCertificate=True;"))
            {
                try
                {
                    connect.Open();

                    // ✅ Check if the category exists before updating
                    string checkQuery = "SELECT COUNT(*) FROM categories WHERE id = @id";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, connect))
                    {
                        checkCmd.Parameters.AddWithValue("@id", getID);

                        int count = (int)checkCmd.ExecuteScalar();
                        if (count == 0)
                        {
                            MessageBox.Show("Category not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // ✅ Perform the update
                    string updateQuery = "UPDATE categories SET category = @cat, date = @date WHERE id = @id";
                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, connect))
                    {
                        updateCmd.Parameters.AddWithValue("@id", getID);
                        updateCmd.Parameters.AddWithValue("@cat", addCategories_category.Text.Trim());
                        updateCmd.Parameters.AddWithValue("@date", DateTime.Now);

                        int rowsAffected = updateCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            addCategories_category.Clear();
                            getID = 0; // Reset ID after update
                            displayCategoriesData(); // Refresh the DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Failed to update category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private int getID = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                getID = (int)row.Cells[0].Value;

                addCategories_category.Text = row.Cells[1].Value.ToString();
            }
        }

        private void addCategories_removeBtn_Click(object sender, EventArgs e)
        {
            // Ensure a category is selected
            if (getID == 0)
            {
                MessageBox.Show("Please select a category to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirm deletion
            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this category?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.No)
            {
                return;
            }

            using (SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyNewDatabase;Integrated Security=True;TrustServerCertificate=True;"))
            {
                try
                {
                    connect.Open();

                    // ✅ Check if the category exists before deleting
                    string checkQuery = "SELECT COUNT(*) FROM categories WHERE id = @id";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, connect))
                    {
                        checkCmd.Parameters.AddWithValue("@id", getID);

                        int count = (int)checkCmd.ExecuteScalar();
                        if (count == 0)
                        {
                            MessageBox.Show("Category not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // ✅ Perform the deletion
                    string deleteQuery = "DELETE FROM categories WHERE id = @id";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, connect))
                    {
                        deleteCmd.Parameters.AddWithValue("@id", getID);

                        int rowsAffected = deleteCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Category removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            addCategories_category.Clear();
                            getID = 0; // Reset ID after deletion
                            displayCategoriesData(); // Refresh the DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Failed to remove category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void addCategories_clearBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
