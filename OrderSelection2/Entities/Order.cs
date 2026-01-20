using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OrderSelection2.Entities;

public partial class Order
{
    public int Id { get; set; }

    public int? ExecutorId { get; set; }
    [JsonIgnore]

    public int? ClientsId { get; set; }
    [JsonIgnore]

    public int? ManagerId { get; set; }

    public string? DateOpenOrder { get; set; }

    public string? DateCloseOrder { get; set; }

    public int? OrderStatus { get; set; }

    public string? Description { get; set; }

    public string? Sum { get; set; }

    public int? InArchive { get; set; }

    public int? Categorial { get; set; }

    public virtual Categotial? CategorialNavigation { get; set; }

    public virtual Client? Clients { get; set; }

    public virtual Employer? Manager { get; set; }

    public virtual OrderStatus? OrderStatusNavigation { get; set; }
    [JsonIgnore]

    public virtual ICollection<ServicesOrder> ServicesOrders { get; set; } = new List<ServicesOrder>();
}
