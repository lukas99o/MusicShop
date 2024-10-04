using Microsoft.AspNetCore.Mvc;
using MusicShop.Models;

namespace MusicShop.Controllers
{

    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        [Route("GetMusicInstruments")]

        public IActionResult GetAll() 
        
        {
        
         List<Products> products = new List<Products>();    
        

            return View(products);  
        }
    }
}
