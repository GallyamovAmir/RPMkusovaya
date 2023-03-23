using System;
using System.Collections.Generic;

namespace RPM.Models;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string Name { get; set; } = null!;

    public string? LastName { get; set; }

    public int PassportSeria { get; set; }

    public int PassportNumber { get; set; }

    public string Phone { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; } = new List<Ticket>();

    public virtual ICollection<Worker> Workers { get; } = new List<Worker>();
}
