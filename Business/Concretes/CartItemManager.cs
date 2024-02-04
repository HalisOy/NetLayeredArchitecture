using Business.Abstracts;
using Business.Validations;
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

public class CartItemManager : ICartItemService
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly ICartService _cartService;
    private readonly CartItemValidations _cartItemValidations;

    public CartItemManager(ICartItemRepository cartItemRepository, ICartService cartService, CartItemValidations cartItemValidations)
    {
        _cartItemRepository = cartItemRepository;
        _cartService = cartService;
        _cartItemValidations = cartItemValidations;
    }

    public CartItem Add(AddCartItemDto addCartItemDto)
    {
        var cart = _cartService.GetByUserId(addCartItemDto.UserId);
        if (cart == null)
        {
            var cartDto = new AddCartDto()
            {
                UserId = addCartItemDto.UserId,
                TransactionDate = DateTime.Now
            };
            cart = _cartService.Add(cartDto);
        }
        var cartItem = new CartItem();
        cartItem.CartId = cart.Id;
        cartItem.ProductId = addCartItemDto.ProductId;
        cartItem.Quantity = addCartItemDto.Quantity;
        _cartItemRepository.Add(cartItem);
        return cartItem;
    }

    public async Task<CartItem> AddAsync(AddCartItemDto addCartItemDto)
    {
        var cart = await _cartService.GetByUserIdAsync(addCartItemDto.UserId);
        if (cart == null)
        {
            var cartDto = new AddCartDto()
            {
                UserId = addCartItemDto.UserId,
                TransactionDate = DateTime.Now
            };
            cart = _cartService.Add(cartDto);
        }
        var cartItem = await _cartItemRepository.GetAsync(predicate: item => item.ProductId == addCartItemDto.ProductId);
        if (cartItem == null)
        {
            cartItem.CartId = cart.Id;
            cartItem.ProductId = addCartItemDto.ProductId;
            cartItem.Quantity = addCartItemDto.Quantity;
        }
        cartItem.Quantity += addCartItemDto.Quantity;
        await _cartItemRepository.AddAsync(cartItem);
        return cartItem;
    }

    public void AddQuantity(Guid id)
    {
        var cartItem = _cartItemRepository.Get(predicate: cartItem => cartItem.Id == id);
        _cartItemValidations.CartItemMustNotEmpty(cartItem).Wait();
        cartItem.Quantity++;
        _cartItemRepository.Update(cartItem);
    }

    public async Task AddQuantityAsync(Guid id)
    {
        var cartItem = await _cartItemRepository.GetAsync(predicate: cartItem => cartItem.Id == id);
        await _cartItemValidations.CartItemMustNotEmpty(cartItem);
        cartItem.Quantity++;
        await _cartItemRepository.UpdateAsync(cartItem);
    }

    public void DecreaseQuantity(Guid id)
    {
        var cartItem = _cartItemRepository.Get(predicate: cartItem => cartItem.Id == id);
        _cartItemValidations.CartItemMustNotEmpty(cartItem).Wait();
        cartItem.Quantity--;
        _cartItemRepository.Update(cartItem);
    }

    public async Task DecreaseQuantityAsync(Guid id)
    {
        var cartItem = await _cartItemRepository.GetAsync(predicate: cartItem => cartItem.Id == id);
        await _cartItemValidations.CartItemMustNotEmpty(cartItem);
        cartItem.Quantity--;
        await _cartItemRepository.UpdateAsync(cartItem);
    }

    public void DeleteById(Guid id)
    {
        var cartItem = _cartItemRepository.Get(predicate: cartItem => cartItem.Id == id);
        _cartItemValidations.CartItemMustNotEmpty(cartItem).Wait();
        _cartItemRepository.Delete(cartItem);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var cartItem = await _cartItemRepository.GetAsync(predicate: cartItem => cartItem.Id == id);
        await _cartItemValidations.CartItemMustNotEmpty(cartItem);
        await _cartItemRepository.DeleteAsync(cartItem);
    }

    public IList<CartItem> GetAll()
    {
        return _cartItemRepository.GetAll().ToList();
    }

    public async Task<IList<CartItem>> GetAllAsync()
    {
        var result = await _cartItemRepository.GetAllAsync();
        return result.ToList();
    }

    public IList<CartItem> GetAllContents(Guid id)
    {
        return _cartItemRepository.GetAll(include: cartItem => cartItem.Include(c => c.Product)).ToList();
    }

    public async Task<IList<CartItem>> GetAllContentsAsync(Guid id)
    {
        var result = await _cartItemRepository.GetAllAsync(include: cartItem => cartItem.Include(c => c.Product));
        return result.ToList();
    }

    public CartItem? GetById(Guid id)
    {
        var result = _cartItemRepository.Get(predicate: cartItem => cartItem.Id == id);
        // null validations
        return result;
    }

    public async Task<CartItem?> GetByIdAsync(Guid id)
    {
        var result = await _cartItemRepository.GetAsync(predicate: cartItem => cartItem.Id == id);
        // null validations
        return result;
    }

    public CartItem Update(CartItem cartItem)
    {
        var result = _cartItemRepository.Get(predicate: cartItem => cartItem.Id == cartItem.Id);
        result.Quantity = cartItem.Quantity;
        _cartItemRepository.Update(result);
        return result;
    }

    public async Task<CartItem> UpdateAsync(CartItem cartItem)
    {
        var result = await _cartItemRepository.GetAsync(predicate: cartItem => cartItem.Id == cartItem.Id);
        result.Quantity = cartItem.Quantity;
        await _cartItemRepository.UpdateAsync(result);
        return result;
    }
}
