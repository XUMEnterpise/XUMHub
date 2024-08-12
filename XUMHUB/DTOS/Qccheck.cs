using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XUMHUB.DTOS;

[Table("QCChecks")]
public partial class Qccheck
{
    [Key]
    public int CheckId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? CheckName { get; set; }

    public bool? IsPassed { get; set; }

    [Column("QCEntryId")]
    public int QcentryId { get; set; }
}
