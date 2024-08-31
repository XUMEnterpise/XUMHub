using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XUMHUB.Core;
using XUMHUB.Model;
using XUMHUB.Services.IssueLogService;
using XUMHUB.Stores;

namespace XUMHUB.ViewModel
{
    public class FaultsViewmodel: BaseViewModel
    {
        IIssueLogToDB _issueLogToDB=new IssuesToDb();
        private int? repairId;
        public FaultsViewmodel(AgentStore agentStore, List<FaultViewModel> FaultsFromRepairData=null,int? RepairID=null)
        {
            AgentStore = agentStore;
            Faults =new ObservableCollection<FaultViewModel>();
            LoadData();
            FaultSelections = new ObservableCollection<FaultSelectionViewModel>();

            AddFaultCommand = new RelayCommand(_ => OnAddNewFault());
            if(FaultsFromRepairData != null)
            {
                LoadDataForExisting(FaultsFromRepairData);
            }
            repairId = RepairID;

        }

        public ObservableCollection<FaultViewModel> Faults { get; }

        public ObservableCollection<FaultSelectionViewModel> FaultSelections { get; }

        public ICommand AddFaultCommand { get; }
        public AgentStore AgentStore { get; }

        private void OnAddNewFault()
        {
            FaultSelections.Add(new FaultSelectionViewModel(Faults, AgentStore));
        }
        private async void LoadDataForExisting(List<FaultViewModel> FaultsFromRepairData)
        {
            foreach (var fault in FaultsFromRepairData)
            {
                ObservableCollection<FaultViewModel> ReadyFaults = new ObservableCollection<FaultViewModel>();
                ReadyFaults.Add(fault);
                FaultSelectionViewModel faultSelectionViewModel = new FaultSelectionViewModel(ReadyFaults, AgentStore);
                faultSelectionViewModel.SelectedFault = fault;
                faultSelectionViewModel.IsComboBoxVisible = false;
                FaultSelections.Add(faultSelectionViewModel);
            }
        }
        private async void LoadData()
        {
            IList<string> faults =await _issueLogToDB.GetAllIssues();
            foreach (var fault in faults)
            {
                Faults.Add(new FaultViewModel(0,repairId??0,fault,false));
            }
        }

    }
}
