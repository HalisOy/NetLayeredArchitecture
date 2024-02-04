using Business.Abstracts;
using Business.Validations;
using DataAccess.Abstracts;
using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class ProductStockTransactionManager : IProductStockTransactionService
{
    private readonly IProductStockTransactionRepository _productStockTransactionRepository;
    private readonly ProductStockTransactionValidations _productStockTransactionValidations;

    public ProductStockTransactionManager(IProductStockTransactionRepository productStockTransactionRepository, ProductStockTransactionValidations productStockTransactionValidations)
    {
        _productStockTransactionRepository = productStockTransactionRepository;
        _productStockTransactionValidations = productStockTransactionValidations;
    }
    public ProductStockTransaction Add(AddProductStockTransactionDto addProductStockTransactionDto)
    {
        var productStockTransaction = new ProductStockTransaction();
        productStockTransaction.ProductId = addProductStockTransactionDto.ProductId;
        productStockTransaction.Quantity = addProductStockTransactionDto.Quantity;
        productStockTransaction.TransactionTime = _productStockTransactionValidations.CreatedTimeMustNotBeEmpty(addProductStockTransactionDto.TransactionTime);
        return _productStockTransactionRepository.Add(productStockTransaction);
    }

    public async Task<ProductStockTransaction> AddAsync(AddProductStockTransactionDto addProductStockTransactionDto)
    {
        var productStockTransaction = new ProductStockTransaction();
        productStockTransaction.ProductId = addProductStockTransactionDto.ProductId;
        productStockTransaction.Quantity = addProductStockTransactionDto.Quantity;
        productStockTransaction.TransactionTime = _productStockTransactionValidations.CreatedTimeMustNotBeEmpty(addProductStockTransactionDto.TransactionTime);
        return await _productStockTransactionRepository.AddAsync(productStockTransaction);
    }

    public void DeleteById(Guid id)
    {
        var productStockTransaction = _productStockTransactionRepository.Get(productStockTransaction=> productStockTransaction.Id==id);
        _productStockTransactionValidations.ProductStockTransactionMustNotEmpty(productStockTransaction);
        _productStockTransactionRepository.Delete(productStockTransaction);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var productStockTransaction = _productStockTransactionRepository.Get(productStockTransaction => productStockTransaction.Id == id);
        await _productStockTransactionValidations.ProductStockTransactionMustNotEmpty(productStockTransaction);
        await _productStockTransactionRepository.DeleteAsync(productStockTransaction);
    }

    public IList<ProductStockTransaction> GetAll()
    {
        return _productStockTransactionRepository.GetAll().ToList();
    }

    public async Task<IList<ProductStockTransaction>> GetAllAsync()
    {
        var result = await _productStockTransactionRepository.GetAllAsync();
        return result.ToList();
    }

    public ProductStockTransaction? GetById(Guid id)
    {
        return _productStockTransactionRepository.Get(
            predicate:productStockTransaction=>productStockTransaction.Id==id);
    }

    public async Task<ProductStockTransaction?> GetByIdAsync(Guid id)
    {
        return await _productStockTransactionRepository.GetAsync(
            predicate: productStockTransaction => productStockTransaction.Id == id);
    }

    public int ProductStockCount(Guid productId)
    {
        return _productStockTransactionRepository
            .GetAll(predicate: product => product.ProductId == productId).Sum(product => product.Quantity);
    }

    public async Task<int> ProductStockCountAsync(Guid productId)
    {
        var result = await _productStockTransactionRepository
            .GetAllAsync(predicate: product => product.ProductId == productId);
        return result.Sum(product => product.Quantity);
    }

    public ProductStockTransaction Update(UpdateProductStockTransactionDto updateProductStockTransactionDto)
    {
        var productStockTransaction = _productStockTransactionRepository
            .Get(predicate:productStockTransaction=>productStockTransaction.Id==updateProductStockTransactionDto.Id);
        productStockTransaction.Id = updateProductStockTransactionDto.Id;
        productStockTransaction.ProductId = updateProductStockTransactionDto.ProductId;
        productStockTransaction.Quantity = updateProductStockTransactionDto.Quantity;
        return _productStockTransactionRepository.Update(productStockTransaction);
    }

    public async Task<ProductStockTransaction> UpdateAsync(UpdateProductStockTransactionDto updateProductStockTransactionDto)
    {
        var productStockTransaction = await _productStockTransactionRepository
            .GetAsync(predicate: productStockTransaction => productStockTransaction.Id == updateProductStockTransactionDto.Id);
        productStockTransaction.Id = updateProductStockTransactionDto.Id;
        productStockTransaction.ProductId = updateProductStockTransactionDto.ProductId;
        productStockTransaction.Quantity = updateProductStockTransactionDto.Quantity;
        return await _productStockTransactionRepository.UpdateAsync(productStockTransaction);
    }
}
