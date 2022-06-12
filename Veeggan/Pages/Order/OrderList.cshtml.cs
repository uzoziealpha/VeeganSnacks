using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Veeggan.Pages.Order
{

    [Authorize]

    public class OrderListModel : PageModel
    {


    
            public void OnGet(int id)
            {
            }

    
    }
}
