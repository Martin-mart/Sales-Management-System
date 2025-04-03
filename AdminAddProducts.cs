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
using System.IO;

namespace Inventory
{
    public partial class AdminAddProducts : UserControl
    {

        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyNewDatabase;Integrated Security=True;TrustServerCertificate=True;");
        public AdminAddProducts()
        {
            InitializeComponent();
            displayCategories();
            displayAllProducts();
        }
        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(refreshData));
                return;
            }
            displayCategories();
            displayAllProducts();
        }

        public void displayAllProducts()
        {
            if (checkConnection())
            {
                try
                {
                    connect.Open();
                    string query = "SELECT * FROM products";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        public bool checkEmptyFields()
        {
            if (addProducts_prodId.Text == "" || addProducts_prodName.Text == "" || addProducts_category.SelectedIndex == -1
                || addProducts_image.Image == null || addProducts_price.Text == "" || addProducts_stock.Text == ""
                || addProducts_status.SelectedIndex == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void displayCategories()
        {
            if(checkConnection())
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT * FROM categories";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        if(reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                addProducts_category.Items.Add(reader["category"].ToString());
                            }
                        }
                    }                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Connection Failed!" + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        private void addProducts_addBtn_Click(object sender, EventArgs e)
        {
            if (checkEmptyFields())
            {
                MessageBox.Show("Empty Fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (checkConnection())
            {
                try
                {
                    connect.Open();

                    
                    string selectData = "SELECT * FROM products WHERE prod_id = @prodID";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@prodID", addProducts_prodId.Text.Trim());

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            MessageBox.Show("Product Id: " + addProducts_prodId.Text.Trim() + " already exists",
                                "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            
                            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                            string relativePath = Path.Combine("Product_Directory", addProducts_prodId.Text.Trim() + ".jpg");
                            string path = Path.Combine(baseDirectory, relativePath);
                            string directoryPath = Path.GetDirectoryName(path);

                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }

                            File.Copy(addProducts_image.ImageLocation, path, true);

                            
                            string insertData = "INSERT INTO products (prod_id, prod_name, category, price, stock, image_path, status, date_insert) " +
                                                "VALUES (@prodId, @prodName, @cat, @price, @stock, @path, @status, @date)";

                            using (SqlCommand insertD = new SqlCommand(insertData, connect))
                            {
                                insertD.Parameters.AddWithValue("@prodId", addProducts_prodId.Text.Trim());
                                insertD.Parameters.AddWithValue("@prodName", addProducts_prodName.Text.Trim());
                                insertD.Parameters.AddWithValue("@cat", addProducts_category.SelectedItem);
                                insertD.Parameters.AddWithValue("@price", addProducts_price.Text.Trim());
                                insertD.Parameters.AddWithValue("@stock", addProducts_stock.Text.Trim());
                                insertD.Parameters.AddWithValue("@path", path);
                                insertD.Parameters.AddWithValue("@status", addProducts_status.SelectedItem);

                                
                                DateTime today = DateTime.Today;
                                insertD.Parameters.AddWithValue("@date", today);

                                insertD.ExecuteNonQuery();

                                clearFields();

                                MessageBox.Show("Added Successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection Failed: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }


        public bool checkConnection()
        {
            if(connect.State != ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void addProducts_importBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg; *.png)|*.jpg;*.png";
                string imagePath = "";

                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    addProducts_image.ImageLocation = imagePath;
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void clearFields()
        {
            addProducts_prodId.Text = "";
            addProducts_prodName.Text = "";
            addProducts_category.SelectedIndex = -1;
            addProducts_price.Text = "";
            addProducts_stock.Text = "";
            addProducts_status.SelectedIndex = -1;
            addProducts_image.Image = null;
        }
        private void addProducts_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private int getID = 0;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                getID = Convert.ToInt32(row.Cells[0].Value);  

                addProducts_prodId.Text = row.Cells[1].Value.ToString();   
                addProducts_prodName.Text = row.Cells[8].Value.ToString(); 
                addProducts_category.Text = row.Cells[2].Value.ToString(); 
                addProducts_price.Text = row.Cells[3].Value.ToString();    
                addProducts_stock.Text = row.Cells[4].Value.ToString();    
                addProducts_status.Text = row.Cells[6].Value.ToString();   

                string imagepath = row.Cells[5].Value.ToString(); 
                try
                {
                    if (!string.IsNullOrEmpty(imagepath) && File.Exists(imagepath))
                    {
                        addProducts_image.Image = Image.FromFile(imagepath);
                    }
                    else
                    {
                        addProducts_image.Image = null; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void addProducts_updateBtn_Click(object sender, EventArgs e)
        {
            
            if (getID == 0)
            {
                MessageBox.Show("Please select a product to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (checkEmptyFields())
            {
                MessageBox.Show("Please fill in all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (checkConnection())
            {
                try
                {
                    connect.Open();

                    
                    string updateQuery = "UPDATE products SET prod_id=@prodId, prod_name=@prodName, category=@cat, " +
                                         "price=@price, stock=@stock, image_path=@path, status=@status, date_insert=@date " +
                                         "WHERE id=@id";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@id", getID);
                        cmd.Parameters.AddWithValue("@prodId", addProducts_prodId.Text.Trim());
                        cmd.Parameters.AddWithValue("@prodName", addProducts_prodName.Text.Trim());
                        cmd.Parameters.AddWithValue("@cat", addProducts_category.SelectedItem);
                        cmd.Parameters.AddWithValue("@price", addProducts_price.Text.Trim());
                        cmd.Parameters.AddWithValue("@stock", addProducts_stock.Text.Trim());
                        cmd.Parameters.AddWithValue("@status", addProducts_status.SelectedItem);

                        
                        string imagePath = addProducts_image.ImageLocation;
                        if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                        {
                            cmd.Parameters.AddWithValue("@path", imagePath);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@path", DBNull.Value);
                        }

                        
                        cmd.Parameters.AddWithValue("@date", DateTime.Today);

                        
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            displayAllProducts(); 
                            clearFields();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update product!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update Failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        private void addProducts_removeBtn_Click(object sender, EventArgs e)
        {
            
            if (getID == 0)
            {
                MessageBox.Show("Please select a product to remove!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            DialogResult result = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Deletion",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (checkConnection())
                {
                    try
                    {
                        connect.Open();

                        
                        string deleteQuery = "DELETE FROM products WHERE id=@id";

                        using (SqlCommand cmd = new SqlCommand(deleteQuery, connect))
                        {
                            cmd.Parameters.AddWithValue("@id", getID);

                            
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Product removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                displayAllProducts(); 
                                clearFields(); 
                            }
                            else
                            {
                                MessageBox.Show("Failed to remove product!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Delete Failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

    }
}
