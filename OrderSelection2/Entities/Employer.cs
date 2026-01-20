using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OrderSelection2.Entities;

public partial class Employer
{
    public int Id { get; set; }

    public int? Role { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Phone { get; set; }

    public double? Passport { get; set; }

    public string? DateOfBirthd { get; set; }

    public int? TypeLogin { get; set; }
    [JsonIgnore]

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role? RoleNavigation { get; set; }
}
