using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XUMHUB.DTOS;

public partial class InventoryBin
{
    [Key]
    public int Id { get; set; }

    [Column("BIN")]
    [StringLength(15)]
    public string Bin { get; set; } = null!;

    [Column("SKU")]
    [StringLength(100)]
    public string Sku { get; set; } = null!;

    public int Quantity { get; set; }
}
