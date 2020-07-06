using MediaCatalogue_API.Models;
using MediaCatalogue_WPF.Interactors;
using MediaCatalogue_WPF.Interactors.Interfaces;
using MediaCatalogue_WPF.Models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MediaCatalogue_WPF
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Window
    {
        private ISearchInteractor _searchInteractor;
        private IGenreInteractor _genreInteractor;
        private IActorInteractor _actorInteractor;
        private ICrewInteractor _crewInteractor;

        public Create(ISearchInteractor searchInteractor, IGenreInteractor genreInteractor, IActorInteractor actorInteractor,
            ICrewInteractor crewInteractor)
        {
            InitializeComponent();

            _searchInteractor = searchInteractor;
            _genreInteractor = genreInteractor;
            _actorInteractor = actorInteractor;
            _crewInteractor = crewInteractor;
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

            MovieInteractor mi = new MovieInteractor(_searchInteractor, _genreInteractor, _actorInteractor, _crewInteractor);
            ResponseModel<Movie> response = mi.AddMovie(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                Success();
            else
                Failure(response.Message);
        }

        private void Success()
        {
            MessageBox.Show("Operation completed successfully.");

            txtActor.Clear();
            txtDirector.Clear();
            txtGenre.Clear();
            txtLocation.Clear();
            txtTitle.Clear();
            txtYear.Clear();
        }

        private void Failure(string message)
        {
            MessageBox.Show(string.Format("An error occurred. {0}. Please try again.", message));
        }
    }
}
