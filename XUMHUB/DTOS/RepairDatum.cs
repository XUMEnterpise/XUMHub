using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XUMHUB.DTOS;

public partial class RepairDatum
{
    [Key]
    public int RepairId { get; set; }

    [StringLength(255)]
    public string? ServiceTag { get; set; }

    [StringLength(25)]
    public string? AgentLogged { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LoggedDate { get; set; }

    [StringLength(25)]
    public string? RepairStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RepairedDate { get; set; }

    public int? AgentRepaired { get; set; }

    [Column("DbID")]
    public int DbId { get; set; }

    [ForeignKey("DbId")]
    [InverseProperty("RepairData")]
    public virtual History Db { get; set; } = null!;

    [InverseProperty("Repair")]
    public virtual ICollection<Fault> Faults { get; set; } = new List<Fault>();
}
