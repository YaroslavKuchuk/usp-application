using System;
using System.Collections.Generic;

namespace Usp.Api.Data.Models;

public partial class SellingPointProperty
{
    public Guid Id { get; set; }

    public Guid SellingPointId { get; set; }

    public string? Name { get; set; }

    public virtual SellingPoint SellingPoint { get; set; } = null!;
}
