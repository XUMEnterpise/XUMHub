using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XUMHUB.DTOS;

[Keyless]
[Table("SSDS")]
public partial class Ssd
{
    [Column("SSD")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Ssd1 { get; set; }
}
