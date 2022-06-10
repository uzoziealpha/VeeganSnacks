using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//I  UNIT CATEGORY WILL STAND AS THE MAIN PARENT FOR DATA ~ its a wrapper for all REPOS
// we save methods here
namespace Veegan.Data.Access.Repository.IRepository
{
    public  interface IUnitOfWork
    {
        ICategoryRepository Category { get; }

        IFoodTypeRepository FoodType { get; }

        IMenuItemRepository MenuItem { get; }
        IShoppingCartRepository ShoppingCart { get; }
        IOrderHeaderRepository OrderHeader { get; }
        IOrderDetailRepository OrderDetail { get; }
        IApplicationUserRepository ApplicationUser { get; }

        void Save();
    }
}
