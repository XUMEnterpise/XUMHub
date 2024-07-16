using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XUMHUB.DTOS;

[Keyless]
[Table("WINDOWS")]
public partial class Window
{
    [Column("WINDOWS")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Windows { get; set; }
}
