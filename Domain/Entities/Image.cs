

namespace Domain.Entities;

public class Image : BaseEntity
{
    public int? ProductId { get; set; }

    public string? ImageLink { get; set; }

    public int? Thumbnail { get; set; }

    public virtual Product Product { get; set; }
}
