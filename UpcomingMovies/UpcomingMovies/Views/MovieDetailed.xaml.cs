using UpcomingMovies.Entities;
using UpcomingMovies.Util;
using Xamarin.Forms;

namespace UpcomingMovies.Views
{
    public partial class MovieDetailed : ContentPage
    {
        public int Id;
        public string MovieTitle { get; set; }
        public string ReleaseDate { get; set; }
        public string PosterPath { get; set; }
        public string Genre { get; set; }
        public string Overview { get; set; }

        public MovieDetailed(int Id)
        {
            InitializeComponent();
            this.Id = Id;
        }
        protected override async void OnAppearing() 
        {
            UpcomingMovies.DAO.Movie movieDAO = new UpcomingMovies.DAO.Movie();
            Movie movie = await movieDAO.getMovieById(this.Id);

            Title = movie.Title;
            MovieTitle = movie.Title;
            ReleaseDate = movie.ReleaseDateString;
            PosterPath = TheMovieDBImages.getImageForMobile(movie.PosterPath);
            Genre = string.Join(", ", movie.Genres);
            Overview = movie.Overview;


            BindingContext = this;
        }
    }
}
