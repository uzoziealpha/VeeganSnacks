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
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        //we need to extract ApplicationDb COntext with Dependency Injection
        private readonly ApplicationDbContext _db;

        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(OrderHeader obj)
        {
            // to update an object from the categories using Iunit and IRepos
           _db.OrderHeader.Update(obj);
           
        }
    }
}
