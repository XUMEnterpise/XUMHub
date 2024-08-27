using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XUMHUB.DTOS;

[Keyless]
public partial class AutoPilotTest
{
    [StringLength(40)]
    public string? ServiceCode { get; set; }

    [StringLength(40)]
    public string? SerialNumber { get; set; }

    public bool? IsPassed { get; set; }
}
