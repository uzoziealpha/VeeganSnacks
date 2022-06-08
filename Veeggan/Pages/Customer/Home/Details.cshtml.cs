using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Veegan.Data.Access.Repository.IRepository;
using Vegan.Models;

namespace Veeggan.Pages.Customer.Home
{
    //we add the authorize in details page so only registerted users are authorized
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // this is the range we allow per memu item in details 
        [BindProperty]

        public ShoppingCart ShoppingCart { get; set; }
        public void OnGet(int id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            ShoppingCart = new()
            {
                ApplicationUserId = claim.Value,
                MenuItem = _unitOfWork.MenuItem.GetFirstOrDefault(u => u.Id == id, includeProperties: "Category,FoodType"),
                MenuItemId = id
            };
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ShoppingCart.Add(ShoppingCart);
                _unitOfWork.Save();
                return RedirectToPage("Index");

            }
            return Page();

        }

    }  
} 