using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XUMHUB.Commands;
using XUMHUB.Services;
using XUMHUB.Stores;

namespace XUMHUB.ViewModel
{
    public class ToolsViewModel : BaseViewModel
    {
        public ICommand LoadCSV { get; }
        public ToolsViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
            CSVUploadViewModel customerReturnViewModel = new CSVUploadViewModel();
            NavigationService<CSVUploadViewModel> navService = new NavigationService<CSVUploadViewModel>(navigationStore, () => customerReturnViewModel);
            LoadCSV = new NavigateCommand<CSVUploadViewModel>(navService);
        }

        public NavigationStore navigationStore { get; }

    }
}
