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
        public ObservableCollection<FaultViewModel> FaultList { get; private set; }
        public FaultSelectionViewModel(ObservableCollection<FaultViewModel> faults)
        {
            IsComboBoxVisible = true;
            FaultList = faults;
            ConvertToLabelCommand = new RelayCommand(_ => OnConverToLabel());
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

        private void OnConverToLabel()
        {
            IsComboBoxVisible = false;
        }


    }
}
