using Business.Abstracts;
using DataAccess.Abstracts;
using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class OrderItemManager : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;
    public OrderItemManager(IOrderItemRepository orderItemRepository)
    {
        _orderItemRepository = orderItemRepository;
    }
    public OrderItem Add(AddOrderItemDto addOrderItemDto)
    {
        var orderItem = new OrderItem();
        orderItem.OrderId = addOrderItemDto.OrderId;
        orderItem.ProductId = addOrderItemDto.ProductId;
        orderItem.Price = addOrderItemDto.Price;
        orderItem.Quantity = addOrderItemDto.Quantity;
        _orderItemRepository.Add(orderItem);
        return orderItem;
    }

    public async Task<OrderItem> AddAsync(AddOrderItemDto addOrderItemDto)
    {
        var orderItem = new OrderItem();
        orderItem.OrderId = addOrderItemDto.OrderId;
        orderItem.ProductId = addOrderItemDto.ProductId;
        orderItem.Price = addOrderItemDto.Price;
        orderItem.Quantity = addOrderItemDto.Quantity;
        await _orderItemRepository.AddAsync(orderItem);
        return orderItem;
    }
}
