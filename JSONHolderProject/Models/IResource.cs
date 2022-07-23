using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JSONHolderProject.Models
{
    public interface IResource
    {
        [JsonProperty("id")]
        int Id { get; set; }
    }
}
