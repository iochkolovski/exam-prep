using System.Text.Json.Serialization;

namespace RestSharpAPITests.Models
{
    public class CreateTaskResponse
    {
        [JsonPropertyName("msg")]
        public string msg { get; set; }

        [JsonPropertyName("task")]
        public TaskResponse task { get; set; }
    }
}
