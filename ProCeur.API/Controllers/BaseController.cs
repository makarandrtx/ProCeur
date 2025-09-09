using Microsoft.AspNetCore.Mvc;

namespace ProCeur.API.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// write generic basecontroller 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return Ok(200);
        }
    }
}
