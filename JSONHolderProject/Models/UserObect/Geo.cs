using Newtonsoft.Json;

namespace JSONHolderProject.Models
{
    [JsonObject("geo")]
    public class Geo
    {
        [JsonProperty("lat")]
        public string Lat { get; set; }
        [JsonProperty("lng")]
        public string Lng { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Geo geo &&
                   Lat == geo.Lat &&
                   Lng == geo.Lng;
        }
    }
}
