using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Model;

namespace XUMHUB.ViewModel
{
    public class CustomerReturnViewModel : BaseViewModel
    {
        ReturnsInfoViewModel ReturnsInfo { get;  }
        public string OrderNumber => ReturnsInfo.OrderID;
        public string SKU => ReturnsInfo.SKU;
        public string CustomerName => ReturnsInfo.Name;
        public string ChannelRefference => ReturnsInfo.ChannelRefference;
        public string Channel => ReturnsInfo.Channel;
        public DateOnly? OrderDate => ReturnsInfo.OrderedDate;

        public ObservableCollection<string> Options { get; } 

        private string status;
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                OnPropertyChanged(nameof(status));
            }
        }

        public CustomerReturnViewModel(ReturnsInfoViewModel returnsInfo)
        {
            ReturnsInfo = returnsInfo;
            

            Options = new ObservableCollection<string>() {
                "TO BE REPAIRED",
                "BEING REPAIRED",
                "REPAIRED",
                "TO BE REFUNDED",
                "BEING REFUNDED",
                "REFUNDED",
                "TO BE REPLACED",
                "BING REPLACED",
                "REPLACED"

            };
            
            Status = Options[Options.IndexOf(returnsInfo.Status.ToUpper())];
        }
    }
}
