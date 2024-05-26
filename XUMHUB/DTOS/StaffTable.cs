using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XUMHUB.DTOS;

[Keyless]
[Table("StaffTable")]
public partial class StaffTable
{
    public int? StaffNumber { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    public int? TestingPower { get; set; }
}
