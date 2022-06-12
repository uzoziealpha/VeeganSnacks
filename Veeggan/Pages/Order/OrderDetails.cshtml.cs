using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veegan.Data.Access.Repository.IRepository;
using Vegan.Models.ViewModel;

namespace Veeggan.Pages.Order
{
    public class OrderDetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderDetailVM OrderDetailVM {get; set;}

        public OrderDetailsModel(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
            OrderDetailVM = new()
            {
                OrderHeader =  _unitOfWork.OrderHeader.GetFirstOrDefault(u => u.Id == id, includeProperties: "ApplicationUser"),
                OrderDetails = _unitOfWork.OrderDetail.GetAll(u=>u.OrderId==id).ToList()
            };
        }
    }
}
