using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Model for the About Us Page
    /// </summary>
    public class AboutUsModel : PageModel
    {
        private readonly ILogger<AboutUsModel> _logger;

        public AboutUsModel(ILogger<AboutUsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {   
        }
    }
}
