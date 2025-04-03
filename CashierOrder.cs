using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Inventory
{
    public partial class CashierOrder : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyNewDatabase;Integrated Security=True;TrustServerCertificate=True;");

        public CashierOrder()
        {
            InitializeComponent();
            displayAllAvailableProducts();
            displayAllCategories();
            displayOrders();
            displayTotalPrice();
        }
        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(refreshData));
                return;
            }
            displayAllAvailableProducts();
            displayAllCategories();
            displayOrders();
            displayTotalPrice();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        public void displayAllAvailableProducts()
        {
            AddProductsData apData = new AddProductsData();
            List<AddProductsData> listdata = apData.allAvailableProducts();

            dataGridView1.DataSource = listdata;

        }

        public void displayOrders()
        {
            OrdersData oData = new OrdersData();
            List<OrdersData> listData = oData.allOrdersData();

            dataGridView2.DataSource = listData;
        }

        private void cashierOrder_addBtn_Click(object sender, EventArgs e)
        {
            IDGenerator();

            if (cashierOrder_category.SelectedIndex == -1 ||
                cashierOrder_prodID.SelectedIndex == -1 ||
                string.IsNullOrEmpty(cashierOrder_prodName.Text) ||
                string.IsNullOrEmpty(cashierOrder_price.Text) ||
                cashierOrder_qty.Value == 0)
            {
                MessageBox.Show("Please select an item first!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (connect == null)
            {
                MessageBox.Show("Database connection is not initialized!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cashierOrder_prodID.SelectedItem == null)
            {
                MessageBox.Show("Please select a product!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(idGen == null || idGen.ToString().Trim() == "")
            {
                MessageBox.Show("ID Generation failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (checkConnection())
            {
                try
                {
                    connect.Open();

                    float getPrice = 0;
                    string selectOrder = "SELECT * FROM products WHERE prod_id = @proID";

                    using (SqlCommand getOrder = new SqlCommand(selectOrder, connect))
                    {
                        getOrder.Parameters.AddWithValue("@proID", cashierOrder_prodID.SelectedItem);

                        using (SqlDataReader reader = getOrder.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                object rawValue = reader["price"];
                                if (rawValue != DBNull.Value)
                                {
                                    getPrice = Convert.ToSingle(rawValue);
                                }
                            }
                        }
                    }

                    string insertData = "INSERT INTO orders (customer_id, prod_id, prod_name, category, qty, orig_price, totalprice, order_date) " +
                                        "VALUES(@cID, @prodID, @prodName, @cat, @qty, @origPrice, @totalprice, @date)";

                    using (SqlCommand cmd = new SqlCommand(insertData, connect))
                    {
                        cmd.Parameters.AddWithValue("@cID", idGen);
                        cmd.Parameters.AddWithValue("@prodID", cashierOrder_prodID.SelectedItem);
                        cmd.Parameters.AddWithValue("@prodName", cashierOrder_prodName.Text.Trim());
                        cmd.Parameters.AddWithValue("@cat", cashierOrder_category.SelectedItem);
                        cmd.Parameters.AddWithValue("@qty", Convert.ToInt32(cashierOrder_qty.Value));
                        cmd.Parameters.AddWithValue("@origPrice", getPrice);

                        float totalP = getPrice * (int)cashierOrder_qty.Value;
                        cmd.Parameters.AddWithValue("@totalprice", totalP);

                        cmd.Parameters.AddWithValue("@date", DateTime.Today);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection Failed: " + ex.Message, "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }

            if (this != null)
            {
                displayOrders();
                displayTotalPrice();
            }
        }


        private int idGen;
        public bool checkConnection()
        {
            if(connect.State == ConnectionState.Closed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void displayAllCategories()
        {
            if (checkConnection())
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT * FROM categories";

                    using(SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            cashierOrder_category.Items.Clear();

                            while (reader.Read())
                            {
                                string item = reader.GetString(1);
                                cashierOrder_category.Items.Add(item);
                            }
                        }
                    }

                }catch(Exception ex)
                {
                    MessageBox.Show("Connection Failed!" + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        private float totalPrice = 0;

        public void displayTotalPrice()
        {
            try
            {
                IDGenerator(); // Check if this causes an error
            }
            catch (Exception ex)
            {
                MessageBox.Show("IDGenerator() Failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop execution if it fails
            }

            if (checkConnection())
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT total_price FROM orders WHERE customer_id = @cID";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@cID", idGen);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value) // Ensure result is valid
                        {
                            totalPrice = Convert.ToSingle(result);
                            cashierOrder_totalPrice.Text = totalPrice.ToString("0.00");
                        }
                        else
                        {
                            cashierOrder_totalPrice.Text = "0.00"; // Default value if no result
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Query Failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }



        private void cashierOrder_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            cashierOrder_prodID.SelectedIndex = -1;
            cashierOrder_prodID.Items.Clear();
            cashierOrder_prodName.Text = "";
            cashierOrder_price.Text = "";

            string selectedValue = cashierOrder_category.SelectedItem as string;
            
            if(selectedValue != null)
            {
                if(checkConnection())
                {
                    try
                    {
                        connect.Open();

                        string selectData = $"SELECT * FROM products WHERE category = '{selectedValue}' AND status = @status";

                        using (SqlCommand cmd = new SqlCommand(selectData, connect)) 
                        {
                            cmd.Parameters.AddWithValue("@status", "Available");

                            using(SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string value = reader["prod_id"].ToString();
                                    cashierOrder_prodID.Items.Add(value);
                                }
                            }
                        }
                    }catch(Exception ex)
                    {
                        MessageBox.Show("Connection Failed! " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void cashierOrder_prodID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cashierOrder_prodID.SelectedItem as string;
            if (checkConnection())
            {
                if (selectedValue != null)
                {
                    try
                    {
                        connect.Open();

                        string selectData = $"SELECT * FROM products WHERE prod_id = '{selectedValue}' AND status = @status";

                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            cmd.Parameters.AddWithValue("@status", "Available");

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string prodName = reader["prod_name"].ToString();
                                    float prodPrice = Convert.ToSingle(reader["price"]);

                                    cashierOrder_prodName.Text = prodName;
                                    cashierOrder_price.Text = prodPrice.ToString("0.00");

                                }
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Connection Failed" + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }
        public void IDGenerator()
        {
            using (SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyNewDatabase;Integrated Security=True;TrustServerCertificate=True;"))
            {
                connect.Open();

                string selectData = "SELECT MAX(customer_id) FROM customers";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value && result != null) // Check for null
                    {
                        idGen = Convert.ToInt32(result) + 1;
                    }
                    else
                    {
                        idGen = 1; // Default to 1 if no records exist
                    }
                }
            }
        }


        private void cashierOrder_payOrders_Click(object sender, EventArgs e)
        {
            IDGenerator();

            if(cashierOrder_amount.Text =="" || dataGridView2.Rows.Count < 0)
            {
                MessageBox.Show("Something went wrong", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(MessageBox.Show("Are you sure to pay order?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (checkConnection())
                    {
                        try
                        {

                            connect.Open();
                            string insertData = "INSERT INTO customer (id, customer_id, total_price, amount, change, order_date) VALUES (@cID, @totalPrice, @amount, @change, @date)";

                            using(SqlCommand cmd = new SqlCommand(insertData, connect))
                            {
                                cmd.Parameters.AddWithValue("@cID", idGen);
                                cmd.Parameters.AddWithValue("@totalPrice", cashierOrder_totalPrice.Text);
                                cmd.Parameters.AddWithValue("@amount", cashierOrder_amount.Text);
                                cmd.Parameters.AddWithValue("@change", cashierOrder_change.Text);

                                DateTime today = DateTime.Today;
                                cmd.Parameters.AddWithValue("@date", today);

                                cmd.ExecuteNonQuery();
                                clearFields();
                                MessageBox.Show("Paid successfully! ", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Connection Failed: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            connect.Close();
                        }
                    }
                }
            }

            displayTotalPrice();

            cashierOrder_amount.Text = "";
            cashierOrder_change.Text = "";
        }
        private void cashierOrder_removeBtn_Click(object sender, EventArgs e)
        {
            if(prodID == 0)
            {
                MessageBox.Show("Please select item first", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to Remove ID: " + prodID
                     + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (checkConnection())
                    {
                        try
                        {
                            connect.Open();

                            string deleteData = "DELETE FROM orders WHERE id = @id";

                            using(SqlCommand cmd = new SqlCommand(deleteData, connect))
                            {
                                cmd.Parameters.AddWithValue("@id", prodID);

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Removed Successfully!",
                               "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }

                        }catch(Exception ex)
                        {
                            MessageBox.Show("Connection Failed" + ex,
                                "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            connect.Close();
                        }
                    }
                }
            }

            displayOrders();
            displayTotalPrice();
        }

        private int prodID = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                prodID = (int)row.Cells[0].Value;

            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                prodID = (int)row.Cells[0].Value;

            }
        }
        private void cashierOrder_amount_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                try
                {
                    float getAmount = Convert.ToSingle(cashierOrder_amount.Text);
                    float getChange = (getAmount - totalPrice);

                    if(getChange <= -1)
                    {
                        cashierOrder_amount.Text = "";
                        cashierOrder_change.Text = "";
                    }
                    else
                    {
                        cashierOrder_change.Text = getChange.ToString("0.00");
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show("Something went wrong : " + ex,
                               "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cashierOrder_amount.Text = "";
                    cashierOrder_change.Text = "";
                }
                finally
                {

                }
            }
        }
        private void close_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to close this?","Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
                
            }
            
        }
        public void clearFields()
        {
            cashierOrder_category.SelectedIndex = -1;
            cashierOrder_prodID.SelectedIndex = -1;
            cashierOrder_prodName.Text = "";
            cashierOrder_price.Text = "";
            cashierOrder_qty.Value = 0;
        }
        private void cashierOrder_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }
        private void cashierOrder_receipts_Click(object senders, EventArgs e)
        {
            if(cashierOrder_amount.Text == "" || dataGridView2.Rows.Count < 0)
            {
                MessageBox.Show("Please order first!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                printDocument1.BeginPrint += new PrintEventHandler(printDocument1_BeginPrint_1);

                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
            



        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            displayTotalPrice();

            float y = 0;
            int count = 0;
            int rowIndex = 0;
            int colWidth = 120;
            int headerMargin = 10;
            int tableMargin = 10;

            using (Font font = new Font("Tahoma", 12))
            using (Font bold = new Font("Tahoma", 12, FontStyle.Bold))
            using (Font headerFont = new Font("Tahoma", 16, FontStyle.Bold))
            using (Font labelFont = new Font("Tahoma", 14, FontStyle.Bold))
            {
                float margin = e.MarginBounds.Top;

                StringFormat alignCenter = new StringFormat
                {
                    Alignment = StringAlignment.Center
                };

                string headerText = "Trojan's Inventory Management System";
                y = margin + count * headerFont.GetHeight(e.Graphics) + headerMargin;
                e.Graphics.DrawString(headerText, headerFont, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width / 2), y, alignCenter);
                count++;
                y += tableMargin;

                string[] header = { "ID", "CID", "PID", "PName", "Category", "OrigPrice", "QTY", "TotalPrice" };

                for (int q = 0; q < header.Length; q++)
                {
                    y = margin + count * bold.GetHeight(e.Graphics) + tableMargin;
                    e.Graphics.DrawString(header[q], bold, Brushes.Black, e.MarginBounds.Left + q * colWidth, y, alignCenter);
                }
                count++;

                float rSpace = e.MarginBounds.Bottom - y;

                while (rowIndex < dataGridView2.Rows.Count)
                {
                    DataGridViewRow row = dataGridView2.Rows[rowIndex];

                    for (int q = 0; q < dataGridView2.Columns.Count; q++)
                    {
                        object cellValue = row.Cells[q].Value;
                        string cell = (cellValue != null) ? cellValue.ToString() : string.Empty;

                        y = margin + count * font.GetHeight(e.Graphics) + tableMargin;
                        e.Graphics.DrawString(cell, font, Brushes.Black, e.MarginBounds.Left + q * colWidth, y, alignCenter);
                    }
                    count++;
                    rowIndex++;

                    if (y + font.GetHeight(e.Graphics) > e.MarginBounds.Bottom)
                    {
                        e.HasMorePages = true;
                        count = 0;  // Reset count for new page
                        return;
                    }
                }

                int labelmargin = (int)Math.Min(rSpace, 200);
                DateTime today = DateTime.Now;

                float labelx = e.MarginBounds.Right - e.Graphics.MeasureString("----------------------------", labelFont).Width;

                y = e.MarginBounds.Bottom - labelmargin - labelFont.GetHeight(e.Graphics);
                e.Graphics.DrawString("Total Price: \tKsh" + cashierOrder_amount.Text.Trim()
                     + "\n\t\t--------------\nChange: \tKsh" + cashierOrder_change.Text.Trim(), labelFont, Brushes.Black, labelx, y);

                labelmargin = (int)Math.Min(rSpace, -40);

                string labelText = today.ToString();
                y = e.MarginBounds.Bottom - labelmargin - labelFont.GetHeight(e.Graphics);
                e.Graphics.DrawString(labelText, labelFont, Brushes.Black, e.MarginBounds.Right - e.Graphics.MeasureString("-----------", labelFont).Width, y);
            }
        }

        private int rowIndex = 0;
        private void printDocument1_BeginPrint_1(object sender, PrintEventArgs e)
        {
            rowIndex = 0;
        }

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
