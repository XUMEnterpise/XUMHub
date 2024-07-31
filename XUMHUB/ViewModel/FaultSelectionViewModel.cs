using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XUMHUB.Core;

namespace XUMHUB.ViewModel
{
    public class FaultSelectionViewModel : BaseViewModel
    {
        private string _selectedFault;
        private string searchQuerry;
        private ObservableCollection<string> _filteredFaults;
        public string SearchQuerry
        {
            get
            {
                return searchQuerry;
            }
            set
            {
                searchQuerry = value;
                OnPropertyChanged(nameof(SearchQuerry));
                SearchFaults();
            }
        }
        public FaultSelectionViewModel(ObservableCollection<string> faults)
        {
            Faults = faults;
            _filteredFaults=faults;
        }

        public ObservableCollection<string> Faults { get; }

        public string SelectedFault
        {
            get => _selectedFault;
            set
            {
                _selectedFault = value;
                OnPropertyChanged(nameof(SelectedFault));
            }
        }
        private void SearchFaults()
        {
            _filteredFaults.Clear();
            foreach (var fault in Faults.Where(l => l.Contains(SearchQuerry,StringComparison.OrdinalIgnoreCase)))
            {
                _filteredFaults.Add(fault);
            }
        }

    }
}
