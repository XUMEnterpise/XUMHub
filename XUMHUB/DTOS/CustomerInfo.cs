using System;
using System.Collections.Generic;

namespace XUMHUB.DTOS;

public partial class CustomerInfo
{
    public int Id { get; set; }

    public string? OrderId { get; set; }

    public string? CustomerName { get; set; }

    public string? ChannelReference { get; set; }
}
