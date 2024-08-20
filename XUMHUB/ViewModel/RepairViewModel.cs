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
        public RepairViewModel(NavigationStore store)
        {
            _store = store;
			LoadDataCommand = new TaskCommand(async () => await LoadData());
            LoadDataCommand.Execute(null);
        }

        private async Task LoadData()
        {
            IEnumerable<RepairDataModel> repairDataModels = await _databaseToRepairDataModel.GetAllRepairs();
			DataRows = new ObservableCollection<RepairEntryViewModel>();
            foreach (var repairDataModel in repairDataModels)
			{
				DataRows.Add(new RepairEntryViewModel(repairDataModel));
            }
        }

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

        private void ChangeToRepairEdit(RepairEntryViewModel item)
        {
            RepairEditViewModel repairEditViewModel = new RepairEditViewModel(item);
            NavigationService<RepairEditViewModel> navService = new NavigationService<RepairEditViewModel>(_store, () => repairEditViewModel);
            ICommand LoadRepairEdit = new NavigateCommand<RepairEditViewModel>(navService);
            LoadRepairEdit.Execute(null);
        }
    }
}
