using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    /// <summmary>
    /// Controller class for the products.json
    /// </summmary>
    public class ProductsController : ControllerBase
    {   
        // Product service method
        public ProductsController(JsonFileProductService productService)
        {
            ProductService = productService;
        }
        // Product service get function
        public JsonFileProductService ProductService { get; }

        [HttpGet]
        //Product service http get function
        public IEnumerable<ProductModel> Get()
        {
            return ProductService.GetProducts();
        }

        [HttpPatch]
        // product service rating method
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            ProductService.AddRating(request.ProductId, request.Rating);

            return Ok();
        }


        // get set method for rating
        public class RatingRequest
        {
            public string ProductId { get; set; }
            public int Rating { get; set; }
        }

        [HttpPatch]
        // Product Add comment method
        public ActionResult Patch([FromBody] CommentRequest request)
        {
            ProductService.AddComment(request.ProductId, request.Comment);

            return Ok();
        }

        /// <summary>
        /// comment request class
        /// </summary>
        public class CommentRequest
        {
            // get set method for the product ID
            public string ProductId { get; set; }

            // get set method for the comment
            public string Comment { get; set; }
        }
    }
}