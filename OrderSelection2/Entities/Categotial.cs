using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OrderSelection2.Entities;

public partial class Categotial
{
    public int Id { get; set; }

    public string? Categorial { get; set; }
    [JsonIgnore]

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
