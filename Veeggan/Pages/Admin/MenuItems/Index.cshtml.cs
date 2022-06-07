 using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vegan.DataAccess.Data;
using Vegan.Models;

namespace Veeggan.Pages.Admin.MenuItems;



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