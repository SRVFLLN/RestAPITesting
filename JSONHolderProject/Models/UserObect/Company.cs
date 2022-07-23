using Newtonsoft.Json;

namespace JSONHolderProject.Models
{
    [JsonObject("company")]
    public class Company
    {
        [JsonProperty("name")]
        public string CompanyName { get; set; }
        [JsonProperty("catchPhrase")]
        public string CatchPhrase { get; set; }
        [JsonProperty("bs")]
        public string Bs { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Company company &&
                   CompanyName == company.CompanyName &&
                   CatchPhrase == company.CatchPhrase &&
                   Bs == company.Bs;
        }
    }
}
