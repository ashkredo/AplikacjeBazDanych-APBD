using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalDb.ConnectionDbP;

namespace DalDb
{
    public class SqlServerDbAnimalsType
    {
        private string connectionDbP = ConnectionP.getConnectionP();
        
        public List<string> AnimalsType()
        {
            var list = new List<string>();
            using (var con = new SqlConnection(connectionDbP))
            {
                var com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "SELECT Name FROM AnimalType;";
                con.Open();
                using (var dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(dr["Name"].ToString());
                    }
                }
            }
            return list;
        }
    }
}
