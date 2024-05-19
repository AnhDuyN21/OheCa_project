

namespace Domain.Entities;

public class Image : BaseEntity
{
    public int? ProductId { get; set; }

    public byte[] ImageCode { get; set; }

    public int? Thumbnail { get; set; }

    public virtual Product Product { get; set; }
}
