﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XUMHUB.DTOS;

[Keyless]
public partial class Skuview
{
    [Column("SKU")]
    [StringLength(50)]
    public string? Sku { get; set; }

    [Column("CASE")]
    [StringLength(10)]
    public string? Case { get; set; }

    [Column("MOBO")]
    [StringLength(10)]
    public string? Mobo { get; set; }

    [Column("CPU")]
    [StringLength(10)]
    public string? Cpu { get; set; }

    [Column("RAM")]
    [StringLength(5)]
    public string? Ram { get; set; }

    [Column("GPU")]
    [StringLength(20)]
    public string? Gpu { get; set; }

    [Column("HDD")]
    [StringLength(10)]
    public string? Hdd { get; set; }

    [Column("SSD")]
    [StringLength(10)]
    public string? Ssd { get; set; }
}
