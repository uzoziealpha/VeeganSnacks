using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Veegan.Data.Access.Repository.IRepository;
using Vegan.Models.Model;

namespace Veeggan.Pages.Customer.Home
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // this is the range we allow per memu item in details 
        public MenuItem MenuItem { get; set; }
        [Range(1, 100 , ErrorMessage = "Please select a count between 1 and 100")]

        public int Count { get; set; }

        public void OnGet(int id)
        {
          
            MenuItem = _unitOfWork.MenuItem.GetFirstOrDefault(u => u.Id == id, includeProperties: "Category,FoodType");
        }
    }
} 