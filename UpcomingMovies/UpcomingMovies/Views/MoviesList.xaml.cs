using System.Collections.Generic;
using System.Linq;
using UpcomingMovies.Entities;
using Xamarin.Forms;

namespace UpcomingMovies.Views
{
    public partial class MoviesList : ContentPage
    {
        public MoviesList(List<UpcomingMovies.Entities.Movie> movieList)
        {
            InitializeComponent();
            if (movieList != null)
            {
                UpcomingMoviesList.ItemsSource = movieList;
            }
        }

        private void UpcomingMoviesList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Movie movie = (Movie)e.Item;
            Navigation.PushAsync(new MovieDetailed(movie.Id));
        }

        private async void BntSearch_Clicked(object sender, System.EventArgs e)
        {
            string Query = SearchText.Text;
            UpcomingMovies.DAO.Movie movieDAO = new UpcomingMovies.DAO.Movie();
            List<UpcomingMovies.Entities.Movie> movieList = await movieDAO.GetUpcomingMovies(); //FIXME: Can be improved, I already had the original list

            if (!string.IsNullOrEmpty(Query))
            {
                movieList = movieList.Where(m => m.Title.Contains(Query)).ToList();
            }
            
            await Navigation.PushAsync(new MoviesList(movieList));
        }
    }
}
