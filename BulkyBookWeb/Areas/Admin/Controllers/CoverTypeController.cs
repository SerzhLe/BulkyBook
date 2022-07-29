using BulkyBookDataAccess.Repository.IRepository;
using BulkyBookModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _uow;

        public CoverTypeController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Index()
        {
            var coverTypes = await _uow.CoverTypeRepository.GetAll();

            return View(coverTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CoverType coverType)
        {
            if (!ModelState.IsValid)
            {
                return View(coverType);
            }

            _uow.CoverTypeRepository.Create(coverType);

            if (!await _uow.CompleteAsync())
            {
                return BadRequest("Failed to create cover type. Please, try again.");
            }

            TempData["success"] = "Cover Type created successfully";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var coverType = await _uow.CoverTypeRepository.GetSingleOrDefault(cT => cT.Id == id);

            if (coverType == null)
            {
                return NotFound();
            }

            return View(coverType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CoverType coverType)
        {
            if (coverType == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(coverType);
            }

            _uow.CoverTypeRepository.Update(coverType);

            if (!await _uow.CompleteAsync())
            {
                return BadRequest("Failed to update the cover type. Please, try again.");
            }

            TempData["success"] = "Cover type updated successfully";

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

            var coverType = await _uow.CoverTypeRepository.GetSingleOrDefault(c => c.Id == id);

            if (coverType == null)
            {
                return NotFound();
            }

            _uow.CoverTypeRepository.Delete(coverType);

            if (!await _uow.CompleteAsync())
            {
                return BadRequest("Failed to delete the cover type. Please, try again.");
            }

            TempData["success"] = "Cover type deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
