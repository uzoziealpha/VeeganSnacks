using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veegan.Data.Access.Repository.IRepository;
using Vegan.DataAccess.Data;
using Vegan.Models;

namespace Veeggan.Pages.Admin.FoodTypes;
[BindProperties]

public class DeleteModel : PageModel
{


    private readonly IUnitOfWork _unitOfWork;

    public IEnumerable<FoodType> FoodTypes { get; set; }    

    private readonly ApplicationDbContext _db;
    public FoodType FoodType { get; set; }

    public DeleteModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }



    // we pass the in id so it can match the CREATE.cshtml ID for editing 
    public void OnGet(int id)
    {
        //THESE ITEMS ARE USED TO RETURN VALUE OR NULL
        FoodType = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == id);
        
        //Category = _db.Category.FirstOrDefault(u=>u.Id==id);
        //Category = _db.Category.SingleOrDefault(id);
        //Category = _db.Category.Where(id);

    }


    //With a post handler for the users to enter that creates a category in db 
    //We can create categories using Async 
    public async Task<IActionResult> OnPost()
    {
        var foodTypeFromDb = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == FoodType.Id);
        if (foodTypeFromDb != null)
        {
            //we add .UPDATE keyword because its a post or patch request
            //    await _db.Category.AddAsync(Category);
            _unitOfWork.FoodType.Remove(foodTypeFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToPage("Index");
        }
        return Page();
    }
}
