using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUMHUB.Model;

namespace XUMHUB.ViewModel
{
    public class FaultViewModel: BaseViewModel
    {
        public readonly FaultModel _faultModel;
        public string FaultName => _faultModel.FaultName;
        public bool? IsRepaired
        {
            get => _faultModel.IsRepaired;
            set
            {
                if (_faultModel.IsRepaired != value)
                {
                    _faultModel.IsRepaired = value;
                    OnPropertyChanged(nameof(IsRepaired));
                }
            }
        }
        public FaultViewModel(FaultModel faultModel)
        {
            _faultModel = faultModel;
        }
    }
}
