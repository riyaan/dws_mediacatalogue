using MediaCatalogue_WPF.Interactors.Interfaces;
using System.Collections.Generic;
using System.Windows;

namespace MediaCatalogue_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ISearchInteractor _searchInteractor;
        private IGenreInteractor _genreInteractor;
        private IActorInteractor _actorInteractor;
        private ICrewInteractor _crewInteractor;

        private List<string> _categories = new List<string>();
        

        public MainWindow(ISearchInteractor searchInteractor, IGenreInteractor genreInteractor, IActorInteractor actorInteractor,
            ICrewInteractor crewInteractor)
        {
            InitializeComponent();

            _searchInteractor = searchInteractor;
            _genreInteractor = genreInteractor;
            _actorInteractor = actorInteractor;
            _crewInteractor = crewInteractor;

            _categories.Add("All");
            _categories.Add("Movie");
            _categories.Add("Actor");
            _categories.Add("Director");

            cmbSearchCategory.ItemsSource = _categories;
            cmbSearchCategory.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Search create = new Search(_searchInteractor, _genreInteractor, _actorInteractor, _crewInteractor,
                txtSearchQuery.Text);
            create.ShowDialog();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Create create = new Create(_searchInteractor, _genreInteractor, _actorInteractor, _crewInteractor);
            create.ShowDialog();
        }
    }
}
