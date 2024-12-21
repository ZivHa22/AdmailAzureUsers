using Microsoft.AspNetCore.Mvc;

namespace AdmailAzureUsers.Controllers
{
    public class AdmailAzureUsersApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
