using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vegan.DataAccess.Data;
using Vegan.Models;

namespace Veeggan.Pages.Admin.FoodTypes;
[BindProperties]

public class EditModel : PageModel
{

    private readonly ApplicationDbContext _db;
    public FoodType FoodType { get; set; }

    public EditModel(ApplicationDbContext db)
    {
        _db = db;
    }

    // we pass the in id so it can match the CREATE.cshtml ID for editing 
    public void OnGet(int id)
    {
        //THESE ITEMS ARE USED TO RETURN VALUE OR NULL
        FoodType = _db.FoodType.Find(id);
        
        //Category = _db.Category.FirstOrDefault(u=>u.Id==id);
        //Category = _db.Category.SingleOrDefault(id);
        //Category = _db.Category.Where(id);

    }


    //With a post handler for the users to enter that creates a category in db 
    //We can create categories using Async 
    public async Task<IActionResult> OnPost()
    {
  

        //we do the server-side FORM vaidations with ModelState 
        if(ModelState.IsValid)
        {
            //we add .UPDATE keyword because its a post or patch request
            //    await _db.Category.AddAsync(Category);
            _db.FoodType.Update(FoodType);
            TempData["success"] = "Category Edited successfully";
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
        return Page();
    }
}
