using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XUMHUB.DTOS;

[Keyless]
[Table("CPUS")]
public partial class Cpu
{
    [Column("CPU")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Cpu1 { get; set; }
}
