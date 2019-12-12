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

        [HttpGet]
        public IActionResult Details(int id)
        {
            var categoryDetails = categories.GetById(id);

            if (categoryDetails.Name == null)
            {
                return BadRequest();
            }

            if (categoryDetails.Description == null)
            {
                categoryDetails.Description = "No description.";
            }

            var categoryDetailsViewModel = new CategoryDetailsViewModel
            {
                Id = categoryDetails.Id,
                Name = categoryDetails.Name,
                Description = categoryDetails.Description,
            };

            return this.View(categoryDetailsViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = this.categories.GetById(id);

            if (category.Name == null)
            {
                return BadRequest();
            }

            var categoryEdit = new CategoryDetailsViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
            };

            return this.View(categoryEdit);
        }

        [HttpPost]
        public IActionResult Edit(CategoryEditInputModel model)
        {
            if (!this.categories.Exists(model.Id))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var categoryEdit = new CategoryEditServiceModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
            };

            this.categories.Edit(categoryEdit);

            return RedirectToAction("Details", "Categories", new { categoryEdit.Id});
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