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
        public bool? IsRepaired => _faultModel.IsRepaired;
        public FaultViewModel(FaultModel faultModel)
        {
            _faultModel = faultModel;
        }
    }
}
