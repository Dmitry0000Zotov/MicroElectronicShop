using MicroElectronic.Domain.ViewModels.Order;
using MicroElectronic.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace MicroElectronic.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {
            var userId = Int32.Parse(User.FindFirst("Id").Value);

            var response = await _orderService.GetItemsList(userId);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return PartialView(response.Data);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderViewModel model)
        {
            var userId = Int32.Parse(User.FindFirst("Id").Value);

            var newOrder = new OrderViewModel()
            {
                OrderId = model.OrderId,
                UserId = userId
            };
            var response = await _orderService.CreateOrder(newOrder);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return RedirectToAction("MyApplicationItems", "ApplicationItems");
            }
            return RedirectToAction("Index", "Home");
        }


    }
}
