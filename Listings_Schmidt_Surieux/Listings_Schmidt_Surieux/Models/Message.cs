using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Listings_Schmidt_Surieux.Models;

namespace Listings_Schmidt_Surieux.Models
{

    [Table("Message")]
    public class Message
    { 
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("listing")]
        public string Listing { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }
    }
}
