using MediaCatalogue_API.Models;
using MediaCatalogue_WPF.Interactors;
using MediaCatalogue_WPF.Interactors.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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

        public ObservableCollection<Actor> actors { get; set; }

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

            //string[] items = { "Fido", "Spark", "Fluffy" };

            //// ... Assign ItemsSource of DataGrid.
            //dgSearchResults.ItemsSource = items;

            actors = new ObservableCollection<Actor>();
            actors.Add(new Actor() { Name = "One" });
            actors.Add(new Actor() { Name = "Two" });
            actors.Add(new Actor() { Name = "Three" });
            actors.Add(new Actor() { Name = "Four" });
            actors.Add(new Actor() { Name = "Five" });

            //string[] items = { "Fido", "Spark", "Fluffy" };

            //// ... Assign ItemsSource of DataGrid.
            //var grid = sender as DataGrid;
            //grid.ItemsSource = items;


            ////DataItem item = new DataItem();
            ////item.Column1 = true;
            ////item.Column2 = "test";
            ////dgSearchResults.Items.Add(new ItemCollection( {  });

            //dgSearchResults.ItemsSource = actors;
        }

        private void dgSearchResults_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        
    }
}
