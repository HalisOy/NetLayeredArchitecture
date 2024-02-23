using Business.Tools.Exceptions;
using Core.Entities;
using Entities.DTOs;
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
        if (user == null)
        {
            throw new ValidationException("User must not be empty.", 500);
        }
        await Task.CompletedTask;
    }

    public async Task UserHaveClaim(User user, Claim claim)
    {
        bool have=false;
        user.UserClaims.ToList().ForEach(userClaim =>
        {
            if (userClaim.ClaimId == claim.Id)
                throw new ValidationException("The user have this claim", 402);

        });
    }
}
