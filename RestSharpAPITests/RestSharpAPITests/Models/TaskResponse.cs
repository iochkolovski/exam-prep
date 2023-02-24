using System.Text.Json.Serialization;

namespace RestSharpAPITests.Models
{
    public class TaskResponse
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("title")]
        public string title { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonPropertyName("board")]
        public Board board { get; set; }

        [JsonPropertyName("dateCreated")]
        public string dateCreated { get; set; }

        [JsonPropertyName("dateModified")]
        public string dateModified { get; set; }
    }


}
