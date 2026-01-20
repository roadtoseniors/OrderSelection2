using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OrderSelection2.Entities;

public partial class Client
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? Phone { get; set; }

    public string? DateOfBirthd { get; set; }

    public string? PersonalSale { get; set; }
    [JsonIgnore]

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
