using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetStore.Services;
using PetStore.Services.Models.Category;
using PetStore.Web.Models.Category;

namespace PetStore.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categories;

        public CategoriesController(ICategoryService categories)
            => this.categories = categories;

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var categoryServiceModel = new CreateCategoryServiceModel
            {
                Name = model.Name,
                Description = model.Description,
            };

            this.categories.Create(categoryServiceModel);

            return this.RedirectToAction("All", "Categories");
        }

        public IActionResult All()
        {
            var allCategories = categories.All()
                .Select(cs => new CategoryListingViewModel
                {
                    Id = cs.Id,
                    Name = cs.Name
                })
                .ToList();

            return View(allCategories);
        }
    }
}