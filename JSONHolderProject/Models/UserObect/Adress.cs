using Newtonsoft.Json;
using System.Collections.Generic;

namespace JSONHolderProject.Models
{
    [JsonObject("address")]
    public class Adress
    {
        [JsonProperty("street")]
        public string Street { get; set; }
        [JsonProperty("suite")]
        public string Suite { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("zipcode")]
        public string Zipecode { get; set; }
        [JsonProperty("geo")]
        public Geo Geo { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Adress adress &&
                   Street == adress.Street &&
                   Suite == adress.Suite &&
                   City == adress.City &&
                   Zipecode == adress.Zipecode &&
                   EqualityComparer<Geo>.Default.Equals(Geo, adress.Geo);
        }
    }
}