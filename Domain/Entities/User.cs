using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public byte[] LastName { get; set; }

    public byte[] Email { get; set; }

    public string Password { get; set; }

    public byte[] Avatar { get; set; }

    public string Phone { get; set; }

    public int? RoleId { get; set; }

    public int? Status { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<AddressUser> AddressUsers { get; set; } = new List<AddressUser>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual Role Role { get; set; }
}
