using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

using ContosoCrafts.WebSite.Models;

using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{
   public class JsonFileMemberService
    {
        /// <summary>
        /// Initiated JsonFileMemberService
        /// </summary>
        /// <param name="webHostEnvironment">environment</param>
        public JsonFileMemberService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        /// <summary>
        /// Returns file path of member json database
        /// </summary>
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "members.json"); }
        }

    }
}