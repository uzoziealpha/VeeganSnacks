using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veegan.Data.Access.Repository.IRepository;
using Vegan.DataAccess.Data;
using Vegan.Models;

namespace Veeggan.Pages.Admin.Categories;
[BindProperties]

public class EditModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;


    public Category Category { get; set; }

    public EditModel(IUnitOfWork unitOfWork)
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


        //we do the server-side FORM vaidations with ModelState 
        if (ModelState.IsValid)
        {
            //we add .UPDATE keyword because its a post or patch request
            //    await _db.Category.AddAsync(Category);
            _unitOfWork.Category.Update(Category);
            TempData["success"] = "Category Edited successfully";
            _unitOfWork.Save();
            return RedirectToPage("Index");
        }
        return Page();
    }
}
