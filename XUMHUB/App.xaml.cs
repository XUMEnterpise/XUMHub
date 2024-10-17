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
        private readonly AgentStore _agentStore;
        public App()
        {
            _agentStore = new AgentStore();
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            
            DashboardViewModel dashboardViewModel = new DashboardViewModel(_agentStore);
            NavigationService<DashboardViewModel> dashNavServ = new NavigationService<DashboardViewModel>(_navigationStore, () => dashboardViewModel);
            
            ReturnsListingViewModel returnsListingView = new ReturnsListingViewModel(_navigationStore,_agentStore);
            ToolsViewModel toolsViewModel = new ToolsViewModel( _navigationStore, _agentStore);
            NavigationService<ReturnsListingViewModel> returnNavSer = new NavigationService<ReturnsListingViewModel>(_navigationStore,()=> returnsListingView);
            NavigationService<ToolsViewModel> toolsNavSer = new NavigationService<ToolsViewModel>(_navigationStore,()=> toolsViewModel);
            NavigationService<LaptopLoggingViewModel> laptopLogNavStore = new NavigationService<LaptopLoggingViewModel>(_navigationStore,()=> new LaptopLoggingViewModel(_navigationStore,_agentStore));
            NavigationService<RepairViewModel> repairViewService = new NavigationService<RepairViewModel>(_navigationStore,()=> new RepairViewModel(_navigationStore,_agentStore));
            LoginViewModel loginViewModel = new LoginViewModel(dashNavServ, _agentStore);
            _navigationStore.CurrentViewModel = loginViewModel;

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore, dashNavServ,returnNavSer,toolsNavSer,laptopLogNavStore, repairViewService)
            };
            loginViewModel.MainViewModel = (MainViewModel)MainWindow.DataContext;
            MainWindow.Show();
            base.OnStartup(e);
        }
    }

}
