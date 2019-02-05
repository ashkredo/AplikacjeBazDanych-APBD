using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalDb.ConnectionDbP;

namespace DalDb
{
    public class SqlServerDbAddAnimal
    {
        private string connectionDbP = ConnectionP.getConnectionP();
        private String animalName;
        private String ownerFirstName;
        private String ownerLastName;
        private DateTime ownerBirthDate;
        private int ownerId;
        private DateTime ownerRegisterDate;
        private String animalType;
        private int idAnimalType;
        public SqlServerDbAddAnimal(String animalName, String ownerLastName, String animalType)
        {
            this.animalName = animalName;
            this.ownerLastName = ownerLastName;
            this.animalType = animalType;
            searchInfoOwner();
            searchIdType();
            insertIntoAnimal();
        }

        private void insertIntoAnimal()
        {
            using (var con = new SqlConnection(connectionDbP))
            {
                var com = new SqlCommand();
                com.Connection = con;
                com.Parameters.AddWithValue("animalName", animalName);
                com.Parameters.AddWithValue("idAnimalType", idAnimalType);
                com.Parameters.AddWithValue("ownerId", ownerId);
                com.CommandText = "INSERT INTO Animal (Name, IdAnimalType, IdOwner) VALUES (@animalName, @idAnimalType, @ownerId);";
                con.Open();
                using (var dr = com.ExecuteReader())
                {
                }
            }
        }

        public void searchIdType()
        {
            using (var con = new SqlConnection(connectionDbP))
            {
                var com = new SqlCommand();
                com.Connection = con;
                com.Parameters.AddWithValue("animalType", animalType);
                com.CommandText = "SELECT IdAnimalType FROM AnimalType WHERE Name = @animalType;";
                con.Open();
                using (var dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        idAnimalType = (int)dr["IdAnimalType"];
                    }
                }
            }
        }
        public void searchInfoOwner()
        {
            using (var con = new SqlConnection(connectionDbP))
            {
                var com = new SqlCommand();
                com.Connection = con;
                com.Parameters.AddWithValue("lastName", ownerLastName);
                com.CommandText = "SELECT * FROM Owner WHERE LastName = @lastName;";
                con.Open();
                using (var dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ownerFirstName = dr["FirstName"].ToString();
                        ownerRegisterDate = (DateTime)dr["RegisterDate"];
                        ownerBirthDate = (DateTime)dr["BirthDate"];
                        ownerId = (int)dr["IdOwner"];
                    }
                }
            }
        }
    }
}
