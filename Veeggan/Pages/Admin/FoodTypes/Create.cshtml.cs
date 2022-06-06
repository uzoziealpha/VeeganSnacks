using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vegan.DataAccess.Data;
using Vegan.Models;

namespace Veeggan.Pages.Admin.FoodTypes;
[BindProperties]

public class CreateModel : PageModel
{

    private readonly ApplicationDbContext _db;
    public FoodType FoodType { get; set; }

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


        //we do the server-side FORM vaidations with ModelState 
        if(ModelState.IsValid)
        {
            await _db.FoodType.AddAsync(FoodType);
            await _db.SaveChangesAsync();
            TempData["success"] = "Category created successfully";
            return RedirectToPage("Index");
        }
        return Page();
    }
}
