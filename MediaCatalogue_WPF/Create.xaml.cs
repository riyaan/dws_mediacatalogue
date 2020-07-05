using MediaCatalogue_WPF.Interactors;
using MediaCatalogue_WPF.Models;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Window
    {
        private ISearchInteractor _searchInteractor;
        private IGenreInteractor _genreInteractor;


        public Create(ISearchInteractor searchInteractor, IGenreInteractor genreInteractor)
        {
            InitializeComponent();

            _searchInteractor = searchInteractor;
            _genreInteractor = genreInteractor;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MovieRequestModel request = new MovieRequestModel()
            {
                Actors = new List<string>() { txtActor.Text },
                Director = new List<string>() { txtDirector.Text },
                Genre = txtGenre.Text,
                Location = txtLocation.Text,
                Title = txtTitle.Text,
                Year = Convert.ToInt32(txtYear.Text)
            };

            MovieInteractor mi = new MovieInteractor(_searchInteractor, _genreInteractor);
            ResponseModel response = mi.AddMovie(request);
        }
    }
}
