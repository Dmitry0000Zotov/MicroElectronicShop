using MicroElectronic.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroElectronic.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [Route("Catalog/Equipments/EquipmentPage")]
        public async Task<IActionResult> EquipmentPage(int id)
        {
            var response = await _equipmentService.GetEquipment(id);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ViewData["Title"] = response.Data.Name;
                return View(response.Data);
            }

            return RedirectToAction("Index", "Catalog");
        }
    }
}
