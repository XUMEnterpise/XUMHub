using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XUMHUB.DTOS;

[Table("ModelToBin")]
public partial class ModelToBin
{
    [Key]
    public int Id { get; set; }

    [Column("BIN")]
    [StringLength(15)]
    public string Bin { get; set; } = null!;

    [StringLength(100)]
    public string? Model { get; set; }

    [Column("max_qty")]
    public int? MaxQty { get; set; }

    [Column("racking_type")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RackingType { get; set; }

    [Column("qty")]
    public int? Qty { get; set; }
}
