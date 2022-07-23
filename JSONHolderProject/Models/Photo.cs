using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JSONHolderProject.Models
{
    public class Photo : IResource
    {
        [JsonProperty("albumId")]
        public int AlbumId { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Photo photo &&
                   AlbumId == photo.AlbumId &&
                   Id == photo.Id &&
                   Title == photo.Title &&
                   Url == photo.Url &&
                   ThumbnailUrl == photo.ThumbnailUrl;
        }
    }
}
