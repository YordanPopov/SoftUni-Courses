using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializingWithJsonNet
{
    public class Products
    {
        [JsonProperty("product")]
        public string Product { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("keyWords")]
        public string[] KeyWords { get; set; }

        public Products(string product, double price, string description, string[] keyWords)
        {
            this.Product = product;
            this.Price = price;
            this.Description = description;
            this.KeyWords = keyWords;
        }
    }
}
