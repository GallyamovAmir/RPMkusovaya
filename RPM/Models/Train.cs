using System;
using System.Collections.Generic;

namespace RPM.Models;

public partial class Train
{
    public int Id { get; set; }

    public DateTime DepartureTime { get; set; }

    public DateTime ArrivalTime { get; set; }

    public int ArrivalId { get; set; }

    public int DepartureId { get; set; }

    public virtual City Arrival { get; set; } = null!;

    public virtual City Departure { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; } = new List<Ticket>();
}
