using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OrderSelection2.Entities;

public partial class Role
{
    public int Id { get; set; }

    public string? Role1 { get; set; }
    [JsonIgnore]

    public virtual ICollection<Employer> Employers { get; set; } = new List<Employer>();
}
