
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Aboutus
{
    /// <summary>
    /// Create Page
    /// </summary>
    public class CreateModel : PageModel
    {
        // Data middle tier
        public JsonFileMemberService MemberService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="memberService"></param>
        public CreateModel(JsonFileMemberService memberService)
        {
            MemberService = memberService;
        }

        // The data to show
        public MemberModel Member;

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public IActionResult OnGet()
        {
            Member  = MemberService.CreateData();

            // Redirect the webpage to the Update page populated with the data so the user can fill in the fields
            return RedirectToPage("./Update", new { Id = Member.Id });
        }
    }
}