using Newtonsoft.Json;
using System.Collections.Generic;

namespace JSONHolderProject.Models
{
    public class User : IResource
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("address")]
        public Adress Adress { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   Id == user.Id &&
                   Name == user.Name &&
                   Username == user.Username &&
                   Email == user.Email &&
                   EqualityComparer<Adress>.Default.Equals(Adress, user.Adress) &&
                   Phone == user.Phone &&
                   Website == user.Website &&
                   EqualityComparer<Company>.Default.Equals(Company, user.Company);
        }
    }
}
