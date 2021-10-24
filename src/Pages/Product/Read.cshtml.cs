using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using System.ComponentModel.DataAnnotations;

namespace ContosoCrafts.WebSite.Pages.Product
{
    public class ReadModel : PageModel
    {
        // Comment variable required and max length
        [BindProperty]
        [Required]
        [MaxLength(250)]
        [MinLength(1)]
        public string Comment { get; set; }

        // The data to show, bind to it for the post
        [BindProperty]
        public ProductModel Product { get; set; }

        // Data middletier
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public ReadModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            Product  = ProductService.GetProducts().FirstOrDefault(m => m.Id.Equals(id));
        }

        /// <summary>
        /// REST Post request to add a comment
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            //var comment = Request.Form["comment"];

            if (!ModelState.IsValid)
            {
                return RedirectToPage("./Read");
            }

            ProductService.AddComment(Product.Id, Comment);

            return RedirectToPage("./Read");
        }
    }
}