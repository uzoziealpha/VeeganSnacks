using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vegan.DataAccess.Data;
using Vegan.Models;

namespace Veeggan.Pages.Admin.Categories;
[BindProperties]

public class CreateModel : PageModel
{
    

    private readonly ApplicationDbContext _db;

    public Category Category { get; set; }

    public CreateModel(ApplicationDbContext db)
    {
        _db = db; 
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
             await _db.Category.AddAsync(Category);
            await _db.SaveChangesAsync();
            TempData["success"] = "Category created successfully";
            return RedirectToPage("Index");
        }
        return Page();
    }
}
