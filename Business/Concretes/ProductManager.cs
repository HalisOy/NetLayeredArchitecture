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

public class ProductManager : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ProductValidations _productValidations;
    public ProductManager(IProductRepository productRepository, ProductValidations productValidations)
    {
        _productRepository = productRepository;
        _productValidations = productValidations;
    }
    public Product Add(AddProductDto addProductDto)
    {
        var product = new Product();
        product.UserId = addProductDto.UserId;
        product.CategoryId = addProductDto.CategoryId;
        product.Name = addProductDto.Name;
        product.Price = addProductDto.Price;
        product.Description = addProductDto.Description;
        product.IsActive = addProductDto.IsActive;
        _productRepository.Add(product);
        return product;
    }

    public async Task<Product> AddAsync(AddProductDto addProductDto)
    {
        var product = new Product();
        product.UserId = addProductDto.UserId;
        product.CategoryId = addProductDto.CategoryId;
        product.Name = addProductDto.Name;
        product.Price = addProductDto.Price;
        product.Description = addProductDto.Description;
        product.IsActive = addProductDto.IsActive;
        await _productRepository.AddAsync(product);
        return product;
    }

    public void DeleteById(Guid id)
    {
        var product = _productRepository.Get(predicate: product => product.Id == id);
        _productValidations.ProductMustNotBeEmpty(product);
        _productRepository.Delete(product);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var product = _productRepository.Get(predicate: product => product.Id == id);
        await _productValidations.ProductMustNotBeEmpty(product);
        await _productRepository.DeleteAsync(product);
    }

    public IList<Product> GetAll()
    {
        return _productRepository.GetAll().ToList();
    }

    public async Task<IList<Product>> GetAllAsync()
    {
        var result = await _productRepository.GetAllAsync();
        return result.ToList();
    }

    public IList<Product> GetAllByCategoryId(Guid categoryId)
    {
        return _productRepository.GetAll(predicate: product => product.CategoryId == categoryId).ToList();
    }

    public async Task<IList<Product>> GetAllByCategoryIdAsync(Guid categoryId)
    {
        var result = await _productRepository.GetAllAsync(predicate: product => product.CategoryId == categoryId);
        return result.ToList();
    }

    public IList<Product> GetAllByUserId(Guid userId)
    {
        return _productRepository.GetAll(predicate: product => product.UserId == userId,
            include: product => product.Include(p => p.Category).Include(p => p.User).Include(p => p.Comments)).ToList();
    }

    public async Task<IList<Product>> GetAllByUserIdAsync(Guid userId)
    {
        var result = await _productRepository.GetAllAsync(predicate: product => product.UserId == userId,
            include: product => product.Include(p => p.Category).Include(p => p.User).Include(p => p.Comments));
        return result.ToList();
    }

    public IList<Product> GetAllPriceRange(int minPrice, int maxPrice)
    {
        _productValidations.ProductPriceRange(minPrice, maxPrice);
        return _productRepository.GetAll(predicate: product => product.Price > minPrice && product.Price < maxPrice).ToList();
    }

    public async Task<IList<Product>> GetAllPriceRangeAsync(int minPrice, int maxPrice)
    {
        _productValidations.ProductPriceRange(minPrice, maxPrice);
        var result = await _productRepository.GetAllAsync(predicate: product => product.Price > minPrice && product.Price < maxPrice);
        return result.ToList();
    }

    public IList<Product> GetAllWithCategoryAndUser()
    {
        return _productRepository.GetAll(include: product => product.Include(p => p.Category).Include(p => p.User)).ToList();
    }

    public async Task<IList<Product>> GetAllWithCategoryAndUserAsync()
    {
        var result = await _productRepository.GetAllAsync(include: product => product.Include(p => p.Category).Include(p => p.User));
        return result.ToList();
    }

    public Product? GetById(Guid id)
    {
        return _productRepository.Get(predicate: product => product.Id == id);
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _productRepository.GetAsync(predicate: product => product.Id == id);
    }

    public Product Update(UpdateProductDto updateProductDto)
    {
        var product = _productRepository.Get(predicate: product => product.Id == updateProductDto.Id);
        _productValidations.ProductMustNotBeEmpty(product);
        product.UserId = updateProductDto.User.Id;
        product.CategoryId = updateProductDto.Category.Id;
        product.Name = updateProductDto.Name;
        product.Price = updateProductDto.Price;
        product.Description = updateProductDto.Description;
        product.IsActive = updateProductDto.IsActive;
        _productRepository.Update(product);
        return product;
    }

    public async Task<Product> UpdateAsync(UpdateProductDto updateProductDto)
    {
        var product = await _productRepository.GetAsync(predicate: product => product.Id == updateProductDto.Id);
        _productValidations.ProductMustNotBeEmpty(product);
        product.UserId = updateProductDto.User.Id;
        product.CategoryId = updateProductDto.Category.Id;
        product.Name = updateProductDto.Name;
        product.Price = updateProductDto.Price;
        product.Description = updateProductDto.Description;
        product.IsActive = updateProductDto.IsActive;
        await _productRepository.UpdateAsync(product);
        return product;
    }
}
