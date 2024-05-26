using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUMHUB.Classes
{
    public class ReturnsInfoModel
    {
        public ReturnsInfoModel(int returnId, DateOnly? returnDate, string status, string reasonForReturn, string additionalReturnInfo, string diagnosis, string aditionalRepairInfo, string orderID)
        {
            ReturnId = returnId;
            ReturnDate = returnDate;
            Status = status;
            ReasonForReturn = reasonForReturn;
            AdditionalReturnInfo = additionalReturnInfo;
            Diagnosis = diagnosis;
            AditionalRepairInfo = aditionalRepairInfo;
            OrderID = orderID;
        }

        public int ReturnId { get; }
        public string OrderID { get; }
        public DateOnly? ReturnDate { get; }
        public string Status { get;  }
        public string ReasonForReturn { get; }
        public string AdditionalReturnInfo { get; }
        public string Diagnosis { get; }
        public string AditionalRepairInfo { get; }



    }
}
