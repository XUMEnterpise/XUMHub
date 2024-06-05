using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Stores;
using XUMHUB.ViewModel;

namespace XUMHUB.Services
{
    public class NavigationService<TViewModel> where TViewModel : BaseViewModel 
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            this.createViewModel = createViewModel;
        }
        public void Navigate()
        {
            _navigationStore.CurrentViewModel = createViewModel();
        }
    }
}
