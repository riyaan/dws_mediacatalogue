using MediaCatalogue_WPF.Interactors;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediaCatalogue_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ISearchInteractor _searchInteractor;
        private IGenreInteractor _genreInteractor;

        public MainWindow(ISearchInteractor searchInteractor, IGenreInteractor genreInteractor)
        {
            InitializeComponent();

            _searchInteractor = searchInteractor;
            _genreInteractor = genreInteractor;

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Create create = new Create(_searchInteractor, _genreInteractor);
            create.ShowDialog();
        }
    }
}
