﻿using Business.Tools.Exceptions;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations;

public class CartItemValidations
{
    public async Task CartItemMustNotEmpty(CartItem cartItem)
    {
        if (cartItem == null)
            throw new ValidationException("Cart Item must not be empty.",400);
        await Task.CompletedTask;
    }
}
