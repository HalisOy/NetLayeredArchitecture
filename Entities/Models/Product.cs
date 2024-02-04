using Core.Entities;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models;

public class Product : Entity<Guid>
{
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public virtual User User { get; set; }
    public virtual Category Category { get; set; }
    public virtual IEnumerable<ProductComment> Comments { get; set; }
    public Product()
    {
        Comments = new HashSet<ProductComment>();
    }
}
