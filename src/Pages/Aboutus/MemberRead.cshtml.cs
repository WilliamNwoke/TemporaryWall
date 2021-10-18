using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Aboutus
{
    public class ReadModel : PageModel
    {
        // Data middletier
        public JsonFileMemberService MemberService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="memberService"></param>
        public ReadModel(JsonFileMemberService memberService)
        {
            MemberService = memberService;
        }

        // The data to show
        public MemberModel Member;

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            Member  = MemberService.GetMembers().FirstOrDefault(m => m.Id.Equals(id));
        }
    }
}