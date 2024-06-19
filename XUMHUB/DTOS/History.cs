using System;
using System.Collections.Generic;

namespace XUMHUB.DTOS;

public partial class History
{
    public int Id { get; set; }

    public string Orderid { get; set; } = null!;

    public string Sku { get; set; } = null!;

    public string Qty { get; set; } = null!;

    public string? Channel { get; set; }

    public DateOnly Date { get; set; }

    public bool IsTested { get; set; }

    public string TestedBy { get; set; } = null!;

    public string TestStatus { get; set; } = null!;

    public string? PackedBy { get; set; }

    public DateTime? PackedDate { get; set; }

    public string? AssignedNumber { get; set; }
}
