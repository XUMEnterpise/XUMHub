using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XUMHUB.Core;
using XUMHUB.Services.IssueLogService;

namespace XUMHUB.ViewModel
{
    public class FaultsViewmodel: BaseViewModel
    {
        IIssueLogToDB _issueLogToDB=new IssuesToDb();
        public FaultsViewmodel()
        {
            Faults =new ObservableCollection<string>();
            LoadData();
            FaultSelections = new ObservableCollection<FaultSelectionViewModel>();

            AddFaultCommand = new RelayCommand(_ => AddFault());
        }

        public ObservableCollection<string> Faults { get; }

        public ObservableCollection<FaultSelectionViewModel> FaultSelections { get; }

        public ICommand AddFaultCommand { get; }

        private void AddFault()
        {
            FaultSelections.Add(new FaultSelectionViewModel(Faults));
        }
        private async void LoadData()
        {
            IList<string> faults =await _issueLogToDB.GetAllIssues();
            foreach (var fault in faults)
            {
                Faults.Add(fault);
            }
        }
    }
}
