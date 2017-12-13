using Newtonsoft.Json;

namespace UpcomingMovies.Entities
{
    public class ProductionCompany
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
