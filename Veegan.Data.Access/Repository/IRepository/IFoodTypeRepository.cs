using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vegan.Models;

namespace Veegan.Data.Access.Repository.IRepository
{
     public interface IFoodTypeRepository : IRepository<FoodType>
    {

        //we add the interface of update in a new folder
        void Update(FoodType obj);
   

        //in food type we use OBJ for generic reasons 



        //  void Save();
        // We can't save or repos here we use a unit of work 
    }
}
