using HotelBooking.Application.Common.Interfaces;
using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Web.Controllers
{

    public class VillaController : Controller
    {
        private readonly IVillaRepository _villaRepository;

        public VillaController(IVillaRepository villaRepository)
        {
            _villaRepository = villaRepository;
        }
        public IActionResult Index()
        {
            //var villas = _db.Villas.ToList();
            var villas = _villaRepository.GetAll(); 

            return View(villas);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Villa obj)
        {
            if(obj.Name == obj.Description)
            {
                ModelState.AddModelError("name", "The description cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                //_db.Villas.Add(obj);
                _villaRepository.Add(obj);
                //_db.SaveChanges();
                _villaRepository.Save();
                TempData["success"] = "The villa has been created successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Update(int villaId)
        {
            //Villa? obj = _db.Villas.FirstOrDefault(u => u.Id == villaId);
            Villa? obj = _villaRepository.Get(u=>u.Id == villaId);

            //var VillaList = _db.Villas.Where(u => u.Price > 50 && u.Occupancy > 0);

            if(obj == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Update(Villa obj)
        {
            if (ModelState.IsValid && obj.Id > 0)
            {
                _villaRepository.Update(obj);
                _villaRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Delete(int villaId)
        {
            Villa? obj =_villaRepository.Get(u => u.Id == villaId);

            //var VillaList = _db.Villas.Where(u => u.Price > 50 && u.Occupancy > 0);

            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(Villa obj)
        {
            Villa? objFromDb = _villaRepository.Get(u => u.Id == obj.Id);

            if (objFromDb is not null)
            {
                _villaRepository.Remove(objFromDb);
                _villaRepository.Save();
                TempData["success"] = "The villa has been deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The villa could not be deleted.";
            return View();
        }
    }
}
