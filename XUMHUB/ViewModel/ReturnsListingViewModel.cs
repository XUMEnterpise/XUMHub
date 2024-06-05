using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using XUMHUB.Commands;
using XUMHUB.Core;
using XUMHUB.DTOS;
using XUMHUB.Model;
using XUMHUB.Services;
using XUMHUB.Services.CustomerInfoProvider;
using XUMHUB.Services.HistoryProvider;
using XUMHUB.Services.ReturnsProvider;
using XUMHUB.Stores;
using XUMHUB.View;

namespace XUMHUB.ViewModel
{
    class ReturnsListingViewModel : BaseViewModel
    {
        

        private ObservableCollection<ReturnsInfoViewModel> _dataRows;
        private IReturnsProvider returnsProvider= new DatabaseReturnsInfoProvider();
        private IHistoryProvider historyProvider=new DatabaseHistoryProvider();
        private ICustomerInforProvider customerInforProvider= new DabatabaseCustomerInfoProvider();
        
        public NavigationStore navigationStore { get; }

        public ObservableCollection<ReturnsInfoViewModel> DataRows
        {
            get => _dataRows;
            set
            {
                _dataRows=value;
                OnPropertyChanged();
            }

        }
        public ICommand LoadDataCommand { get; }
        public ReturnsListingViewModel(NavigationStore navigationStore) 
        {
            this.navigationStore = navigationStore;
            LoadDataCommand = new TaskCommand(async () => await LoadData());
            LoadDataCommand.Execute(null);
            
            
        }

        private void ChangeToCustomer(ReturnsInfoViewModel returnsInfoViewModel)
        {
            CustomerReturnViewModel customerReturnViewModel=new CustomerReturnViewModel(returnsInfoViewModel);
            NavigationService<CustomerReturnViewModel> navService= new NavigationService<CustomerReturnViewModel>(navigationStore,() => customerReturnViewModel);
            ICommand LoadCustomerReturn= new NavigateCommand<CustomerReturnViewModel>(navService);
            LoadCustomerReturn.Execute(null);
        }

        private async Task LoadData()
        {
            Return @return = new Return(returnsProvider,historyProvider,customerInforProvider);
            IEnumerable<ReturnsInfoModel> returnsInfo=await @return.GetAllReturnsInfo();
            DataRows = new ObservableCollection<ReturnsInfoViewModel>();
            foreach(var item in returnsInfo)
            {
                CustomerInfoModel cm = await @return.GetCustomerByOrderNumber(item.OrderID);
                HistoryModel hm=await @return.GetOrderByOrderID(item.OrderID);
                ReturnsInfoViewModel infoVM = new ReturnsInfoViewModel(item, hm, cm);
                DataRows.Add(infoVM);
                   
            }
        }
        public void HandleDoubleClick(ReturnsInfoViewModel item)
        {
            if (item != null)
            {
                
                ChangeToCustomer(item);
              
            }
        }
    }
}
