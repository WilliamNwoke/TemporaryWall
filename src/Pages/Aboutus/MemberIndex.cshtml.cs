using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Aboutus
{
    /// <summary>
    /// Index Page will return all the data to show
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="memberService"></param>
        public IndexModel(JsonFileMemberService memberService)
        {
            MemberService = memberService;
        }

        // Data Service
        public JsonFileMemberService MemberService { get; }
        
        // Collection of the Data
        public IEnumerable<MemberModel> Members { get; private set; }

        /// <summary>
        /// REST OnGet, return all data
        /// </summary>
        public void OnGet()
        {
            Members = MemberService.GetMembers();
        }
    }
}