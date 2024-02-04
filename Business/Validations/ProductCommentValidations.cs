using Business.Tools.Exceptions;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations;

public class ProductCommentValidations
{
    public async Task ProductCommentMustNotEmpty(ProductComment productComment)
    {
        if (productComment == null)
            throw new ValidationException("Product comment must not be empty.",400);
    }
}
