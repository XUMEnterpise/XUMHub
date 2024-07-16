using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using XUMHUB.Core;
using XUMHUB.Model;
using XUMHUB.Services;

namespace XUMHUB.ViewModel
{
    class CSVUploadViewModel : BaseViewModel
    {
        private CSVService _CSVService;
        private POModel _poModel;
        private string filePath;
        public List<POEntryModel> POEntries { get; private set; }
        public ICommand OpenFileCommand { get; }
        public ICommand Save { get; }

        public CSVUploadViewModel()
        {
            _CSVService = new CSVService();
            OpenFileCommand = new RelayCommand(OpenFile);
            Save = new RelayCommand(SavePO);
            POEntries = new List<POEntryModel>();
        }

        private void SavePO(object obj)
        {
            LoadPOModel(filePath, _poNumber, _poTitle);
        }

        private string _poNumber;
        public string PoNumber
        {
            get
            {
                return _poNumber;
            }
            set
            {
                _poNumber = value;
                OnPropertyChanged(nameof(PoNumber));
            }
        }
        private string _poTitle;
        public string POTitle
        {
            get
            {
                return _poTitle;
            }
            set
            {
                _poTitle = value;
                OnPropertyChanged(nameof(POTitle));
            }
        }
        private void OpenFile(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*",
                FilterIndex = 1
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
            }
        }
        public void LoadPOModel(string filePath, string pONumber, string pOTitle)
        {
            _poModel = _CSVService.CreatePOModel(filePath, pONumber, pOTitle);
        }
    }
}
