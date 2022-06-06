using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vegan.DataAccess.Data;
using Vegan.Models;

namespace Veeggan.Pages.Admin.Categories;
[BindProperties]

public class DeleteModel : PageModel
{

    private readonly ApplicationDbContext _db;
    public Category Category { get; set; }

    public DeleteModel(ApplicationDbContext db)
    {
        _db = db;
    }

    // we pass the in id so it can match the CREATE.cshtml ID for editing 
    public void OnGet(int id)
    {
        //THESE ITEMS ARE USED TO RETURN VALUE OR NULL
         Category = _db.Category.Find(id);

        //Category = _db.Category.FirstOrDefault(u=>u.Id==id);
        //Category = _db.Category.SingleOrDefault(id);
        //Category = _db.Category.Where(id);

    }


    //With a post handler for the users to enter that creates a category in db 
    //We can create categories using Async 
    public async Task<IActionResult> OnPost()
    {
        var categoryFromDb = _db.Category.Find(Category.Id);
        if (categoryFromDb != null)
        {
            //we add .UPDATE keyword because its a post or patch request
            //    await _db.Category.AddAsync(Category);
            _db.Category.Remove(categoryFromDb);
            await _db.SaveChangesAsync();
            TempData["success"] = "Category deleted successfully";
            return RedirectToPage("Index");
        }
        return Page();
    }
}
