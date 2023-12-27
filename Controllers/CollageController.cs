using Asp.netCoreMVCIntro.Models;
using Asp.netCoreMVCIntro.Service;
using Asp.netCoreMVCIntro.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Asp.netCoreMVCIntro.Controllers
{
      public class CollageController : Controller
    {
        private readonly ICollageService _collageService;
        public CollageController(ICollageService collageService)
        {
            _collageService = collageService;
        }

        public async Task<IActionResult> Index()
        {
            var collages = await _collageService.GetAllCollage();
            return View(collages);
            
        }

        [HttpGet]
        public IActionResult CreateCollage()
        {
            return View();

        }

        [HttpPost]
        public IActionResult CreateCollage(CollageViewModel collage)
        {
            if (!ModelState.IsValid)
            {
                return View(collage);
            }
            _collageService.Add(collage);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> EditCollage(int id, string querystringData)
        {
            Collage collage = await _collageService.GetCollage(id);
            var data = new CollageViewModel()
            {
                Collage_Name = collage.Collage_Name,
                Address = collage.Address,
                Grade = collage.Grade,
                Code = collage.Code,

            };
            return View(data);
        }


        [HttpPost]
        public async Task<IActionResult> EditCollage(CollageViewModel modifiedData)
        {

            if (!ModelState.IsValid)
            {
                return View(modifiedData);
            }
            Collage collage = await _collageService.GetCollage(modifiedData.Id);
            collage.Collage_Name = modifiedData.Collage_Name;
            collage.Address = modifiedData.Address;
            collage.Grade = modifiedData.Grade;
            collage.Code = modifiedData.Code;
            Collage updatedCollage = _collageService.Update(collage);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetCollage(int id)
        {
            Collage collage = await _collageService.GetCollage(id);
            // return RedirectToAction("Index",collage);
            List<Collage> collages = new List<Collage>();
            collages.Add(collage);
            return View("Index", collages);
        }

        public IActionResult DeleteCollage(int id)
        {
            _collageService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
