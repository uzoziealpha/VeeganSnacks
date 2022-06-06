using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veegan.Data.Access.Repository.IRepository;
using Vegan.Models;


namespace Veeggan.Pages.Admin.FoodTypes;

[BindProperties]

public class EditModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    public FoodType FoodType { get; set; }


    public EditModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public void OnGet(int id)
    {
        FoodType = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == id);
        //   Category = _db.Category.FirstOrDefault(u=>u.Id==id);
        //   Category = _db.Category.SingleOrDefault(u=>u.Id==id);
        //    Category = _db.Category.Where(u=>u.Id==id).FirstOrDefault();



    }

    public async Task<IActionResult> OnPost()
    {

        if (ModelState.IsValid)
        {
            _unitOfWork.FoodType.Update(FoodType);
            _unitOfWork.Save();
            TempData["success"] = "FoodType updated successfully";
            return RedirectToPage("Index");
        }
        return Page();

    }
}