namespace UpcomingMovies.Util
{
    static class TheMovieDBImages
    {
        private const string IMAGE_URL_TOCONSUME = "https://image.tmdb.org/t/p/";

        public enum AvailableImagesSizes
        {
            w92,
            w145,
            w185,
            w342,
            w500,
            w780,
            original
        }

        static public string getImageForMobile(string imageFile)
        {
            return IMAGE_URL_TOCONSUME + AvailableImagesSizes.w185.ToString() + imageFile;
        }
    }
}
