using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Model;

namespace XUMHUB.ViewModel
{
    public class RepairEntryViewModel
    {
        public readonly RepairDataModel _repairData;
        public string ServiceTag => _repairData.ServiceTag;
        public string Agent => _repairData.AgentLogged.AgentName;
        public DateTime? LoggedDate => _repairData.DateLogged;
        public string RepairStatus => _repairData.RepairStatus;
        public DateTime? RepairDate => _repairData.RepairedDate;
        public string? RepairAgent => _repairData.AgentRepaired.AgentName ?? "Not Repaired";
        public List<FaultViewModel> Faults;


        public RepairEntryViewModel(RepairDataModel repairData)
        {
            Faults = new List<FaultViewModel>();
            _repairData = repairData;
            LoadData();
        }
        public async void LoadData()
        {
            foreach (var fault in _repairData.Faults)
            {
                FaultViewModel viewmodel = new FaultViewModel(fault.FaultName,fault.IsRepaired??false);
                Faults.Add(viewmodel);
            }
        }

    }
}
