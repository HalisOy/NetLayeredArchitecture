using Business.Tools.Exceptions;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations;

public class CartValidations
{
    public async Task CartMustNotEmpty(Cart cart)
    {
        if (cart == null)
            throw new ValidationException("Cart must not be empty.",400);
        await Task.CompletedTask;
    }
}
