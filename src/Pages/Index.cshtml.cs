using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
<<<<<<< HEAD
    /// Kramer Johnson made a change
    /// Henry Song
=======
    /// Kramer Johnson
    /// Henry Song - for GitHub lab excercise #3
>>>>>>> 4dc4f8b2afc6e945f3c53070faf420b0900e6eef
    /// Zhicong Zeng
    /// Uchenna Nwoke
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }
        public IEnumerable<ProductModel> Products { get; private set; }

        public void OnGet()
        {
            Products = ProductService.GetProducts();
        }
    }
}
