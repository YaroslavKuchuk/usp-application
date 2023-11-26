using System;
using System.Collections.Generic;

namespace Usp.Api.Data.Models;

public partial class SellingPoint
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Header { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<SellingPointPrice> SellingPointPrices { get; set; } = new List<SellingPointPrice>();

    public virtual ICollection<SellingPointProperty> SellingPointProperties { get; set; } = new List<SellingPointProperty>();
}
