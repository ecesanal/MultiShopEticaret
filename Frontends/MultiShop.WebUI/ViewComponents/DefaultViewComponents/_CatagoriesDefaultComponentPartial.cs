using Microsoft.AspNetCore.Mvc;
namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CatagoriesDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
