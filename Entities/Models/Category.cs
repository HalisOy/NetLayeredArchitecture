using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models;

public class Category : Entity<Guid>
{
    public string Name { get; set; }
    public virtual IEnumerable<Product>? Products { get; set; }
    public Category()
    {
        Products = new HashSet<Product>();
    }
}
