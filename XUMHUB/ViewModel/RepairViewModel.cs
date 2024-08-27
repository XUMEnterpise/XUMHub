using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XUMHUB.Commands;
using XUMHUB.Core;
using XUMHUB.Model;
using XUMHUB.Services;
using XUMHUB.Services.RepairDataService;
using XUMHUB.Stores;

namespace XUMHUB.ViewModel
{
    class RepairViewModel : BaseViewModel
    {
        IDatabaseToRepairDataModel _databaseToRepairDataModel=new DatabaseToRepairDataModel();
        public NavigationStore _store { get; }
		public ICommand LoadDataCommand { get; }
        public ICommand LaptopLogCommand { get; }
        IEnumerable<RepairDataModel> repairDataModels;
        public RepairViewModel(NavigationStore store)
        {
            _store = store;
			LoadDataCommand = new TaskCommand(async () => await LoadData());
            LoadDataCommand.Execute(null);
            LaptopLogCommand = new RelayCommand(_ => OnLaptopLog());
        }

        private void OnLaptopLog()
        {
            LaptopLoggingViewModel laptopLoggingViewModel = new LaptopLoggingViewModel(_store);
            NavigationService<LaptopLoggingViewModel> laptopLogNavStore = new NavigationService<LaptopLoggingViewModel>(_store, () => laptopLoggingViewModel);
            ICommand ChangeToLaptopViewCommand = new NavigateCommand<LaptopLoggingViewModel>(laptopLogNavStore);
            ChangeToLaptopViewCommand.Execute(null);
        }

        private async Task LoadData()
        {
            repairDataModels = await _databaseToRepairDataModel.GetAllRepairs();
			DataRows = new ObservableCollection<RepairEntryViewModel>();
            repairEditViewModels = new ObservableCollection<RepairEntryViewModel>();
            foreach (var repairDataModel in repairDataModels)
			{
                RepairEntryViewModel repairEntry = new RepairEntryViewModel(repairDataModel.RepairId, repairDataModel.ServiceTag, repairDataModel.AgentLogged==null?null:repairDataModel.AgentLogged.AgentName, repairDataModel.DateLogged, repairDataModel.RepairStatus
                    , repairDataModel.RepairedDate, repairDataModel.AgentRepaired==null?null:repairDataModel.AgentRepaired.AgentName, repairDataModel.Faults);

                DataRows.Add(repairEntry);
                repairEditViewModels.Add(repairEntry);
            }
        }
        private ObservableCollection<RepairEntryViewModel> repairEditViewModels;
		private ObservableCollection<RepairEntryViewModel> _datarows;
		public ObservableCollection<RepairEntryViewModel> DataRows
		{
			get
			{
				return _datarows;
			}
			set
			{
				_datarows = value;
				OnPropertyChanged(nameof(DataRows));
			}
		}
        public void HandleDoubleClick(RepairEntryViewModel item)
        {
            if (item != null)
            {

                ChangeToRepairEdit(item);

            }
        }
        private string searchQuery;
        public string SearchQuery
        {
            get
            {
                return searchQuery;
            }
            set
            {
                searchQuery = value;
                OnPropertyChanged(nameof(SearchQuery));
                FilterRepairs();
            }
        }

        private void FilterRepairs()
        {
            _datarows.Clear();
            foreach (var repair in repairEditViewModels.Where(l => l.ServiceTag.ToString().Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)))
            {
                _datarows.Add(repair);
            }
        }

        private void ChangeToRepairEdit(RepairEntryViewModel item)
        {
            RepairEditViewModel repairEditViewModel = new RepairEditViewModel(item);
            NavigationService<RepairEditViewModel> navService = new NavigationService<RepairEditViewModel>(_store, () => repairEditViewModel);
            ICommand LoadRepairEdit = new NavigateCommand<RepairEditViewModel>(navService);
            LoadRepairEdit.Execute(null);
        }
    }
}
