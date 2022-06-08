using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Veegan.Data.Access.Repository.IRepository;
using Vegan.Models;

namespace Veeggan.Pages.Customer.Home
{
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
            ShoppingCart = new()
            {
                MenuItem = _unitOfWork.MenuItem.GetFirstOrDefault(u => u.Id == id, includeProperties: "Category,FoodType")
            };
        }
    }
       
} 