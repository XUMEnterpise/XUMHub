using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XUMHUB.DTOS;

[Table("QCEntry")]
public partial class Qcentry
{
    [Key]
    [Column("QCId")]
    public int Qcid { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Agent { get; set; }

    [Column("QCStatus")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Qcstatus { get; set; }

    [Column(TypeName = "text")]
    public string? Notes { get; set; }

    [Column("QCDate", TypeName = "datetime")]
    public DateTime? Qcdate { get; set; }

    [Column("QCDataId")]
    public int QcdataId { get; set; }
}
