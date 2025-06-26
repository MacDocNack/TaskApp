using System.Text.Json.Serialization;

namespace TaskAppWeb.Models
{
    public record Task
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Description")]
        public string Description { get; set; }
        [JsonPropertyName("TaskDate")]
        public DateTime TaskDate { get; set; }
        [JsonPropertyName("Priority")]
        public string Priority { get; set; }
        [JsonPropertyName("Category")]
        public string Category { get; set; }
        [JsonPropertyName("State")]
        public bool State { get; set; }
    }
}
