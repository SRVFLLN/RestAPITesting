using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JSONHolderProject.Models
{
    public class ToDo : IResource
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("completed")]
        public string Completed { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ToDo @do &&
                   UserId == @do.UserId &&
                   Id == @do.Id &&
                   Title == @do.Title &&
                   Completed == @do.Completed;
        }
    }
}
