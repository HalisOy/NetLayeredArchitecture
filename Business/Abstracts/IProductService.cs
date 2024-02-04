using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IProductService
{
    Product? GetById(Guid id);
    Task<Product?> GetByIdAsync(Guid id);
    IList<Product> GetAll();
    Task<IList<Product>> GetAllAsync();
    IList<Product> GetAllWithCategoryAndUser();
    Task<IList<Product>> GetAllWithCategoryAndUserAsync();
    IList<Product> GetAllByUserId(Guid userId);
    Task<IList<Product>> GetAllByUserIdAsync(Guid userId);
    IList<Product> GetAllByCategoryId(Guid categoryId);
    Task<IList<Product>> GetAllByCategoryIdAsync(Guid categoryId);
    IList<Product> GetAllPriceRange(int minPrice, int maxPrice);
    Task<IList<Product>> GetAllPriceRangeAsync(int minPrice, int maxPrice);
    Product Add(AddProductDto addProductDto);
    Product Update(UpdateProductDto addProductDto);
    void DeleteById(Guid id);
    Task<Product> AddAsync(AddProductDto addProductDto);
    Task<Product> UpdateAsync(UpdateProductDto addProductDto);
    Task DeleteByIdAsync(Guid id);
}
