using Microsoft.AspNetCore.Mvc;

namespace HostedPage.Controllers
{
    public class CheckOutController : Controller
    {
        //[HttpGet("checkoutpage")]
        public IActionResult CheckOut()
        {
            return View();
        }
    }
}
