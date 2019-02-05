using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalDb.ConnectionDbP
{
    public class ConnectionP
    {
        private static string connectionP = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Artur\\Documents\\APBD_SA_S15444\\AppData\\AppData\\AnimalsDatabase.mdf;Integrated Security=True";

        public static string getConnectionP()
        {
            return connectionP;
        }
    }
}
