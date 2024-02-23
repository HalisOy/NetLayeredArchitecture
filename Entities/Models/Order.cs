using Core.Entities;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models;

public class Order : Entity<Guid>
{
    public Guid UserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Status { get; set; }
    public virtual User User { get; set; }
    public virtual IEnumerable<OrderItem> OrderItems { get; set; }
    public Order()
    {
        OrderItems = new HashSet<OrderItem>();
    }

}
