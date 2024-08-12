using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XUMHUB.DTOS;

public partial class Fault
{
    [Key]
    public int Id { get; set; }

    public int? RepairId { get; set; }

    [Column("Fault")]
    [StringLength(255)]
    public string? Fault1 { get; set; }

    public bool? IsRepaired { get; set; }

    [ForeignKey("RepairId")]
    [InverseProperty("Faults")]
    public virtual RepairDatum? Repair { get; set; }
}
