using Business.Abstracts;
using Business.Validations;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class ProductCommentManager : IProductCommentService
{
    private readonly IProductCommentRepository _productCommentRepository;
    private readonly ProductCommentValidations _productCommentValidations;

    public ProductCommentManager(IProductCommentRepository productCommentRepository, ProductCommentValidations productCommentValidations)
    {
        _productCommentRepository = productCommentRepository;
        _productCommentValidations = productCommentValidations;
    }
    public ProductComment Add(AddProductCommentDto addProductCommentDto)
    {
        var productComment = new ProductComment();
        productComment.UserId = addProductCommentDto.UserId;
        productComment.ProductId = addProductCommentDto.ProductId;
        productComment.Rating = addProductCommentDto.Rating;
        productComment.Comment = addProductCommentDto.Comment;
        _productCommentRepository.Add(productComment);
        return productComment;
    }

    public async Task<ProductComment> AddAsync(AddProductCommentDto addProductCommentDto)
    {
        var productComment = new ProductComment();
        productComment.UserId = addProductCommentDto.UserId;
        productComment.ProductId = addProductCommentDto.ProductId;
        productComment.Rating = addProductCommentDto.Rating;
        productComment.Comment = addProductCommentDto.Comment;
        await _productCommentRepository.AddAsync(productComment);
        return productComment;
    }

    public void DeleteById(Guid id)
    {
        var productComment = _productCommentRepository.Get(predicate: productComment => productComment.Id == id);
        _productCommentValidations.ProductCommentMustNotEmpty(productComment).Wait();
        _productCommentRepository.Delete(productComment);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var productComment = await _productCommentRepository.GetAsync(predicate: productComment => productComment.Id == id);
        await _productCommentValidations.ProductCommentMustNotEmpty(productComment);
        await _productCommentRepository.DeleteAsync(productComment);
    }

    public IList<ProductComment?> GetByCommentsProductId(Guid productId)
    {
        return _productCommentRepository.GetAll(predicate: productComment => productComment.ProductId == productId).ToList();
    }

    public async Task<IList<ProductComment?>> GetByCommentsProductIdAsync(Guid productId)
    {
        var productComments = await _productCommentRepository.GetAllAsync(predicate: productComment => productComment.ProductId == productId);
        return productComments.ToList();
    }

    public ProductComment? GetById(Guid id)
    {
        return _productCommentRepository.Get(predicate: productComment => productComment.Id == id);
    }

    public async Task<ProductComment?> GetByIdAsync(Guid id)
    {
        return await _productCommentRepository.GetAsync(predicate: productComment => productComment.Id == id);
    }

    public ProductComment Update(ProductComment productComment)
    {
        var updateProductComment = _productCommentRepository.Get(predicate:productComment=>productComment.Id==productComment.Id);
        _productCommentValidations.ProductCommentMustNotEmpty(updateProductComment).Wait();
        updateProductComment.Id = productComment.Id;
        updateProductComment.UserId = productComment.UserId;
        updateProductComment.ProductId = productComment.ProductId;
        updateProductComment.Rating = productComment.Rating;
        updateProductComment.Comment = productComment.Comment;
        return _productCommentRepository.Add(updateProductComment);
    }

    public async Task<ProductComment> UpdateAsync(ProductComment productComment)
    {
        var updateProductComment = await _productCommentRepository.GetAsync(predicate: productComment => productComment.Id == productComment.Id);
        await _productCommentValidations.ProductCommentMustNotEmpty(updateProductComment);
        updateProductComment.Id = productComment.Id;
        updateProductComment.UserId = productComment.UserId;
        updateProductComment.ProductId = productComment.ProductId;
        updateProductComment.Rating = productComment.Rating;
        updateProductComment.Comment = productComment.Comment;
        return await _productCommentRepository.AddAsync(updateProductComment);
    }
}
