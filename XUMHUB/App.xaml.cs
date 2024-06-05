using System.Configuration;
using System.Data;
using System.Windows;
using XUMHUB.Services;
using XUMHUB.Stores;
using XUMHUB.ViewModel;

namespace XUMHUB
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        public App()
        {
            
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            
            DashboardViewModel dashboardViewModel = new DashboardViewModel();
            _navigationStore.CurrentViewModel = dashboardViewModel;
            ReturnsListingViewModel returnsListingView = new ReturnsListingViewModel(_navigationStore);
            NavigationService<DashboardViewModel> dashNavServ = new NavigationService<DashboardViewModel>(_navigationStore,()=>dashboardViewModel);
            NavigationService<ReturnsListingViewModel> returnNavSer = new NavigationService<ReturnsListingViewModel>(_navigationStore,()=> returnsListingView);
            
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore, dashNavServ,returnNavSer)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }

}
