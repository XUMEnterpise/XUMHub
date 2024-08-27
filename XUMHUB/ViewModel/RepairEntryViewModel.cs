using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.DTOS;
using XUMHUB.Model;

namespace XUMHUB.ViewModel
{
    public class RepairEntryViewModel
    {
        public int? RepairId { get; }
        public string ServiceTag { get; }
        public string Agent { get; }
        public DateTime? LoggedDate { get; }
        public string RepairStatus { get; }
        public DateTime? RepairDate { get; }
        public string? RepairAgent { get; }
        public List<FaultViewModel> Faults;
        List<FaultModel> faultsModel;

        public RepairEntryViewModel(int? repairId,string serviceTag, string agent, DateTime? loggedDate, string repairStatus, DateTime? repairDate, string? repairAgent, List<FaultModel> faultsModel)
        {
            RepairId = repairId;
            ServiceTag = serviceTag;
            Agent = agent;
            LoggedDate = loggedDate;
            RepairStatus = repairStatus;
            RepairDate = repairDate;
            RepairAgent = repairAgent;
            this.faultsModel = faultsModel;
            Faults = new List<FaultViewModel>();
            LoadData();
        }

        public async void LoadData()
        {
            foreach (var fault in faultsModel)
            {
                FaultViewModel viewmodel = new FaultViewModel(fault.FaultId??0,fault.RepairId,fault.FaultName,fault.IsRepaired??false);
                Faults.Add(viewmodel);
            }
        }

    }
}
