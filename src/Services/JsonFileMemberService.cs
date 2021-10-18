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
        /// Initiated JsonFileProductService
        /// </summary>
        /// <param name="webHostEnvironment">environment</param>
        public JsonFileMemberService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        /// <summary>
        /// Returns file path of product json database
        /// </summary>
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "members.json"); }
        }

        /// <summary>
        /// Retrieves products
        /// </summary>
        /// <returns>iterable list of products</returns>
        public IEnumerable<MemberModel> GetMembers()
        {
            using(var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<MemberModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
        /*
        /// <summary>
        /// Adds a rating to the specified product ID
        /// </summary>
        /// <param name="productId">ID of specific product</param>
        /// <param name="rating">Rating to be added</param>
        public void AddRating(string productId, int rating)
        {
            var products = GetProducts();

            if(products.First(x => x.Id == productId).Ratings == null)
            {
                //creates new list of ratings
                products.First(x => x.Id == productId).Ratings = new int[] { rating };
            }
            else
            {
                //adds rating to existing ratings list
                var ratings = products.First(x => x.Id == productId).Ratings.ToList();
                ratings.Add(rating);
                products.First(x => x.Id == productId).Ratings = ratings.ToArray();
            }

            SaveData(products);
        }*/

        /// <summary>
        /// Save All products data to storage
        /// </summary>
        private void SaveData(IEnumerable<MemberModel> members)
        {

            using (var outputStream = File.Create(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<MemberModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    members
                );
            }
        }

        /// <summary>
        /// Find the data record
        /// Update the fields
        /// Save to the data store
        /// </summary>
        /// <param name="data"></param>
        public MemberModel UpdateData(MemberModel data)
        {
            var members = GetMembers();
            var memberData = members.FirstOrDefault(x => x.Id.Equals(data.Id));
            if (memberData == null)
            {
                return null;
            }

            memberData.Title = data.Title;
            memberData.Description = data.Description;
            memberData.Url = data.Url;
            memberData.Image = data.Image;

            SaveData(members);

            return memberData;
        }

        /// <summary>
        /// Create a new product using default values
        /// After create the user can update to set values
        /// </summary>
        /// <returns></returns>
        public MemberModel CreateData()
        {
            var data = new MemberModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Title = "Enter Title",
                Description = "Enter Description",
                Url = "Enter URL",
                Image = "",
            };

            // Get the current set, and append the new record to it becuase IEnumerable does not have Add
            var dataSet = GetMembers();
            dataSet = dataSet.Append(data);

            SaveData(dataSet);

            return data;
        }

        /// <summary>
        /// Remove the item from the system
        /// </summary>
        /// <returns></returns>
        public MemberModel DeleteData(string id)
        {
            // Get the current set, and append the new record to it
            var dataSet = GetMembers();
            var data = dataSet.FirstOrDefault(m => m.Id.Equals(id));

            var newDataSet = GetMembers().Where(m => m.Id.Equals(id) == false);

            SaveData(newDataSet);

            return data;
        }
    }
}