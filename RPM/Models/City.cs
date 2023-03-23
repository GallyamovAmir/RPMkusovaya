using System;
using System.Collections.Generic;

namespace RPM.Models;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Train> TrainArrivals { get; } = new List<Train>();

    public virtual ICollection<Train> TrainDepartures { get; } = new List<Train>();
}
