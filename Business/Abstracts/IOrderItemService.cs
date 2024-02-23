using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IOrderItemService
{
    OrderItem Add(AddOrderItemDto addOrderItemDto);
    Task<OrderItem> AddAsync(AddOrderItemDto addOrderItemDto);
}
