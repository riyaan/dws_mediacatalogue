using MediaCatalogue_WPF.Interactors;
using Ninject;
using System.Windows;

namespace MediaCatalogue_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            this.container = new StandardKernel();
            container.Bind<ISearchInteractor>().To<SearchInteractor>().InTransientScope();
            container.Bind<IGenreInteractor>().To<GenreInteractor>().InTransientScope();
        }

        private void ComposeObjects()
        {
            Current.MainWindow = this.container.Get<MainWindow>();
            Current.MainWindow.Title = "DWS Media Catalogue";
        }
    }
}
