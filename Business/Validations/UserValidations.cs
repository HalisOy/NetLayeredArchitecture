using Business.Tools.Exceptions;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations;
public class UserValidations
{
    public async Task UserMustNotBeEmpty(User? user)
    {
        if(user == null)
        {
            throw new ValidationException("User must not be empty.", 500);
        }
        await Task.CompletedTask;
    }
}
