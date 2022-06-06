using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veegan.Data.Access.Repository.IRepository;
using Vegan.DataAccess.Data;
using Vegan.Models;

namespace Veeggan.Pages.Admin.Categories;
[BindProperties]

public class CreateModel : PageModel
{

    private readonly IUnitOfWork _unitOfWork;


    public Category Category { get; set; }

    public CreateModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void OnGet()
    {
    }


    //With a post handler for the users to enter that creates a category in db 
    //We can create categories using Async 
    public async Task<IActionResult> OnPost()
    {
        if (Category.Name == Category.DisplayOrder.ToString())
        {
            ModelState.AddModelError(string.Empty, "The DisplayOrder cannot exactly match the Name.");
        }


        //we do the server-side FORM vaidations with ModelState 
        if (ModelState.IsValid)
        {
            _unitOfWork.Category.Add(Category);
            _unitOfWork.Save();
            TempData["success"] = "Category created successfully";
            return RedirectToPage("Index");
        }
        return Page();
    }
}
