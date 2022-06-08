using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veegan.Data.Access.Data;
using Veegan.Data.Access.Repository.IRepository;
using Vegan.Models;

namespace Veegan.Data.Access.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        //we need to extract ApplicationDb COntext with Dependency Injection
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category category)
        {
            // to update an object from the categories using Iunit and IRepos
            var objFromDb = _db.Category.FirstOrDefault(u => u.Id == category.Id);
            objFromDb.Name = category.Name;
            objFromDb.DisplayOrder = category.DisplayOrder;
        }
    }
}
