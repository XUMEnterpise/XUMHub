using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XUMHUB.Commands;
using XUMHUB.Core;
using XUMHUB.Model;

namespace XUMHUB.ViewModel
{
    public class FaultViewModel: BaseViewModel
    {
        public int repairId { get; private set; }
        public string FaultName { get; private set; }
        private bool _isRepaired;
        public int? faultId;

        public bool? IsRepaired
        {
            get => _isRepaired;
            set
            {
                _isRepaired = value ?? false;
                OnPropertyChanged(nameof(IsRepaired));

            }
        }
        public FaultViewModel(int? faultId,int repairId,string FaultName, bool isRepaired )
        {
            this.faultId = faultId;
            this.repairId = repairId;
            this.FaultName = FaultName;
            this.IsRepaired = isRepaired;

        }
    }
}
