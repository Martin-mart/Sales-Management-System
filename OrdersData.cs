using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.CodeDom.Compiler;

namespace Inventory
{
    internal class OrdersData
    {

        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyNewDatabase;Integrated Security=True;TrustServerCertificate=True;");

        public int ID { set; get; }
        public string CID { set; get; }
        public string PID { set; get; }
        public string PName { set; get; }
        public string Category { set; get; }
        public string QTY { set; get; }
        public string OrigPrice { set; get; }
        public string TotalPrice { set; get; }
    

        public List<OrdersData> allOrdersData()
        {
            List<OrdersData> listData = new List<OrdersData>();
            if(connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();

                    int custID = 0;
                    string selectCustData = "SELECT MAX(customer_id) FROM orders";

                    using(SqlCommand cmd = new SqlCommand(selectCustData, connect))
                    {
                        object result = cmd.ExecuteScalar();

                        if(result != DBNull.Value)
                        {
                            int temp = Convert.ToInt32(result);
                            if(temp == 0)
                            {
                                custID = 1;

                            }
                            else
                            {
                                custID = temp;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error ID");
                        }
                    }

                    string selectData = "SELECT * FROM orders WHERE customer_id = @cID";

                    using(SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            OrdersData oData = new OrdersData();

                            oData.ID = (int)reader["id"];
                            oData.CID = reader["customer_id"].ToString();
                            oData.PID = reader["prod_id"].ToString();
                            oData.PName = reader["prod_name"].ToString();
                            oData.Category = reader["category"].ToString();
                            oData.QTY = reader["qty"].ToString();
                            oData.OrigPrice = reader["orig_price"].ToString();
                            oData.TotalPrice = reader["total_price"].ToString();
                            

                            listData.Add(oData);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connection Failed: " + ex);

                }
                finally
                {
                    connect.Close();
                }
            }

            return listData;
        }
            
    }
}
