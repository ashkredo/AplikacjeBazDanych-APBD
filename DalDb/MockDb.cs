using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalDb.Interfaces;
using DalDb.Model;

namespace DalDb
{
    public class MockDb : IAnimalsDb
    {
        public List<string> GetAnimalType()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Animal> GetAnimals()
        {
            throw new NotImplementedException();
            //return new List<Animal> { new Animal { AnimalName = "Bella", LastName = "Shkred", FirstName = "Arthur", AnimalType = "Chihuahua" } }; 
        }
    }
}
