using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XUMHUB.DTOS;

public partial class PurchaseOrder
{
    [Key]
    public int Id { get; set; }

    [Column("PONumber")]
    [StringLength(100)]
    public string Ponumber { get; set; } = null!;

    [Column("POTitle")]
    [StringLength(255)]
    public string Potitle { get; set; } = null!;

    [Column("SKU")]
    [StringLength(100)]
    public string Sku { get; set; } = null!;

    public int Quantity { get; set; }
}
