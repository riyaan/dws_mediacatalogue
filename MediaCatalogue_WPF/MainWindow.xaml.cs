using MediaCatalogue_WPF.Interactors.Interfaces;
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

        public MainWindow(ISearchInteractor searchInteractor, IGenreInteractor genreInteractor, IActorInteractor actorInteractor,
            ICrewInteractor crewInteractor)
        {
            InitializeComponent();

            _searchInteractor = searchInteractor;
            _genreInteractor = genreInteractor;
            _actorInteractor = actorInteractor;
            _crewInteractor = crewInteractor;
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
