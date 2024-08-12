using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XUMHUB.DTOS;

public partial class LaptopModels
{
    [StringLength(255)]
    public string? Sku { get; set; }

    [Column("LaptopModel")]
    [StringLength(255)]
    public string? LaptopModel { get; set; }

    [StringLength(255)]
    public string? Cpu { get; set; }

    [StringLength(255)]
    public string? Ram { get; set; }

    [StringLength(255)]
    public string? Storage { get; set; }

    [StringLength(255)]
    public string? Display { get; set; }

    [StringLength(255)]
    public string? WindowsVersion { get; set; }

    [Key]
    public int Id { get; set; }
}
