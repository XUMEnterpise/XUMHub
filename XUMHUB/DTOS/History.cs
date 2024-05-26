using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XUMHUB.DTOS;

[Table("History")]
public partial class History
{
    [Key]
    public int Id { get; set; }

    [StringLength(25)]
    public string? OrderId { get; set; }

    [Column("SKU")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Sku { get; set; }

    [Column("QTY")]
    public int? Qty { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Channel { get; set; }

    public DateOnly? Date { get; set; }

    [Column("isTested")]
    public bool? IsTested { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? TestedBy { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? TestStatus { get; set; }
}
