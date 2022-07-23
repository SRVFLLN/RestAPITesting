using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace JSONHolderProject.Models
{
    public class Post : IResource
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Post post &&
                   UserId == post.UserId &&
                   Id == post.Id &&
                   Title == post.Title &&
                   Body == post.Body;
        }
    }
}
