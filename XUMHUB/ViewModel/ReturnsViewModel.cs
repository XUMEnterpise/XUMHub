using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XUMHUB.Classes;
using XUMHUB.Core;
using XUMHUB.DTOS;
using XUMHUB.Model;
using XUMHUB.Services;
using XUMHUB.Services.ReturnsProvider;

namespace XUMHUB.ViewModel
{
    class ReturnsViewModel : BaseViewModel
    {
        

        private ObservableCollection<ReturnsInfoModel> _dataRows;
        private IReturnsProvider returnsProvider= new DatabaseReturnsInfoProvider();

        public ObservableCollection<ReturnsInfoModel> DataRows 
        {
            get => _dataRows;
            set
            {
                _dataRows=value;
                OnPropertyChanged();
            }

        }
        public ICommand LoadDataCommand { get; }
        public ReturnsViewModel() 
        {
            
            LoadDataCommand = new TaskCommand(async () => await LoadData());

            LoadDataCommand.Execute(null);
            
        }
        private async Task LoadData()
        {
            Return @return = new Return(returnsProvider);
            IEnumerable<ReturnsInfoModel> returnsInfos=await @return.GetAllReturnsInfo();
            DataRows = new ObservableCollection<ReturnsInfoModel>();
            foreach(var returnsInfo in returnsInfos)
            {
                DataRows.Add(returnsInfo);
            }
        }
    }
}
