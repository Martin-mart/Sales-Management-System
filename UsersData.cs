using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Inventory
{
    internal class UsersData
    {

        public int ID { set; get; }

        public string username { set; get; }
        public string password { set; get; }
        public string Role { set; get; }
        public string Status { set; get; }
        public string Date { set; get; }

        public List<UsersData> AllUsersData()
        {
            List<UsersData> listData = new List<UsersData>();

            using (SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyNewDatabase;Integrated Security=True;TrustServerCertificate=True;"))
            {
                connect.Open();

                string SelectData = "SELECT * FROM users";
                using (SqlCommand cmd = new SqlCommand(SelectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        UsersData uData = new UsersData();
                        uData.ID = (int)reader["id"];
                        uData.username = reader["username"].ToString();
                        uData.password = reader["password"].ToString();
                        uData.Role = reader["role"].ToString();
                        uData.Status = reader["Status"].ToString();
                        uData.Date = reader["date"].ToString();
                        listData.Add(uData);

                    }
                }
            }

            return listData;
        }
    }

}
