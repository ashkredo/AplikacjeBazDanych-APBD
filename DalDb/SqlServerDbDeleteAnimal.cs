using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DalDb.ConnectionDbP;

namespace DalDb
{
    public class SqlServerDbDeleteAnimal
    {
        private int idOwner;
        private string connectionDbP = ConnectionP.getConnectionP();

        public SqlServerDbDeleteAnimal(DataGridViewSelectedRowCollection selectedRows)
        {
            foreach (DataGridViewRow i in selectedRows)
            {
                using (var con = new SqlConnection(connectionDbP))
                {
                    var com = new SqlCommand();
                    com.Connection = con;
                    com.Parameters.AddWithValue("firstName", i.Cells[0].Value.ToString());
                    com.Parameters.AddWithValue("lastName", i.Cells[1].Value.ToString());
                    com.CommandText = "SELECT * FROM Owner WHERE FirstName = @firstName AND LastName = @lastName;";

                    con.Open();
                    var dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        idOwner = (int)dr["IdOwner"];
                    }
                }

                using (var con = new SqlConnection(connectionDbP))
                {
                    var com = new SqlCommand();
                    com.Connection = con;
                    com.CommandText = "DELETE FROM Animal WHERE IdOwner = @idOwner AND Name = @name;";
                    com.Parameters.AddWithValue("idOwner", idOwner);
                    com.Parameters.AddWithValue("name", i.Cells[2].Value.ToString());
                    con.Open();
                    var dr = com.ExecuteReader();
                }
            }
        }
    }
}
