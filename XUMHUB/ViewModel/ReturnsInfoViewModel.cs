using XUMHUB.DTOS;
using XUMHUB.Model;

namespace XUMHUB.ViewModel
{
    public class ReturnsInfoViewModel
    {
        public readonly ReturnsInfoModel _returnsInfo;
        public readonly HistoryModel orderHistory;
        public readonly CustomerInfoModel customerInfoModel;

        public int ReturnId => _returnsInfo?.ReturnId ?? 0; // Assuming 0 as a default for int
        public string OrderID => _returnsInfo?.OrderID ?? "Not found";
        public string SKU => orderHistory?.Sku ?? "Not found";
        public DateOnly? ReturnDate => _returnsInfo?.ReturnDate ?? null;
        public DateOnly? OrderedDate => orderHistory?.Date ?? null;
        public string Name => customerInfoModel?.Name ?? "Not found";
        public string Status => _returnsInfo?.Status ?? "Not found";
        public string ReasonForReturn => _returnsInfo?.ReasonForReturn ?? "Not provided";
        public string AdditionalReturnInfo => _returnsInfo?.AdditionalReturnInfo ?? "Not provided";
        public string Diagnosis => _returnsInfo?.Diagnosis ?? "Not provided";
        public string AditionalRepairInfo => _returnsInfo?.AdditionalReturnInfo ?? "Not provided";

        public string Channel => orderHistory?.Channel ?? "Not provided";
        public string ChannelRefference => customerInfoModel?.ChannelRefference ?? "Not provided";
        


        public ReturnsInfoViewModel(ReturnsInfoModel returnsInfo, HistoryModel orderHistory, CustomerInfoModel customerInfoModel)
        {
            _returnsInfo = returnsInfo;
            this.orderHistory = orderHistory;
            this.customerInfoModel = customerInfoModel;
        }
    }
}
