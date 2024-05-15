using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ReportOfUser
{
    public int Id { get; set; }

    public int? CommentId { get; set; }

    public int? ReportTypeId { get; set; }

    public virtual Comment Comment { get; set; }

    public virtual ReportType ReportType { get; set; }
}
