using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JSONHolderProject.Models
{
    public class Comment : IResource
    {
        [JsonProperty("postId")]
        public int PostId { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Comment comment &&
                   PostId == comment.PostId &&
                   Id == comment.Id &&
                   Name == comment.Name &&
                   Email == comment.Email &&
                   Body == comment.Body;
        }
    }
}
