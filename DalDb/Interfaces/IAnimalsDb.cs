using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalDb.Model;

namespace DalDb.Interfaces
{
    // DAL - Data Access Layer 
    public interface IAnimalsDb
    {
        //List<Animal> GetAnimals();
        IEnumerable<Animal> GetAnimals();
    }
}
