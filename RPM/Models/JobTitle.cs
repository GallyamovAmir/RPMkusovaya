using System;
using System.Collections.Generic;

namespace RPM.Models;

public partial class JobTitle
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Salary { get; set; }

    public virtual ICollection<Worker> Workers { get; } = new List<Worker>();
}
