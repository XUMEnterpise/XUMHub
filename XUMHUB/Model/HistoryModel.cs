
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUMHUB.Model
{
    public class HistoryModel
    {
        public HistoryModel(int id, string? orderId, string? sku, int? qty, string? channel, DateOnly? date, bool? isTested, string? testedBy, string? testStatus)
        {
            Id = id;
            OrderId = orderId;
            Sku = sku;
            Qty = qty;
            Channel = channel;
            Date = date;
            IsTested = isTested;
            TestedBy = testedBy;
            TestStatus = testStatus;
        }
        public int Id { get; }
        public string? OrderId { get; }
        public string? Sku { get; }
        public int? Qty { get; }
        public string? Channel { get; }
        public DateOnly? Date { get; }
        public bool? IsTested { get; }
        public string? TestedBy { get; }
        public string? TestStatus { get; }
    }
}
