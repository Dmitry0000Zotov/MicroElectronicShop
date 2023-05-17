using MicroElectronic.Domain.ViewModels.Category;
using MicroElectronic.Domain.ViewModels.Pagination;
using MicroElectronic.Service.Implementations;
using MicroElectronic.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroElecWebStore.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ILogger<CatalogController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IEquipmentService _equipmentService;
        private readonly IBufferedFileUploadService _bufferedFileUploadService;

        public CatalogController(ILogger<CatalogController> logger, ICategoryService categoryService, 
            IEquipmentService equipmentService, IBufferedFileUploadService bufferedFileUploadService)
        {
            _logger = logger;
            _categoryService = categoryService;
            _equipmentService = equipmentService;
            _bufferedFileUploadService = bufferedFileUploadService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _categoryService.GetCategories();
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return View(response.Data);
            }
            return View();
        }

        public async Task<IActionResult> EditMode()
        {
            var response = await _categoryService.GetCategories();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return View(response.Data);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(int id)
        {
            if (id == 0)
                return PartialView();

            var response = await _categoryService.GetCategory(id);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return PartialView("EditCategory", response.Data);
            }

            ModelState.AddModelError("", response.Description);
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(IFormFile? file, [FromForm]CategoryViewModel model)
        {
            if (model.Name != null)
            {
                if(file?.Length > 0)
                {
                    var imageUrl = await _bufferedFileUploadService.UploadFile(file);
                    model.ImageUrl = imageUrl;
                }   
                if (model.Id == 0)
                {
                    await _categoryService.Create(model);
                }
                else
                {
                    await _categoryService.Update(model.Id, model);
                }
            }
            return RedirectToAction("EditMode", "Catalog");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var response = await _categoryService.GetCategory(id);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return PartialView("DeleteCategory", response.Data);
            }

            ModelState.AddModelError("", response.Description);
            return RedirectToAction("EditMode", "Catalog");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(CategoryViewModel model)
        {
            if(model.Id != 0)
            {
                System.IO.File.Delete("D:/repos/MicroElectronic/MicroElectronic/wwwroot" + model.ImageUrl);
                await _categoryService.DeleteCategory(model.Id);
            }

            return RedirectToAction("EditMode", "Catalog");
        }

        [HttpGet]
        public async Task<IActionResult> Equipments(int category, int page = 1)
        {
            var response = await _equipmentService.GetEquipments(category);
            var title = await _categoryService.GetCategory(category);
            int pageSize = 5;
            var count = response.Data.Count();
            var items = response.Data.Skip((page - 1) * pageSize)
                .Take(pageSize);

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel indexViewModel = new IndexViewModel()
            {
                PageViewModel = pageViewModel,
                Equipments = items
            };
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ViewData["CategoryTitle"] = title.Data.Name;
                ViewData["CategoryId"] = category;
                return View("Equipments", indexViewModel);
            }

            return RedirectToAction("Index", "Catalog");
        }
    }
}
