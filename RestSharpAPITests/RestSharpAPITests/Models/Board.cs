using System.Text.Json.Serialization;

namespace RestSharpAPITests.Models
{
    public class Board
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }
    }
}
