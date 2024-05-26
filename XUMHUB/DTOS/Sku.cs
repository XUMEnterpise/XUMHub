using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XUMHUB.DTOS;

[Table("SKUS")]
public partial class Sku
{
    [Column("SKU")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Sku1 { get; set; }

    [Column("CASE")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Case { get; set; }

    [Column("MOBO")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Mobo { get; set; }

    [Column("CPU")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Cpu { get; set; }

    [Column("RAM")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Ram { get; set; }

    [Column("GPU")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Gpu { get; set; }

    [Column("HDD")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Hdd { get; set; }

    [Column("SSD")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Ssd { get; set; }

    [Key]
    public int Id { get; set; }

    [Column("WINDOWS")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Windows { get; set; }
}
