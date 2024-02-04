using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models;

public class Cart : Entity<Guid>
{
    public Guid UserId { get; set; }
    public DateTime TransactionDate { get; set; }
    public virtual ICollection<CartItem> CartItems { get; set; }
    public Cart()
    {
        CartItems = new HashSet<CartItem>();
    }
}
