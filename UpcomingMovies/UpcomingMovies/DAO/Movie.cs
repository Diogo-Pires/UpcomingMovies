using ConsumingWebServices.DAO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UpcomingMovies.DAO
{
    class Movie
    {
        private string Method;
        private string Url;
        private string ResponseString;

        public async Task<List<Entities.Movie>> GetUpcomingMovies()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"Page", "1"}
            };
            this.Method = "movie/upcoming";
            this.Url = TheMovieDBConnection.mountURLToConsume(this.Method, parameters);
            RootObject root = null;

            try
            {
                this.ResponseString = await TheMovieDBConnection.callAPI(this.Url);

                if (!String.IsNullOrEmpty(this.ResponseString))
                {
                    root = JsonConvert.DeserializeObject<RootObject>(this.ResponseString);
                }
                
                return root.movies;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Entities.Movie> getMovieById(int Id)
        {
            this.Method = "movie/" + Id.ToString();
            this.Url = TheMovieDBConnection.mountURLToConsume(this.Method, null);
            Entities.Movie movie = null;

            try
            {
                this.ResponseString = await TheMovieDBConnection.callAPI(this.Url);

                if (!String.IsNullOrEmpty(this.ResponseString))
                {
                    movie = JsonConvert.DeserializeObject<Entities.Movie>(this.ResponseString);
                }

                return movie;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Entities.Movie>> searchMovieByName(string query)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"query", query}
            };
            this.Method = "search/movie";
            this.Url = TheMovieDBConnection.mountURLToConsume(this.Method, parameters);
            RootObject root = null;

            try
            {
                this.ResponseString = await TheMovieDBConnection.callAPI(this.Url);

                if (!String.IsNullOrEmpty(this.ResponseString))
                {
                    root = JsonConvert.DeserializeObject<RootObject>(this.ResponseString);
                }

                return root.movies;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
