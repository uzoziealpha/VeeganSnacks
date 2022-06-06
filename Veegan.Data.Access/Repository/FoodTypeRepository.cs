using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Veegan.Data.Access.Repository.IRepository;
using Vegan.DataAccess.Data;
using Vegan.Models;

namespace Veegan.Data.Access.Repository
{
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        //we need to extract ApplicationDb COntext with Dependency Injection
        private readonly ApplicationDbContext _db;

        public FoodTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

  

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(FoodType obj)
        {
            // to update an object from the categories using Iunit and IRepos
            var objFromDb = _db.FoodType.FirstOrDefault(u => u.Id == obj.Id);
            objFromDb.Name = obj.Name;
          //  objFromDb.DisplayOrder = category.DisplayOrder;  (NO ORDERS IN FOODTYPE)
        }

     
    }
}
