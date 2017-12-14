using Newtonsoft.Json;
using System.Collections.Generic;
using UpcomingMovies.Entities;

namespace ConsumingWebServices.DAO
{
    class RootObject
    {
        public int page { get; set; }
        [JsonProperty("results")]
        public List<Movie> movies { get; set; }
        public Dates dates { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
