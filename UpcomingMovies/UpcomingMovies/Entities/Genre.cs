using Newtonsoft.Json;

namespace UpcomingMovies.Entities
{
    public class Genre
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
