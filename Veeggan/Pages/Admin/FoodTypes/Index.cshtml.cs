using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veegan.Data.Access.Data;
using Vegan.Models;

namespace Veeggan.Pages.Admin.FoodTypes;



public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;

    public IEnumerable<FoodType> FoodTypes { get; set; }
    public IndexModel(ApplicationDbContext db)
    {
        _db = db;
    }   

    public void OnGet()
    {
        //we use the Get() to get all the category list from DB
        FoodTypes = _db.FoodType;
    }

}