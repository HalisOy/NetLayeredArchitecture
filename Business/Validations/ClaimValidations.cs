using Business.Tools.Exceptions;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations;
public class ClaimValidations
{
    public async Task ClaimMustNotBeEmpty(Claim? claim)
    {
        if (claim == null)
        {
            throw new ValidationException("Claim must not be empty.", 500);
        }
        await Task.CompletedTask;
    }
}
