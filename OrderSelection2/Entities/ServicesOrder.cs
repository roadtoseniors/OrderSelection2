using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OrderSelection2.Entities;

public partial class ServicesOrder
{
    public int Id { get; set; }
    [JsonIgnore]
    public int? OrderId { get; set; }
    [JsonIgnore]

    public int? ServicesId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Service? Services { get; set; }
}
