using MediaCatalogue_API.Models;
using MediaCatalogue_WPF.Interactors;
using MediaCatalogue_WPF.Interactors.Interfaces;
using MediaCatalogue_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace MediaCatalogue_WPF
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        private ISearchInteractor _searchInteractor;
        private IGenreInteractor _genreInteractor;
        private IActorInteractor _actorInteractor;
        private ICrewInteractor _crewInteractor;
        private dynamic _item;

        private int _movieId;
        private int _directorId;
        private Dictionary<int, string> _actor = new Dictionary<int, string>();
        private int _genreId;

        public Edit(ISearchInteractor searchInteractor, IGenreInteractor genreInteractor, IActorInteractor actorInteractor,
            ICrewInteractor crewInteractor, dynamic item)
        {
            InitializeComponent();

            _searchInteractor = searchInteractor;
            _genreInteractor = genreInteractor;
            _actorInteractor = actorInteractor;
            _crewInteractor = crewInteractor;

            _item = item;

            Load();
        }

        private void Load()
        {
            MovieInteractor mi = new MovieInteractor(_searchInteractor, _genreInteractor, _actorInteractor,
                _crewInteractor);

            ResponseModel<Movie> movieSearchResult = _searchInteractor.SearchMovieByTitle(_item.Title);

            txtTitle.Text = movieSearchResult.Data[0].Title;
            txtYear.Text = movieSearchResult.Data[0].Year.ToString();
            txtGenre.Text = movieSearchResult.Data[0].Genre.Name;
            _genreId = movieSearchResult.Data[0].Genre.Id;

            txtLocation.Text = movieSearchResult.Data[0].Location;
            _movieId = movieSearchResult.Data[0].Id;

            ResponseModel<Actor> actorSearchResult = _searchInteractor.SearchActorsByMovie(_item.Title);
            string actors = string.Join(",", actorSearchResult.Data.Select(a => a.Name));
            txtActor.Text = actors;

            foreach(Actor actor  in actorSearchResult.Data)
            {
                _actor.Add(actor.Id, actor.Name);
            }

            ResponseModel<Crew> crewSearchResult = _searchInteractor.SearchCrewByMovie(_item.Title);
            txtDirector.Text = crewSearchResult.Data[0].Name;
            _directorId = crewSearchResult.Data[0].Id;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {            
            MovieRequestModel request = new MovieRequestModel()
            {
                Actors = new List<string>(),
                Director = txtDirector.Text,
                Genre = txtGenre.Text,
                Location = txtLocation.Text,
                Title = txtTitle.Text,
                Year = Convert.ToInt32(txtYear.Text)
            };

            string[] actors = txtActor.Text.Split(',');
            request.Actors.AddRange(actors);

            // add the id's
            request.UpdateId = new MediaCatalogue_WPF.Models.UpdateId()
            {
                ActorIds = _actor,
                DirectorId = _directorId,
                GenreId = _genreId,
                MovieId = _movieId
            };

            MovieInteractor mi = new MovieInteractor(_searchInteractor, _genreInteractor, _actorInteractor, _crewInteractor);
            ResponseModel<Movie> response = mi.UpdateMovie(request);

            if (response.Message.Equals("OK"))
                Success();
            else
                Failure(response.Message);
        }

        private void Success()
        {
            MessageBox.Show("Operation completed successfully.");
        }

        private void Failure(string message)
        {
            MessageBox.Show(string.Format("An error occurred. {0}. Please try again.", message));
        }
    }
}
