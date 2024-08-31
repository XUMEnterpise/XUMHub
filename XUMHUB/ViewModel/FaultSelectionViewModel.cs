using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XUMHUB.Commands;
using XUMHUB.Core;
using XUMHUB.DTOS;
using XUMHUB.Services.FaultsService;
using XUMHUB.Stores;

namespace XUMHUB.ViewModel
{
    public class FaultSelectionViewModel : BaseViewModel
    {
        public ObservableCollection<FaultViewModel> FaultList { get; private set; }
        public AgentStore AgentStore { get; }

        public UpdateFaultCheckBoxCommand _UpdateFaultCheckBoxCommand;
        ICommand _addFaultCommand;
        public ICommand CheckCommand { get; }
        public FaultSelectionViewModel(ObservableCollection<FaultViewModel> faults,AgentStore agentStore)
        {
            IsComboBoxVisible = true;
            FaultList = faults;
            AgentStore = agentStore;
            ConvertToLabelCommand = new RelayCommand(_ => OnConverToLabel());
            CheckCommand = new RelayCommand(_ => OnCheckBoxChanged());
        }

        private void OnCheckBoxChanged()
        {
            if (SelectedFault.faultId != 0)
            {
                _UpdateFaultCheckBoxCommand = new UpdateFaultCheckBoxCommand(SelectedFault.faultId??0, IsRepaired ?? false,AgentStore==null?"":AgentStore.AgentModel.AgentId.ToString());
                _UpdateFaultCheckBoxCommand.Execute(null);
            }
        }

        private bool _isComboBoxVisible;
		public bool IsComboBoxVisible
        {
			get
			{
				return _isComboBoxVisible;
			}
			set
			{
				_isComboBoxVisible = value;
				OnPropertyChanged(nameof(IsComboBoxVisible));
			}
		}
        private FaultViewModel _selectedFault;
        public FaultViewModel SelectedFault
        {
            get => _selectedFault;
            set
            {
                _selectedFault = value;
                OnPropertyChanged(nameof(SelectedFault));
                OnPropertyChanged(nameof(FaultName));
                OnPropertyChanged(nameof(IsRepaired));
            }
        }

        public string FaultName => SelectedFault?.FaultName;
        public bool? IsRepaired
        {
            get => SelectedFault?.IsRepaired;
            set
            {
                if (SelectedFault != null && SelectedFault.IsRepaired != value)
                {
                    SelectedFault.IsRepaired = value;
                    OnPropertyChanged(nameof(IsRepaired));
                }
            }
        }
        public ICommand ConvertToLabelCommand { get; }

        private async void OnConverToLabel()
        {
            IDatabaseToFaults faultsService = new DatabaseToFaults();
            IsComboBoxVisible = false;
             _addFaultCommand = new CreateFaultCommand(_selectedFault);
             _addFaultCommand.Execute(null);
            string repairIDFromDB = await faultsService.GetFaultId(_selectedFault.repairId, _selectedFault.FaultName);
            int repairId=0;
            if(Int32.TryParse(repairIDFromDB,out repairId))
            {
                _selectedFault.faultId = repairId;
            }
            

        }


    }
}
