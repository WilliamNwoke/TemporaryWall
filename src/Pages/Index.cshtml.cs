using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Model for the Index Page
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

        // Retrieves Product Service
        public JsonFileProductService ProductService { get; }
        public IEnumerable<ProductModel> Products { get; private set; }

        // Retrieves Products using razor component
        public void OnGet()
        {
            Products = ProductService.GetProducts();
        }
    }
    public class MemberIndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public MemberIndexModel(ILogger<IndexModel> logger,
            JsonFileMemberService memberService)
        {
            _logger = logger;
            MemberService = memberService;
        }

        // Retrieves Product Service
        public JsonFileMemberService MemberService { get; }
        public IEnumerable<MemberModel> Members { get; private set; }

        // Retrieves Products using razor component
        public void OnGet()
        {
            Members = MemberService.GetMembers();
        }
    }
}
