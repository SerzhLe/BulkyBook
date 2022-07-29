using BulkyBookDataAccess.Data;
using BulkyBookModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.ToListAsync();

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

            _context.Categories.Add(category);

            if (await _context.SaveChangesAsync() <= 0)
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

            var category = await _context.Categories.FindAsync(id);

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

            _context.Categories.Update(category);

            if (await _context.SaveChangesAsync() <= 0)
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

            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);

            if (await _context.SaveChangesAsync() <= 0)
            {
                return BadRequest("Failed to delete the category. Please, try again.");
            }

            TempData["success"] = "Category deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
