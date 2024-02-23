using Business.Abstracts;
using DataAccess.Abstracts;
using Entities.DTOs;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class OrderManager : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderItemService _orderItemService;
    private readonly ICartService _cartService;
    public OrderManager(IOrderRepository orderRepository, IOrderItemService orderItemService, ICartService cartService)
    {
        _orderRepository = orderRepository;
        _orderItemService = orderItemService;
        _cartService = cartService;
    }

    public Order Add(AddOrderDto addOrderDto)
    {
        var order = _orderRepository.Add(new Order()
        {
            UserId = addOrderDto.UserId,
            CreatedDate = DateTime.Now,
            Status = "Ready"
        });
        var cart = _cartService.GetByUserId(addOrderDto.UserId);
        cart.CartItems.ToList().ForEach(orderItem =>
        {
            var orderItemDto = new AddOrderItemDto()
            {
                OrderId = order.Id,
                ProductId = orderItem.ProductId,
                Price = orderItem.Product.Price*orderItem.Quantity,
                Quantity = orderItem.Quantity
            };
            _orderItemService.Add(orderItemDto);
        });
        _cartService.AllDeleteCartItems(addOrderDto.UserId);
        return order;
    }

    public async Task<Order> AddAsync(AddOrderDto addOrderDto)
    {
        var order = await _orderRepository.AddAsync(new Order()
        {
            UserId = addOrderDto.UserId,
            CreatedDate = DateTime.Now,
            Status = "Ready"
        });
        var cart = await _cartService.GetByUserIdAsync(addOrderDto.UserId);
        for (int i = 0; i < cart.CartItems.Count; i++)
        {
            var orderItemDto = new AddOrderItemDto()
            {
                OrderId = order.Id,
                ProductId = cart.CartItems[i].ProductId,
                Price = cart.CartItems[i].Product.Price * cart.CartItems[i].Quantity,
                Quantity = cart.CartItems[i].Quantity
            };
            await _orderItemService.AddAsync(orderItemDto);
        }
        await _cartService.AllDeleteCartItemsAsync(addOrderDto.UserId);
        return order;
    }

    public void DeleteById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public IList<Order> GetAll()
    {
        return _orderRepository.GetAll().ToList();
    }

    public async Task<IList<Order>> GetAllAsync()
    {
        var result = await _orderRepository.GetAllAsync();
        return result.ToList();
    }

    public Order? GetById(Guid id)
    {
        return _orderRepository.Get(predicate: order => order.Id == id, include: order => order.Include(o=>o.OrderItems));
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await _orderRepository.GetAsync(predicate: order => order.Id == id, include: order => order.Include(o => o.OrderItems));
    }

    public Order Update(Order order)
    {
        throw new NotImplementedException();
    }

    public Task<Order> UpdateAsync(Order order)
    {
        throw new NotImplementedException();
    }
}
