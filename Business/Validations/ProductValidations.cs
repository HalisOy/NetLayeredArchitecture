using Business.Tools.Exceptions;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations;

public class ProductValidations
{
    public async Task ProductMustNotBeEmpty(Product? product)
    {
        if (product == null)
            throw new ValidationException("Product must not be empty.");
        await Task.CompletedTask;
    }
    public async Task ProductPriceRange(int minPrice, int maxPrice)
    {
        if (minPrice > maxPrice)
            throw new ValidationException("minPrice cannot be more than maxPrice");
        await Task.CompletedTask;
    }
}
