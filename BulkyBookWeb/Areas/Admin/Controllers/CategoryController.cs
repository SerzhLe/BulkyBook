﻿using BulkyBookDataAccess.Repository.IRepository;
using BulkyBookModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _uow;

        public CategoryController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _uow.CategoryRepository.GetAll();

            return View(categories);
        }

        //GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                //custom error message
                ModelState.AddModelError("name", "Category name cannot be the same as Display Order");
                //we add key the same as the property of model - that way allows to show this message under Name input
            }

            if (!ModelState.IsValid)
            {
                return View(category);
            }

            _uow.CategoryRepository.Create(category);

            if (!await _uow.CompleteAsync())
            {
                return BadRequest("Failed to create the category. Please, try again");
            }

            //used to store data within one request to another - ideal for notifications
            //if you apply another request or refresh the page - it will go away
            TempData["success"] = "Category created successfully";

            return RedirectToAction("Index");
        }

        //GET
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var category = await _uow.CategoryRepository.GetSingleOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                //custom error message
                ModelState.AddModelError("name", "Category name cannot be the same as DisplayOrder");
            }

            if (!ModelState.IsValid)
            {
                return View(category);
            }

            _uow.CategoryRepository.Update(category);

            if (!await _uow.CompleteAsync())
            {
                return BadRequest("Failed to update the category. Please, try again");
            }

            TempData["success"] = "Category updated successfully";

            return RedirectToAction("Index");
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var category = await _uow.CategoryRepository.GetSingleOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            _uow.CategoryRepository.Delete(category);

            if (!await _uow.CompleteAsync())
            {
                return BadRequest("Failed to delete the category. Please, try again.");
            }

            TempData["success"] = "Category deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
