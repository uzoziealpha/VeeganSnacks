using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Veegan.Data.Access.Repository.IRepository;
using Vegan.Models;

namespace Veeggan.Pages.Customer.Cart
{
    [Authorize]
    public class IndexModel : PageModel
    {
      

        public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }

        public double CartTotal { get; set; }

        private readonly IUnitOfWork _unitOfWork; 
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            CartTotal = 0;
        }
        public void OnGet()
        {
            // To display the Shopping the Cart Item
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(filter: u => u.ApplicationUserId == claim.Value,
                    includeProperties:"MenuItem,MenuItem.FoodType,MenuItem.Category");
                foreach(var cartItem in ShoppingCartList)
                {
                    CartTotal += (cartItem.MenuItem.Price * cartItem.Count);
                }
            }
        }
    }
}