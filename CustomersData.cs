﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Inventory
{
    internal class CustomersData
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyNewDatabase;Integrated Security=True;TrustServerCertificate=True;");

        public string CustomerID { set; get; }
        public string TotalPrice { set; get; }
        public string Amount { set; get; }
        public string Change { set; get; }
        public string Date { set; get; }
        public List<CustomersData> allTodayCustomers()
        {

            List<CustomersData> listData = new List<CustomersData>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();
                    DateTime today = DateTime.Today;

                    string selectData = "SELECT * FROM customers WHERE order_date = @date";

                    using(SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@date", today);

                        SqlDataReader reader = cmd.ExecuteReader();
                        while(reader.Read())
                        {
                            CustomersData cData = new CustomersData();

                            cData.CustomerID = reader["customer_id"].ToString();
                            cData.CustomerID = reader["total_price"].ToString();
                            cData.CustomerID = reader["amount"].ToString();
                            cData.CustomerID = reader["change"].ToString();
                            cData.CustomerID = reader["order_date"].ToString();

                            listData.Add(cData);
                        }
                    }
                }catch(Exception ex)
                {
                    Console.WriteLine("Connection Failed" + ex);
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
