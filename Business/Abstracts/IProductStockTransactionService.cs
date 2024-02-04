using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IProductStockTransactionService
{
    ProductStockTransaction? GetById(Guid id);
    Task<ProductStockTransaction?> GetByIdAsync(Guid id);
    IList<ProductStockTransaction> GetAll();
    Task<IList<ProductStockTransaction>> GetAllAsync();
    int ProductStockCount(Guid productId);
    Task<int> ProductStockCountAsync(Guid productId);
    ProductStockTransaction Add(AddProductStockTransactionDto addProductStockTransactionDto);
    ProductStockTransaction Update(UpdateProductStockTransactionDto updateProductStockTransactionDto);
    void DeleteById(Guid id);
    Task<ProductStockTransaction> AddAsync(AddProductStockTransactionDto addProductStockTransactionDto);
    Task<ProductStockTransaction> UpdateAsync(UpdateProductStockTransactionDto updateProductStockTransactionDto);
    Task DeleteByIdAsync(Guid id);
}
