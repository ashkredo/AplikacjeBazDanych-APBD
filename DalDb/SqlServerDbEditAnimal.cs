using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalDb.ConnectionDbP;

namespace DalDb
{
    public class SqlServerDbEditAnimal
    {
        private int IdOwner;
        private int IdAnimalType;
        private string connectionDbP = ConnectionP.getConnectionP();
        public SqlServerDbEditAnimal(string Name, string Owner, string Type, string animalName, string animalOwner, string animalType)
        {
            SearchIdOwner(animalOwner);
            SearchIdAnimalType(animalType);
            using (var con = new SqlConnection(connectionDbP))
            {
                var com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "UPDATE Animal SET Name = @animalName, IdOwner = @IdOwner, IdAnimalType = @IdAnimalType WHERE Name = @Name;";
                com.Parameters.AddWithValue("animalName", animalName);
                com.Parameters.AddWithValue("IdOwner", IdOwner);
                com.Parameters.AddWithValue("IdAnimalType", IdAnimalType);
                com.Parameters.AddWithValue("Name", Name);
                con.Open();
                var dr = com.ExecuteReader();
                dr.Close();
            }
        }

        private void SearchIdOwner(string animalOwner)
        {
            using (var con = new SqlConnection(connectionDbP))
            {
                var com = new SqlCommand();
                com.Connection = con;
                com.Parameters.AddWithValue("AnimalOwner", animalOwner);
                com.CommandText = "SELECT IdOwner FROM Owner WHERE LastName = @AnimalOwner;";
                con.Open();
                using (var dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        IdOwner = (int)dr["IdOwner"];
                    }
                }
            }
        }

        private void SearchIdAnimalType(string animalType)
        {
            using (var con = new SqlConnection(connectionDbP))
            {
                var com = new SqlCommand();
                com.Connection = con;
                com.Parameters.AddWithValue("AnimalType", animalType);
                com.CommandText = "SELECT IdAnimalType FROM AnimalType WHERE Name = @AnimalType;";
                con.Open();
                using (var dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        IdAnimalType = (int)dr["IdAnimalType"];
                    }
                }
            }
        }
    }
}
