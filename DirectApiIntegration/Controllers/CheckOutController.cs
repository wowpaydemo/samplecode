using Microsoft.AspNetCore.Mvc;

namespace DirectApiIntegration.Controllers
{
    public class CheckOutController : Controller
    {
        public IActionResult CheckOut()
        {
            return View();
        }
    }
}
