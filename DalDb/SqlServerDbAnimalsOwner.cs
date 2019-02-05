using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalDb.ConnectionDbP;

namespace DalDb
{
    public class SqlServerDbAnimalsOwner
    {
        private string connectionDbP = ConnectionP.getConnectionP();
        public List<string> AnimalsOwner()
        {
            var list = new List<string>();
            using (var con = new SqlConnection(connectionDbP))
            {
                var com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "SELECT * FROM Owner;";
                con.Open();
                using (var dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        // list.Add(dr["FirstName"].ToString() + " " + dr["LastName"].ToString());
                        list.Add(dr["LastName"].ToString());
                    }
                }
            }
            return list;
        }
    }
}
