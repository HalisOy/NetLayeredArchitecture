using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface ICartItemService
{
    CartItem? GetById(Guid id);
    Task<CartItem?> GetByIdAsync(Guid id);
    IList<CartItem> GetAll();
    Task<IList<CartItem>> GetAllAsync();
    IList<CartItem> GetAllContents(Guid id);
    Task<IList<CartItem>> GetAllContentsAsync(Guid id);
    CartItem Add(AddCartItemDto addCartItemDto);
    CartItem Update(CartItem cartItem);
    void DeleteById(Guid id);
    Task<CartItem> AddAsync(AddCartItemDto addCartItemDto);
    Task<CartItem> UpdateAsync(CartItem cartItem);
    Task DeleteByIdAsync(Guid id);
    void AddQuantity(Guid id);
    Task AddQuantityAsync(Guid id);
    void DecreaseQuantity(Guid id);
    Task DecreaseQuantityAsync(Guid id);
}
