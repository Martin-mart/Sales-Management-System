﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Inventory
{
    internal class CategoriesData
    {
        public int ID { set; get; }

        public string Category { set; get; }

        public string Date { set; get; }

        public List<CategoriesData> AllCategoriesData()
        {
            List<CategoriesData> listData = new List<CategoriesData>();

            using (SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyNewDatabase;Integrated Security=True;TrustServerCertificate=True;"))


            {
                connect.Open();

                string SelectData = "SELECT * FROM categories";
                using (SqlCommand cmd = new SqlCommand(SelectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CategoriesData cData = new CategoriesData();
                        cData.ID = (int)reader["id"];
                        cData.Date = reader["date"].ToString();
                        cData.Category = reader["category"].ToString();
                        listData.Add(cData);

                    }
                }
            }

            return listData;
        }
    }
}

