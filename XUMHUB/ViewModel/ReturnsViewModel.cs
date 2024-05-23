using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XUMHUB.Core;
using XUMHUB.Model;

namespace XUMHUB.ViewModel
{
    class ReturnsViewModel : BaseViewModel
    {
        private readonly DbManager dbManager;

        private ObservableCollection<ReturnsInfo> _dataRows;

        public ObservableCollection<ReturnsInfo> DataRows 
        {
            get => _dataRows;
            set
            {
                _dataRows=value;
                OnPropertyChanged();
            }

        }
        public ICommand LoadDataCommand { get; }
        public ReturnsViewModel() 
        {
            dbManager = new DbManager();
            LoadDataCommand = new TaskCommand(async () => await LoadData());

            LoadDataCommand.Execute(null);
        }
        private async Task LoadData()
        {
            var dataTable = await dbManager.SelectAsync("ReturnsInfo");
            if (dataTable != null)
            {
                DataRows = new ObservableCollection<ReturnsInfo>();

                foreach(DataRow row in dataTable.Rows) 
                {
                    DataRows.Add(new ReturnsInfo
                    {
                        ReturnId = row["ReturnId"].ToString(),
                        ReturnDate = row["ReturnDate"].ToString(),
                        Status = row["Status"].ToString(),
                        ReasonForReturn = row["ReasonForReturn"].ToString(),
                        AdditionalReturnInfo = row["AdditionalReturnInfo"].ToString(),
                        Diagnosis = row["Diagnosis"].ToString(),
                        AditionalRepairInfo = row["AdditionalRepairInfo"].ToString()

                    });
                }
            }
        }
    }
}
