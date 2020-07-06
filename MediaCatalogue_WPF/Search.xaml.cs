using MediaCatalogue_API.Models;
using MediaCatalogue_WPF.Interactors.Interfaces;
using MediaCatalogue_WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace MediaCatalogue_WPF
{
    /// <summary>
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Search : Window
    {
        private ISearchInteractor _searchInteractor;
        private IGenreInteractor _genreInteractor;
        private IActorInteractor _actorInteractor;
        private ICrewInteractor _crewInteractor;

        private string _searchQuery;

        public ObservableCollection<Movie> movies { get; set; }

        public Search(ISearchInteractor searchInteractor, IGenreInteractor genreInteractor, IActorInteractor actorInteractor,
            ICrewInteractor crewInteractor, string searchQuery)
        {
            InitializeComponent();

            _searchInteractor = searchInteractor;
            _genreInteractor = genreInteractor;
            _actorInteractor = actorInteractor;
            _crewInteractor = crewInteractor;
            _searchQuery = searchQuery;

            lblResults.Content = "Search results for '" + _searchQuery + "'";

            PopulateDataGrid(searchQuery);
        }

        private void PopulateDataGrid(string searchQuery)
        {
            var emptyList = new List<Tuple<string, string, int, string>>()
                        .Select(t => new { Title = t.Item1, Location = t.Item2, Year = t.Item3, Genre = t.Item4 }).ToList();

            ResponseModel<Movie> searchResult = _searchInteractor.SearchMovieByTitle(searchQuery);

            foreach (Movie movie in searchResult.Data)
            {
                emptyList.Add(new { Title = movie.Title, Location = movie.Location, Year = movie.Year, Genre = movie.Genre.Name });
            }

            dgSearchResults.ItemsSource = emptyList;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            dynamic item = dgSearchResults.SelectedItem;
            
            Edit edit = new Edit(_searchInteractor, _genreInteractor, _actorInteractor, _crewInteractor,
                item);
            edit.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not implemented yet");
        }
    }
}
