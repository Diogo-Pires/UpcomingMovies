using Newtonsoft.Json;

namespace UpcomingMovies.Entities
{
    public class ProductionCountry
    {
        [JsonProperty("iso_3166_1")]
        public string Iso31661 { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
