using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OrderSelection2.Entities;

public partial class OrderStatus
{
    public int Id { get; set; }

    public string? OrderStatus1 { get; set; }
    [JsonIgnore]

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
