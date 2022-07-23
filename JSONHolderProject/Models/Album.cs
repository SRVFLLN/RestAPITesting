using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JSONHolderProject.Models
{
    public class Album : IResource
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Album album &&
                   UserId == album.UserId &&
                   Id == album.Id &&
                   Title == album.Title;
        }
    }
}
