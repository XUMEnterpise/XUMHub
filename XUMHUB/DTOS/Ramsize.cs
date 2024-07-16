using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XUMHUB.DTOS;

[Keyless]
[Table("RAMSizes")]
public partial class Ramsize
{
    [StringLength(255)]
    [Unicode(false)]
    public string? Size { get; set; }
}
