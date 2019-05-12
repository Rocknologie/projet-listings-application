using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Listings_Schmidt_Surieux.Models
{
    public class API_Response_Listings
    {
        [JsonProperty("success")]
        public string Success { get; set; }

        [JsonProperty("listings")]
        public List<Listing> Listings { get; set; }
    }
}
