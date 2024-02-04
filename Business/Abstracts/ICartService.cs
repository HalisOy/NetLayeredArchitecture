using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface ICartService
{
    Cart? GetById(Guid id);
    Task<Cart?> GetByIdAsync(Guid id);
    Cart? GetByUserId(Guid userId);
    Task<Cart?> GetByUserIdAsync(Guid userId);
    IList<Cart> GetAll();
    Task<IList<Cart>> GetAllAsync();
    IList<Cart> GetAllProductsByCartId(Guid id);
    Task<IList<Cart>> GetAllProductsByCartIdAsync(Guid id);
    Cart Add(AddCartDto addCartDto);
    Cart Update(Cart cart);
    void DeleteById(Guid id);
    Task<Cart> AddAsync(AddCartDto addCartDto);
    Task<Cart> UpdateAsync(Cart cart);
    Task DeleteByIdAsync(Guid id);
}
