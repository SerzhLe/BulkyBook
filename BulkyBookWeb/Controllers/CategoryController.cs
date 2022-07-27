using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                //custom error message
                ModelState.AddModelError("name", "Category name cannot be the same as DisplayOrder");
                //we add key the same as the property of model - that way allows to show this message under Name input
            }

            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(category);

        }

        //GET
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
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

            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(category);

        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
