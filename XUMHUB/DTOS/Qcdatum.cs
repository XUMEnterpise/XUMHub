using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XUMHUB.DTOS;

[Table("QCData")]
public partial class Qcdatum
{
    public int DbId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? ServiceCode { get; set; }

    [Key]
    [Column("QCId")]
    public int Qcid { get; set; }

    [ForeignKey("DbId")]
    [InverseProperty("Qcdata")]
    public virtual History Db { get; set; } = null!;
}
