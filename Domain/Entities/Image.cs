using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Image
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public byte[] ImageCode { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? Status { get; set; }

    public int? Thumbnail { get; set; }

    public virtual Product Product { get; set; }
}
