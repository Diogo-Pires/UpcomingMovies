using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace UpcomingMovies.DAO
{
    static class TheMovieDBConnection
    {
        private static HttpClient Cliente;
        private static HttpResponseMessage Response;
        private const string API_KEY = "1f54bd990f1cdfb230adb312546d765d";
        private const string URL_TO_CONSUME = "https://api.themoviedb.org/3/";
        private const string LANGUAGE = "en-US";

        static TheMovieDBConnection()
        {
            Cliente = new HttpClient();
            Cliente.BaseAddress = new Uri(URL_TO_CONSUME);
            Cliente.DefaultRequestHeaders.Accept.Clear();
            Cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static string mountURLToConsume(string method, Dictionary<string, string> parameters)
        {
            string UrlToConsume = URL_TO_CONSUME + method + "?api_key=" + API_KEY + "&language=" + LANGUAGE;
            if(parameters != null)
            {
                foreach (KeyValuePair<string, string> query_string in parameters)
                {
                    UrlToConsume += "&" + query_string.Key + "=" + query_string.Value;
                }
            }
            
            return UrlToConsume;
        }

        public async static Task<string> callAPI(string url)
        {
            string ResponseString = null;
            try
            {
                Response = await Cliente.GetAsync(url);
                if (Response.IsSuccessStatusCode)
                {
                    ResponseString = await Response.Content.ReadAsStringAsync();
                }

                return ResponseString;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Response = null;
            }
        }
    }
}
