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
    public class OrderDetailRepository : Repository<OrderDetails>, IOrderDetailRepository
    {
        //we need to extract ApplicationDb COntext with Dependency Injection
        private readonly ApplicationDbContext _db;

        public OrderDetailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(OrderDetails obj)
        {
            // to update an object from the categories using Iunit and IRepos
            _db.OrderDetails.Update(obj);
        }
    }
}
