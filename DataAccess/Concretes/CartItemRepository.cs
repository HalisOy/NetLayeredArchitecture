﻿using DataAccess.Abstracts;
using DataAccess.Contexts;
using DataAccess.Core;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes;

public class CartItemRepository:Repository<CartItem>,ICartItemRepository
{
    public CartItemRepository(BusinessDbContext context):base(context) { }
}
