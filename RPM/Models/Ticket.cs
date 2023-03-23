using System;
using System.Collections.Generic;

namespace RPM.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public int Place { get; set; }

    public decimal Price { get; set; }

    public int Type { get; set; }

    public int TrainId { get; set; }

    public int State { get; set; }

    public int? ClientId { get; set; }

    public virtual User? Client { get; set; }

    public virtual State StateNavigation { get; set; } = null!;

    public virtual Train Train { get; set; } = null!;

    public virtual Type TypeNavigation { get; set; } = null!;
}
