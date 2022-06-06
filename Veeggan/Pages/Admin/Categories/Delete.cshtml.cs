using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veegan.Data.Access.Repository.IRepository;
using Vegan.DataAccess.Data;
using Vegan.Models;

namespace Veeggan.Pages.Admin.Categories;
[BindProperties]

public class DeleteModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;


    public Category Category { get; set; }

    public DeleteModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }



    // we pass the in id so it can match the CREATE.cshtml ID for editing 
    public void OnGet(int id)
    {
        //THESE ITEMS ARE USED TO RETURN VALUE OR NULL
         Category = _unitOfWork.Category.GetFirstOrDefault(u=>u.Id==id);

        //Category = _db.Category.FirstOrDefault(u=>u.Id==id);
        //Category = _db.Category.SingleOrDefault(id);
        //Category = _db.Category.Where(id);

    }


    //With a post handler for the users to enter that creates a category in db 
    //We can create categories using Async 
    public async Task<IActionResult> OnPost()
    {
        var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == Category.Id);
        if (categoryFromDb != null)
        {
          
            _unitOfWork.Category.Remove(categoryFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToPage("Index");
        }
        return Page();
    }
}
