using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XUMHUB.DTOS;

[Table("IssueLog")]
public partial class IssueLog
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column(TypeName = "text")]
    public string Issue { get; set; } = null!;
}
