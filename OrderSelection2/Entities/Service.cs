using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OrderSelection2.Entities;

public partial class Service
{
    public int Id { get; set; }

    public string? NameServices { get; set; }

    public string? PriceServices { get; set; }
    [JsonIgnore]

    public virtual ICollection<ServicesOrder> ServicesOrders { get; set; } = new List<ServicesOrder>();
}
