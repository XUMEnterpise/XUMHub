using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using XUMHUB.View;

namespace XUMHUB.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        public ICommand MinimizeCommand { get; }
        public ICommand MaximizeCommand { get; }
        public ICommand CloseCommand { get; }
        private object _currentView;
        DashboardView dashboardView = new DashboardView();
        ReturnsView returnsView = new ReturnsView();
        public RelayCommand ReturnsViewCommand { get; set; }
        public RelayCommand DashboardViewCommand { get; set; }

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            MinimizeCommand = new RelayCommand(OnMinimize);
            MaximizeCommand = new RelayCommand(OnMaximize);
            CloseCommand = new RelayCommand(OnClose);


            CurrentView=dashboardView;
            DashboardViewCommand = new RelayCommand(ChangeToDashboard);
            ReturnsViewCommand = new RelayCommand(ChangeToReturns);

        }

        private void OnClose()
        {
            Application.Current.MainWindow.Close();
        }

        private void OnMaximize()
        {
            if(Application.Current.MainWindow.WindowState== WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
        }

        private void OnMinimize()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
        private void ChangeToDashboard()
        {
            CurrentView = dashboardView;
        }
        private void ChangeToReturns()
        {
            CurrentView = returnsView;
        }
    }
}
