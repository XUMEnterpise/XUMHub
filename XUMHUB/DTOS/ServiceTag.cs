using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XUMHUB.DTOS;

[Keyless]
public partial class ServiceTag
{
    [StringLength(25)]
    [Unicode(false)]
    public string? ServiceKey { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Model { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string? SerialNumber { get; set; }
}
