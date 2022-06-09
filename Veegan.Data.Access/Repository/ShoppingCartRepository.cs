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
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        //we need to extract ApplicationDb COntext with Dependency Injection
        private readonly ApplicationDbContext _db;

        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public int DecrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count -= count;
            _db.SaveChanges();
            return shoppingCart.Count;
        }

        public int IncrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count += count;
            _db.SaveChanges();
            return shoppingCart.Count;
        }
    }
}
