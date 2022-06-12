using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veegan.Data.Access.Repository.IRepository;
using Vegan.Models;
using Vegan.Models.ViewModel;
using Vegan.Utility;

namespace Veeggan.Pages.Order
{
    public class ManageOrderModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;

        public List<OrderDetailVM>  OrderDetailVM { get; set; }
    

        public ManageOrderModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void OnGet()
        {
            OrderDetailVM = new();

            List<OrderHeader> orderHeaders = _unitOfWork.OrderHeader.GetAll(u => u.Status == SD.StatusSubmitted ||
            u.Status == SD.StatusInProcess).ToList();

            foreach(OrderHeader item in orderHeaders)
            {
                OrderDetailVM individual = new OrderDetailVM()
                {
                    OrderHeader = item,
                    OrderDetails = _unitOfWork.OrderDetail.GetAll(u => u.OrderId == item.Id).ToList()

                };
                OrderDetailVM.Add(individual);
            }
        }
    }
}
