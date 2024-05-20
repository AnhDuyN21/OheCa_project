using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class User : BaseEntity
{

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string Password { get; set; }
    public string Gender { get; set; }

    public byte[] Avatar { get; set; }

    public string? Phone { get; set; }

    public int? RoleId { get; set; }

    public string? ConfirmToken { get; set; }

    public int? Status { get; set; }

    public virtual ICollection<AddressUser> AddressUsers { get; set; } = new List<AddressUser>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Role Role { get; set; }
}
