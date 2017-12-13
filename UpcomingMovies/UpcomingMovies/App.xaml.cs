using System.Collections.Generic;
using Xamarin.Forms;

namespace UpcomingMovies
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new UpcomingMovies.Views.MoviesList(null));
        }

        protected override async void OnStart()
        {
            UpcomingMovies.DAO.Movie movieDAO = new UpcomingMovies.DAO.Movie();
            List<UpcomingMovies.Entities.Movie> movieList = await movieDAO.GetUpcomingMovies();

            if (movieList != null)
            {
                MainPage = new NavigationPage(new UpcomingMovies.Views.MoviesList(movieList));
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
