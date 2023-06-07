using ASP.NET_Ajax_Json_CRUD.Models;
using ASP.NET_Ajax_Json_CRUD.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace ASP.NET_Ajax_Json_CRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly ILogger<HomeController> _logger;        

        public HomeController(ILogger<HomeController> logger, IItemRepository itemRepository)
        {
            _logger = logger;
            _itemRepository = itemRepository;
        }

        // GET: InventoryController
        [HttpGet]
        public ActionResult Inventory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Inventory(ItemVM inventoryItemId)
        {
            await _itemRepository.AddItem(inventoryItemId);
            return RedirectToAction(nameof(Inventory));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}