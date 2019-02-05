using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalDb.ConnectionDbP;
using DalDb.Interfaces;
using DalDb.Model;

namespace DalDb
{
    public class SqlServerDb : IAnimalsDb
    {
        private string connectionDbP = ConnectionP.getConnectionP();

        public IEnumerable<Animal> GetAnimals()
        {
            var list = new List<Animal>();
            using (var con = new SqlConnection(connectionDbP))
            {
                var com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "SELECT FirstName, LastName, Animal.Name, AnimalType.Name AS AnimalType FROM Owner, Animal, AnimalType WHERE Animal.IdOwner = Owner.IdOwner AND Animal.IdAnimalType = AnimalType.IdAnimalType;";
                con.Open();
                using (var dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //com.Parameters.AddWithValue("idAnimal", (int) dr["idOwner"]);
                        var newAnimal = new Animal();
                        newAnimal.FirstName = dr["FirstName"].ToString();
                        newAnimal.LastName = dr["LastName"].ToString();
                        newAnimal.AnimalName = dr["Name"].ToString();
                        newAnimal.AnimalType = dr["AnimalType"].ToString();

                        list.Add(newAnimal);
                    }
                }
            } return list;
        } 

    }
}
