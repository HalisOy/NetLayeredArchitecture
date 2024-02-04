using Business.Abstracts;
using Business.Validations;
using DataAccess.Abstracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly CategoryValidations _categoryValidations;
    public CategoryManager(ICategoryRepository categoryRepository, CategoryValidations categoryValidations)
    {
        _categoryRepository = categoryRepository;
        _categoryValidations = categoryValidations;
    }
    public Category Add(Category category)
    {
        _categoryRepository.Add(category);
        return category;
    }

    public async Task<Category> AddAsync(Category category)
    {
        var newCategory = new Category();
        newCategory.Name = category.Name;
        await _categoryRepository.AddAsync(newCategory);
        return newCategory;
    }

    public void DeleteById(Guid id)
    {
        var category = _categoryRepository.Get(predicate: category => category.Id == id);
        _categoryValidations.CategoryMustNotBeEmpty(category);
        _categoryRepository.Delete(category);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var category = _categoryRepository.Get(predicate: category => category.Id == id);
        await _categoryValidations.CategoryMustNotBeEmpty(category);
        await _categoryRepository.DeleteAsync(category);
    }

    public IList<Category> GetAll()
    {
        return _categoryRepository.GetAll().ToList();
    }

    public async Task<IList<Category>> GetAllAsync()
    {
        var result = await _categoryRepository.GetAllAsync();
        return result.ToList();
    }

    public IList<Category> GetAllProductsByCategoryId(Guid categoryId)
    {
        return _categoryRepository.GetAll(predicate: category => category.Id == categoryId, include: category => category.Include(c => c.Products)).ToList();
    }

    public async Task<IList<Category>> GetAllProductsByCategoryIdAsync(Guid categoryId)
    {
        var result = await _categoryRepository.GetAllAsync(
            predicate: category => category.Id == categoryId,
            include: category => category.Include(c => c.Products));
        return result.ToList();
    }

    public Category? GetById(Guid id)
    {
        return _categoryRepository.Get(predicate: category => category.Id == id);
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _categoryRepository.GetAsync(predicate: category => category.Id == id);
    }

    public Category Update(Category category)
    {
        return _categoryRepository.Update(category);
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        return await _categoryRepository.UpdateAsync(category);
    }
}
