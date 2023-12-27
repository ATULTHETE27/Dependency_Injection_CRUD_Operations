using Asp.netCoreMVCIntro.Service;
using Microsoft.AspNetCore.Mvc;

namespace Asp.netCoreMVCIntro.ViewComponents
{
    public class CollageMenuViewComponent : ViewComponent
    {
        private readonly ICollageService _CollageService;
        public CollageMenuViewComponent(ICollageService collageService)
        {
            _CollageService = collageService;
        }

        //Asynchronous method
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var collages = await _CollageService.GetAllCollage();
            return View(collages);
        }
    }
}
