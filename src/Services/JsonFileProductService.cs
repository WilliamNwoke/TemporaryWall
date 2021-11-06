using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

using ContosoCrafts.WebSite.Models;

using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{
    public class JsonFileProductService
    {
        /// <summary>
        /// Initiated JsonFileProductService
        /// </summary>
        /// <param name="webHostEnvironment">environment</param>
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        // Retrieves web host environment
        public IWebHostEnvironment WebHostEnvironment { get; }

        /// <summary>
        /// Returns file path of product json database
        /// </summary>
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
        }

        /// <summary>
        /// Retrieves products
        /// </summary>
        /// <returns>iterable list of products</returns>
        public IEnumerable<ProductModel> GetProducts()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);//Use simple 'using' statement (IDE0063)
            {
                return JsonSerializer.Deserialize<ProductModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        /// <summary>
        /// Adds a rating to the specified product ID
        /// </summary>
        /// <param name="productId">ID of specific product</param>
        /// <param name="rating">Rating to be added</param>
        public bool AddRating(string productId, int rating)
        {
            // If the ProductID is invalid, return
            if (string.IsNullOrEmpty(productId))
            {
                return false;
            }

            var products = GetProducts();

            // Look up the product, if it does not exist, return
            var data = products.FirstOrDefault(x => x.Id.Equals(productId));
            if (data == null)
            {
                return false;
            }

            // Check Rating for boundries, do not allow ratings below 0
            if (rating < 0)
            {
                return false;
            }

            // Check Rating for boundries, do not allow ratings above 5
            if (rating > 5)
            {
                return false;
            }

            // Check to see if the rating exist, if there are none, then create the array
            if (data.Ratings == null)
            {
                data.Ratings = new int[] { };
            }

            // Add the Rating to the Array
            var ratings = data.Ratings.ToList();
            ratings.Add(rating);
            data.Ratings = ratings.ToArray();

            // Save the data back to the data store
            SaveData(products);

            return true;
        }

        /// <summary>
        /// Adds a comment to the specified product ID
        /// </summary>
        /// <param name="productId">ID of specific product</param>
        /// <param name="comment">Comment to be added</param>
        public void AddComment(string productId, string comment)
        {
            var products = GetProducts();

            if (products.First(x => x.Id == productId).Comments == null)
            {
                //creates new list of comments
                products.First(x => x.Id == productId).Comments = new string[] { comment };
            }
            else
            {
                //adds comment to existing comments list
                var comments = products.First(x => x.Id == productId).Comments.ToList();
                comments.Add(comment);
                products.First(x => x.Id == productId).Comments = comments.ToArray();
            }

            SaveData(products);
        }

        /// <summary>
        /// Save All products data to storage
        /// </summary>
        private void SaveData(IEnumerable<ProductModel> products)
        {

            using var outputStream = File.Create(JsonFileName);//Use simple 'using' statement (IDE0063)
            {
                JsonSerializer.Serialize<IEnumerable<ProductModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products
                );
            }
        }

        /// <summary>
        /// Find the data record
        /// Update the fields
        /// Save to the data store
        /// </summary>
        /// <param name="data"></param>
        public ProductModel UpdateData(ProductModel data)
        {
            var products = GetProducts();
            var productData = products.FirstOrDefault(x => x.Id.Equals(data.Id));
            if (productData == null)
            {
                return null;
            }

            productData.Artist = data.Artist;
            productData.Title = data.Title;            
            productData.Description = data.Description;
            productData.Image = data.Image;

            SaveData(products);

            return productData;
        }

        /// <summary>
        /// Create a new product using default values
        /// After create the user can update to set values
        /// </summary>
        /// <returns></returns>
        public ProductModel CreateData()
        {
            var data = new ProductModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Artist = "",
                Title = "",
                Description = "",
                Image = "",
            };

            // Get the current set, and append the new record to it becuase IEnumerable does not have Add
            var dataSet = GetProducts();
            dataSet = dataSet.Append(data);

            SaveData(dataSet);

            return data;
        }

        /// <summary>
        /// Remove the item from the system
        /// </summary>
        /// <returns></returns>
        public ProductModel DeleteData(string id)
        {
            // Get the current set, and append the new record to it
            var dataSet = GetProducts();
            var data = dataSet.FirstOrDefault(m => m.Id.Equals(id));

            var newDataSet = GetProducts().Where(m => m.Id.Equals(id) == false);

            SaveData(newDataSet);

            return data;
        }

        /// <summary>
        /// Finds the average rating of a product
        /// </summary>
        /// <param name="product">ProductModel of the product to find the average ratings for</param>
        /// <returns></returns>
        public int GetAverageRating(ProductModel product)
        {
            int currentRating = 0;
            int voteCount = 0;
            string voteLabel;
            //Checks if there are ratings
            if (product.Ratings == null) // product with no ratings
            {
                currentRating = 0;
                voteCount = 0;
            }
            else // product with ratings
            {
                voteCount = product.Ratings.Count(); //retrieves number of votes
                voteLabel = voteCount > 1 ? "Votes" : "Vote";
                currentRating = product.Ratings.Sum() / voteCount; //calculates average of all votes
            }

            return currentRating;
        }


        /// <summary>
        /// Finds the 5 highest rated artworks of all the artworks
        /// </summary>
        /// <returns>Tuple of (productID, rating) top 3 highest rated artworks</returns>
        public List<ProductModel> GetHighestRatedArtwork()
        {
            //Initiate List
            var listOfID = new List<(string, int)>();

            //Gets Product List
            var dataset = GetProducts();

            //finds the average rating of each artwork and adds it and product ID to list
            foreach (var product in dataset)
            {
                listOfID.Add((product.Id, GetAverageRating(product)));
            }

            //sort list in decending order by item2 of tuple (the rating)
            //so that the highest rated will be at beginnning of list
            listOfID = listOfID.OrderByDescending(x => x.Item2).ToList();

            List<ProductModel> topThree = new List<ProductModel>();

            //Add product with corresponding ID of top three products to topThree
            foreach (var item in listOfID.GetRange(0, 3))
            {
                foreach (var art in dataset)
                {
                    if (item.Item1 == art.Id)
                    {
                        topThree.Add(art);
                    }
                }
            }



            //return first 5 entries of list (top 3 highest rated products)
            return topThree;
        }
    }
}