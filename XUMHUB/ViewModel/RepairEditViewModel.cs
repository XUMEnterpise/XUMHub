using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public ObservableCollection<string> Options { get; }
        public RepairEditViewModel(RepairEntryViewModel repairEntryViemodel)
        {
            this.repairEntryViemodel = repairEntryViemodel;
            Options = new ObservableCollection<string>()
            {
                "REPAIRED",
                "PENDING",
                "UNREPAIRABLE"
            };
            Status = Options[Options.IndexOf(repairEntryViemodel.RepairStatus.ToUpper())];
        }

        public RepairEntryViewModel repairEntryViemodel { get; }
        private string _status;
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
    }
}
