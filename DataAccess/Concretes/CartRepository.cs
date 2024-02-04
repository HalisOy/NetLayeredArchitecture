using DataAccess.Abstracts;
using DataAccess.Contexts;
using DataAccess.Core;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes;

public class CartRepository : Repository<Cart>, ICartRepository
{
    public CartRepository(BusinessDbContext context) : base(context)
    {
    }
}
