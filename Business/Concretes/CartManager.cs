using Business.Abstracts;
using Business.Validations;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.DTOs;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class CartManager : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly CartValidations _cartValidations;
    public CartManager(ICartRepository cartRepository, CartValidations cartValidations)
    {
        _cartRepository = cartRepository;
        _cartValidations = cartValidations;
    }
    public Cart Add(AddCartDto addCartDto)
    {
        var cart = new Cart();
        cart.UserId = addCartDto.UserId;
        cart.TransactionDate = addCartDto.TransactionDate;
        _cartRepository.Add(cart);
        return cart;
    }

    public async Task<Cart> AddAsync(AddCartDto addCartDto)
    {
        var cart = new Cart();
        cart.UserId = addCartDto.UserId;
        cart.TransactionDate = addCartDto.TransactionDate;
        await _cartRepository.AddAsync(cart);
        return cart;
    }

    public void DeleteById(Guid id)
    {
        var userCart = _cartRepository.Get(predicate: cart => cart.Id == id);
        _cartValidations.CartMustNotEmpty(userCart).Wait();
        _cartRepository.Delete(userCart);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var userCart = await _cartRepository.GetAsync(predicate: cart => cart.Id == id);
        await _cartValidations.CartMustNotEmpty(userCart);
        await _cartRepository.DeleteAsync(userCart);
    }

    public IList<Cart> GetAll()
    {
        return _cartRepository.GetAll().ToList();
    }

    public async Task<IList<Cart>> GetAllAsync()
    {
        var result = await _cartRepository.GetAllAsync();
        return result.ToList();
    }

    public IList<Cart> GetAllProductsByCartId(Guid id)
    {
        return _cartRepository.GetAll(predicate:cart=>cart.Id == id,include:cart=>cart.Include(c=>c.CartItems)).ToList();
    }

    public async Task<IList<Cart>> GetAllProductsByCartIdAsync(Guid id)
    {
        var result = await _cartRepository.GetAllAsync(
            predicate: cart => cart.Id == id, include: cart => cart.Include(c => c.CartItems));
        return result.ToList();
    }

    public Cart? GetById(Guid id)
    {
        var cart = _cartRepository.Get(predicate:cart=>cart.Id==id);
        return cart;
    }

    public async Task<Cart?> GetByIdAsync(Guid id)
    {
        var cart = await _cartRepository.GetAsync(predicate: cart => cart.Id == id);
        return cart;
    }

    public Cart? GetByUserId(Guid userId)
    {
        var cart = _cartRepository.Get(predicate: cart => cart.UserId == userId);
        return cart;
    }

    public async Task<Cart?> GetByUserIdAsync(Guid userId)
    {
        var cart = await _cartRepository.GetAsync(predicate: cart => cart.UserId == userId);
        return cart;
    }

    public Cart Update(Cart cart)
    {
        var updateCart = _cartRepository.Get(predicate: c => c.Id == cart.Id);
        _cartValidations.CartMustNotEmpty(updateCart).Wait();
        updateCart.UserId = cart.UserId;
        updateCart.TransactionDate = cart.TransactionDate;
        _cartRepository.Update(updateCart);
        return updateCart;
    }

    public async Task<Cart> UpdateAsync(Cart cart)
    {
        var updateCart = await _cartRepository.GetAsync(predicate: cart => cart.Id == cart.Id);
        await _cartValidations.CartMustNotEmpty(updateCart);
        updateCart.UserId = cart.UserId;
        updateCart.TransactionDate = cart.TransactionDate;
        await _cartRepository.UpdateAsync(updateCart);
        return updateCart;
    }
}
