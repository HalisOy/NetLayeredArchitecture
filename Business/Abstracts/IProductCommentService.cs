using Core.Repository;
using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IProductCommentService
{
    ProductComment? GetById(Guid id);
    Task<ProductComment?> GetByIdAsync(Guid id);
    IList<ProductComment?> GetByCommentsProductId(Guid productId);
    Task<IList<ProductComment?>> GetByCommentsProductIdAsync(Guid productId);
    ProductComment Add(AddProductCommentDto addProductCommentDto);
    ProductComment Update(ProductComment productComment);
    void DeleteById(Guid id);
    Task<ProductComment> AddAsync(AddProductCommentDto addProductCommentDto);
    Task<ProductComment> UpdateAsync(ProductComment productComment);
    Task DeleteByIdAsync(Guid id);
}
