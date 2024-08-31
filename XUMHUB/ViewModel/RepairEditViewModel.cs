using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Stores;

namespace XUMHUB.ViewModel
{
    public class RepairEditViewModel:BaseViewModel
    {

        public string ServiceCode => repairEntryViemodel.ServiceTag;
        public string Agent => repairEntryViemodel.Agent;
        public DateTime? LoggedDate => repairEntryViemodel.LoggedDate;
        public string RepairStatus => repairEntryViemodel.RepairStatus;
        public DateTime? RepairDate => repairEntryViemodel.RepairDate;
        public string? RepairAgent => repairEntryViemodel.RepairAgent;
        public List<FaultViewModel> Faults => repairEntryViemodel.Faults;
        public int repairId => repairEntryViemodel.RepairId ?? 0;
        public ObservableCollection<string> Options { get; }
        public FaultsViewmodel FaultsViewmodel => new FaultsViewmodel(agentStore,Faults,repairId);
        public string Status => repairEntryViemodel.RepairStatus;
        public RepairEditViewModel(RepairEntryViewModel repairEntryViemodel,AgentStore agentStore)
        {
            this.repairEntryViemodel = repairEntryViemodel;
            this.agentStore = agentStore;
        }

        public RepairEntryViewModel repairEntryViemodel { get; }
        public AgentStore agentStore { get; private set; }
    }
}
