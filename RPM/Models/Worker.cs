using System;
using System.Collections.Generic;

namespace RPM.Models;

public partial class Worker
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int JobTitleId { get; set; }

    public virtual JobTitle JobTitle { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
