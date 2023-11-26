using System;
using System.Collections.Generic;

namespace Usp.Api.Data.Models;

public partial class SellingPointPrice
{
    public Guid Id { get; set; }

    public Guid SellingPointId { get; set; }

    public decimal Price { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual SellingPoint SellingPoint { get; set; } = null!;
}
