using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ReportType
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public virtual ICollection<ReportOfUser> ReportOfUsers { get; set; } = new List<ReportOfUser>();
}
