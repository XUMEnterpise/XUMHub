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
        public ObservableCollection<string> FaultList { get; private set; }
        public FaultSelectionViewModel(ObservableCollection<string> faults)
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
		private string _selectedFault;
		public string SelectedFault
		{
			get
			{
				return _selectedFault;
			}
			set
			{
				_selectedFault = value;
				OnPropertyChanged(nameof(SelectedFault));
			}
		}
		public ICommand ConvertToLabelCommand { get; }

        private void OnConverToLabel()
        {
            IsComboBoxVisible = false;
        }


    }
}
