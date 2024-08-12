using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XUMHUB.DTOS;

[Keyless]
public partial class Lot
{
    [StringLength(40)]
    public string? LotNumber { get; set; }

    public bool IsCurrent { get; set; }
}
